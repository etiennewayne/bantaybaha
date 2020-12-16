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
    public partial class PhonebookAdd : Form
    {

        public int id;


        PhonebookMainform _frm;

        public PhonebookAdd(PhonebookMainform _frm)
        {
            InitializeComponent();
            this._frm = _frm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtlname.Text))
            {
                Box.warnBox("Please input lastname.");
                return;
            }
            if (String.IsNullOrEmpty(txtfname.Text))
            {
                Box.warnBox("Please input firstname.");
                return;
            }

            if (String.IsNullOrEmpty(cmbGender.Text))
            {
                Box.warnBox("Please select gender.");
                return;
            }

            if (!txtContact.MaskFull)
            {
                Box.warnBox("Please input contact no.");
                return;
            }

            processSave();
            _frm.loaddata();
            this.Close();
        }


        void getData()
        {
            Phonebook pb = new Phonebook();

            txtlname.Text = Convert.ToString(pb.find(id).Rows[0]["lname"]);
            txtfname.Text = Convert.ToString(pb.find(id).Rows[0]["fname"]);
            txtmname.Text = Convert.ToString(pb.find(id).Rows[0]["mname"]);
            cmbGender.Text = Convert.ToString(pb.find(id).Rows[0]["gender"]);
            txtContact.Text = Convert.ToString(pb.find(id).Rows[0]["contactNo"]);
        }

        void processSave()
        {
            if (id > 0)
            {
                new Phonebook(txtlname.Text, txtfname.Text, txtmname.Text, cmbGender.Text, txtContact.Text).update(id);
                Box.infoBox("Data successfully updated.");
            }
            else
            {
                new Phonebook(txtlname.Text, txtfname.Text, txtmname.Text, cmbGender.Text, txtContact.Text).insert();
                Box.infoBox("Data successfully saved.");
            }
        }

        private void PhonebookAdd_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                getData();
            }
        }
    }
}
