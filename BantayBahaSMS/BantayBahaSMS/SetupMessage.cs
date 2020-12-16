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
    public partial class SetupMessage : Form
    {
        public SetupMessage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           Properties.Settings.Default.msg1 = txtOrange.Text;
           Properties.Settings.Default.msg2 = txtRed.Text;
            Properties.Settings.Default.Save();
            Box.infoBox("Message(s) saved!");
        }

        private void SetupMessage_Load(object sender, EventArgs e)
        {
            txtOrange.Text = Properties.Settings.Default.msg1;
            txtRed.Text = Properties.Settings.Default.msg2;
        }
    }
}
