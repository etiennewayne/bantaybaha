using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BantayBahaSMS
{
    public partial class Login : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        string query;


        public Login()
        {
            InitializeComponent();
        }


        bool Auth()
        {

            bool flag = false;
            con = Connection.con();
            con.Open();
            query = "select * from users where username=?user and pwd=?pwd";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?user", txtuser.Text.Trim());
            cmd.Parameters.AddWithValue("?pwd", txtpwd.Text.Trim());
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                flag = true;
                Properties.Settings.Default.userid = Convert.ToInt32(dr["userID"]);
                Properties.Settings.Default.username = Convert.ToString(dr["username"]);
                Properties.Settings.Default.lname = Convert.ToString(dr["lname"]);
                Properties.Settings.Default.fname = Convert.ToString(dr["fname"]);
                Properties.Settings.Default.mname = Convert.ToString(dr["mname"]);
                //  Properties.Settings.Default.position = Convert.ToString(dr["position"]);
               // position = Convert.ToString(dr["position"]);
               // posid = Convert.ToInt32(dr["positionID"]);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return flag;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtuser.Text))
            {
                Box.warnBox("Please input username.");
                return;
            }

            if (String.IsNullOrEmpty(txtpwd.Text))
            {
                Box.warnBox("Please input password.");
                return;
            }
            try
            {
                if (Auth())
                {
                    txtuser.Text = "";
                    txtpwd.Text = "";

                    Mainform frm = new Mainform(this);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    Box.warnBox("Username and Password error.");
                }
            }
            catch (Exception er)
            {

                // throw;
                Box.errBox("Connection error. \n" + er.Message);
            }
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConnectionSetting frm = new ConnectionSetting();
            frm.ShowDialog();
        }
    }
}
