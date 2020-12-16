using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BantayBahaSMS.Class;
using MySql.Data.MySqlClient;

namespace BantayBahaSMS
{
    public partial class Mainform : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        string query;

        bool isSMSModemConnected;
        bool isLoop;

        Login _frm;

        SMS sms = new SMS();

        DataTable dtMobile = new DataTable();

        short portNo;


        bool toSend = false;
        bool againSend;



        bool alreadySent2040;
        bool alreadySent4160;
        bool alreadySent60Above;





        public Mainform(Login _frm)
        {
            InitializeComponent();
            this._frm = _frm;
        }

        void getComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {

                cmbPorts.Items.Add(port);
            }
        }


        private void Mainform_Load(object sender, EventArgs e)
        {
            try
            {
                timerTime.Start();
                timerChecker.Start();


                getComPorts();


                
                
            }
            catch (Exception er)
            {

               // throw;
            }
        }

        private void threadSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                sms.s_port = portNo;
                sms.InitModem();
                sms.OpenModemCommunication();


                if (btnConnect.InvokeRequired)
                {
                    btnConnect.Invoke(new MethodInvoker(delegate
                    {
                        btnConnect.Text = "Disconnect";
                        btnConnect.Enabled = true;
                        isSMSModemConnected = true;
                        isLoop = true;
                        txtModemLogs.AppendText(Environment.NewLine + "System : Modem Connected Successfully.");

                    }));
                }


                if (isSMSModemConnected)
                {
                    DataTable dt = new DataTable();
                  

                    //////////
                    ////.////
                    /////////////
                    ///Dara ang LOOP SIGA KAG MATA!!!
                    while (isLoop)
                    {

                        //reading = 20 to 40 above normar, 'Pangandam namo. Water level is above 20'

                        //reading = 41 to 60 High, 'Water level is above 40'

                        //reading = above 60, 'Critical level' force evacuation

                        dt.Clear();

                        using (MySqlConnection conn = new MySqlConnection(Connection.getConnectionString()))
                        {
                            MySqlCommand threadCmd;

                            //conn = Connection.con();
                            conn.Open();
                            string threadQuery = "select * from messages where isSent = 0 and date(dateTimeLog) = curdate()";
                            threadCmd = new MySqlCommand(threadQuery, conn);
                            //threadCmd.Parameters.AddWithValue("?dDay", DateTime.Now.ToString("yyyy-MM-dd"));
                            MySqlDataAdapter aa = new MySqlDataAdapter(threadCmd);
                            aa.Fill(dt);
                            aa.Dispose();
                            threadCmd.Dispose();
                            conn.Close();
                        }


                        if (dt.Rows.Count > 0)
                        {

                            for (int row = 0; row < dt.Rows.Count; row++)
                            {

                                string mobileNo = Convert.ToString(dt.Rows[row]["mobileNo"]);
                                string msg = Convert.ToString(dt.Rows[row]["msg"]);
                                int msgid = Convert.ToInt32(dt.Rows[row]["messageID"]);

                                txtModemLogs.Invoke(new MethodInvoker(delegate
                                {
                                    txtModemLogs.AppendText(Environment.NewLine + "System : Sending to " + mobileNo + ", Message : (" + msg + ")");
                                }));

                        

                                try
                                {
                                    sms.SendMessage(mobileNo, msg, false);
                                    sms.SendMessage(mobileNo, msg, false);
                                    sms.SendMessage(mobileNo, msg, false);
                                    sms.SendMessage(mobileNo, msg, false);
                                    sms.SendMessage(mobileNo, msg, false);

                                    updateIsSent(msgid);
                                }
                                catch (Exception er)
                                {
                                    txtModemLogs.Invoke(new MethodInvoker(delegate
                                    {

                                        txtModemLogs.AppendText(Environment.NewLine + "System : ERROR : " + er.Message + "\nThis message will be send later.");
                                        //btnConnect.Enabled = true;
                                        //btnConnect.Text = "Connect";

                                    }));
                                    // throw;
                                }

                               

                                txtModemLogs.Invoke(new MethodInvoker(delegate
                                {
                                    txtModemLogs.AppendText(Environment.NewLine + "System : Message sending sent.");
                                }));


                                Thread.Sleep(5000);
                            }//end for loop
                        }

                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception er)
            {
                txtModemLogs.Invoke(new MethodInvoker(delegate
                {

                    txtModemLogs.AppendText(Environment.NewLine + "System : ERROR : " + er.Message);
                    btnConnect.Enabled = true;
                    btnConnect.Text = "Connect";

                }));

            }
        }//close do work

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(cmbPorts.Text == "")
            {
                Box.warnBox("Please select port.");
                return;
            }

            try
            {

                if (btnConnect.Text == "Connect")
                {
                    portNo = Convert.ToInt16(cmbPorts.Text.Replace("COM", ""));
                    btnConnect.Enabled = false;
                    btnConnect.Text = "Connecting...";
                    threadSMS.RunWorkerAsync();


                }
                else if (btnConnect.Text == "Disconnect")
                {
                    btnConnect.Text = "Connect";
                    sms.CloseModemCommunication();
                    isSMSModemConnected = false;
                    txtModemLogs.AppendText(Environment.NewLine + "System : Modem Disconnected.");
                    isLoop = false;
                    threadSMS.Dispose(); ;
                    // timerLate.Stop();
                }

            }
            catch (Exception er)
            {
                isSMSModemConnected = false;
                btnConnect.Text = "Connect";
                btnConnect.Enabled = true;
                txtModemLogs.AppendText(Environment.NewLine + "System : ERROR : " + er.Message);

            }


        }


        void SaveMessage(string msg)
        {
            con = Connection.con();
            con.Open();
            query = "select * from phonebook";
            cmd = new MySqlCommand(query, con);

            DataTable dtphonebook = new DataTable();
            MySqlDataAdapter adptr = new MySqlDataAdapter(cmd);
            adptr.Fill(dtphonebook);
            adptr.Dispose();
            cmd.Dispose();

            query = "insert into messages set mobileNo=?mobile, msg=?msg";
            cmd = new MySqlCommand(query, con);

            if (dtphonebook.Rows.Count > 0)
            {
                for(int i = 0; i < dtphonebook.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("?mobile", Convert.ToString(dtphonebook.Rows[i]["contactNo"]));
                    cmd.Parameters.AddWithValue("?msg",msg);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            cmd.Dispose();

            con.Close();
            con.Dispose();
           
        }

        private void Mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            isLoop = false;
            _frm.Show();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void timerChecker_Tick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int measure;
            string bodyMsg;

            using (MySqlConnection conn = new MySqlConnection(Connection.getConnectionString()))
            {
                MySqlCommand threadCmd;

                //conn = Connection.con();
                conn.Open();
                string threadQuery = "select * from measures order by id desc limit 1";
                threadCmd = new MySqlCommand(threadQuery, conn);
                //threadCmd.Parameters.AddWithValue("?dDay", DateTime.Now.ToString("yyyy-MM-dd"));
                MySqlDataAdapter aa = new MySqlDataAdapter(threadCmd);
                aa.Fill(dt);
                aa.Dispose();
                threadCmd.Dispose();
                conn.Close();
            }


            if (dt.Rows.Count > 0)
            {
                //for (int row = 0; row < dt.Rows.Count; row++)
                //{

                //}


                measure = Convert.ToInt32(dt.Rows[0]["distance"]);

                //if (measure >= 20 && measure <= 40)
                //{
                //    bodyMsg = "Water level is now above 20.";

                //    if (!alreadySent2040)
                //    {
                //        SaveMessage(bodyMsg);
                //        alreadySent2040 = true;
                //    }

                //}

                if (measure >= 41 && measure <= 60)
                {
                    //bodyMsg = "Water level is now in high. Empake nag sugod bes.";
                    bodyMsg = Properties.Settings.Default.msg1;
                    if (!alreadySent4160)
                    {
                        SaveMessage(bodyMsg);
                        alreadySent4160 = true;
                    }
                }

                if (measure > 60)
                {
                    //bodyMsg = "Water level is critical. Force evacuation will be implemented. Ayaw too, anod jud ka.";
                    bodyMsg = Properties.Settings.Default.msg2;
                    if (!alreadySent60Above)
                    {
                        SaveMessage(bodyMsg);
                        alreadySent60Above = true;
                    }
                }


                if (measure < 41)
                {
                    alreadySent2040 = false;
                    alreadySent4160 = false;
                    alreadySent60Above = false;
                }

              

            }
        } //timerChecker


        void updateIsSent(int id)
        {
            con = Connection.con();
            con.Open();
            query = "update messages set isSent=1 where messageID=?id";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?id", id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }

        private void phonebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhonebookMainform frm = new PhonebookMainform();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMainform frm = new UserMainform();
            frm.ShowDialog();
        }

        private void setSMSMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupMessage frm = new SetupMessage();
            frm.ShowDialog();
        }
    }
}
