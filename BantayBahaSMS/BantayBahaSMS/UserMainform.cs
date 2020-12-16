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
    public partial class UserMainform : Form
    {
        public UserMainform()
        {
            InitializeComponent();
        }



        public void LoadData()
        {
            flx.AutoGenerateColumns = false;
            flx.DataSource = new User().search(txtUsername.Text, txtlname.Text, txtfname.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();

            }
            catch (Exception er)
            {
                Box.errBox(er.Message);
                //throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserAdd frm = new UserAdd(this);
            frm.id = 0;
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(flx.Rows.Count > 1)
            {
                UserAdd frm = new UserAdd(this);
                frm.id = Convert.ToInt32(flx[flx.RowSel,"userid"]);
                frm.ShowDialog();
            }
            else
            {
                Box.warnBox("No data selected.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (flx.Rows.Count > 1)
            {
                if (Box.questionBox("Are you sure you want to delete this data?", "DELETE?"))
                {
                    int id = Convert.ToInt32(flx[flx.RowSel, "userid"]);
                    new User().delete(id);
                    LoadData();
                    Box.infoBox("Successfully deleted.");
                }
            }
            else
            {
                Box.warnBox("No data selected.");
            }
          
        }

        private void UserMainform_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                Box.errBox(er.Message);
               // throw;
            }
        }
    }
}
