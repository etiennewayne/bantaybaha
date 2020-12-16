using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BantayBahaSMS.Class;
using System.Windows.Forms;

namespace BantayBahaSMS
{
    public partial class PhonebookMainform : Form
    {
        public PhonebookMainform()
        {
            InitializeComponent();
        }


        public void loaddata()
        {
            flx.AutoGenerateColumns = false;
            flx.DataSource = new Phonebook().search(txtlname.Text, txtfname.Text);
        }

        private void PhonebookMainform_Load(object sender, EventArgs e)
        {
            try
            {
                loaddata();
               
            }
            catch (Exception er)
            {
                Box.errBox(er.Message);
                //throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                loaddata();

            }
            catch (Exception er)
            {
                Box.errBox(er.Message);
                //throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PhonebookAdd frm = new PhonebookAdd(this);
            frm.id = 0;
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(flx.Rows.Count > 1)
            {
                PhonebookAdd frm = new PhonebookAdd(this);
                frm.id = Convert.ToInt32(flx[flx.RowSel, "phonebookID"]);
                frm.ShowDialog();
            }
            else
            {
                Box.warnBox("No data found!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Box.questionBox("Are you sure you want to delete?", "DELETE?"))
            {
                new Phonebook().delete(Convert.ToInt32(flx[flx.RowSel, "phonebookID"]));
                Box.infoBox("Data successfully deleted.");
                loaddata();
            }
        }
    }
}
