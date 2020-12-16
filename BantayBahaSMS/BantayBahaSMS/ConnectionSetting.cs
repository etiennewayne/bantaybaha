using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BantayBahaSMS
{
    public partial class ConnectionSetting : Form
    {
        public ConnectionSetting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server =  txtHost.Text;
            Properties.Settings.Default.dbuser = txtUser.Text;
            Properties.Settings.Default.dbpwd = txtPwd.Text;
            Properties.Settings.Default.database = txtDatabase.Text;
            Properties.Settings.Default.Save();

            Box.infoBox("Setting saved.");
            this.Close();
        }

        private void ConnectionSetting_Load(object sender, EventArgs e)
        {
            txtHost.Text = Properties.Settings.Default.server;
            txtUser.Text = Properties.Settings.Default.dbuser;
            txtPwd.Text = Properties.Settings.Default.dbpwd;
            txtDatabase.Text = Properties.Settings.Default.database;

        }
    }
}
