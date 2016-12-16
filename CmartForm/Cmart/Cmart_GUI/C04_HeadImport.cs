using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cmart.Cmart_GUI;
namespace Cmart.Cmart_GUI
{
    public partial class C04_HeadImport : Form
    {
        validation a = new validation();
        public C04_HeadImport(string name)
        {
            InitializeComponent();
            lblName.Text = name;
            importManagementToolStripMenuItem.Visible = false;
            billToolStripMenuItem.Visible = false;
            categoToolStripMenuItem.Visible = false;
            statisticToolStripMenuItem.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string message = null;
            string idExisted = "C001";
            if (!a.Required(txtIDRequest))
            {
                message += "IDRequest is a required field";
            }
            else if (a.Compare(txtIDRequest.Text.ToString(), idExisted))
            {
                message += "IDRequest is existed";
            }
            if (message == null)
            {
                MessageBox.Show("Success");
            }
            else MessageBox.Show(message);
        }

        private void productToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        
        }

        private void promotionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void priceHistoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          
        }

        private void headImportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void branchImportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
  
        }

        private void billToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
      
        }

        private void statisticToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
     
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            C01_Login a = new C01_Login();
            a.ShowDialog();
            this.Close();
        }
    }
}
