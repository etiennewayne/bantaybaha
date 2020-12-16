using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BantayBahaSMS.Class;

namespace BantayBahaSMS
{

    
    public partial class UserAdd : Form
    {
        public int id;

        UserMainform _frm;

        public UserAdd(UserMainform _frm)
        {
            InitializeComponent();
            this._frm = _frm;
        }

        void proccessSave()
        {
            if (id > 0)
            {
                new User(txtuser.Text, txtpwd.Text, txtlname.Text, txtfname.Text, txtmname.Text, cmbGender.Text).update(id);
                Box.infoBox("User successfully updated.");
                
            }
            else
            {
                new User(txtuser.Text, txtpwd.Text, txtlname.Text, txtfname.Text, txtmname.Text, cmbGender.Text).insert();
                Box.infoBox("User successfully saved.");
            }
        }

        void getData()
        {
            User user = new User();

            txtuser.Text = Convert.ToString(user.find(id).Rows[0]["username"]);
            txtlname.Text = Convert.ToString(user.find(id).Rows[0]["lname"]);
            txtfname.Text = Convert.ToString(user.find(id).Rows[0]["fname"]);
            txtmname.Text = Convert.ToString(user.find(id).Rows[0]["mname"]);
            cmbGender.Text = Convert.ToString(user.find(id).Rows[0]["gender"]);
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            if(txtpwd.Text != txtrpwd.Text)
            {
                Box.warnBox("Password not match.");
                return;
            }
            if (String.IsNullOrEmpty(cmbGender.Text))
            {
                Box.warnBox("Please select gender.");
                return;
            }

            proccessSave();
            _frm.LoadData();
            this.Close();

        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                getData();
            }
        }
    }
}
