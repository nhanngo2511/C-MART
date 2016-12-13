using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmart.Cmart_GUI
{
    public partial class C03_Bill : Form
    {
        validation a = new validation();
        public C03_Bill()
        {
            InitializeComponent();
        }
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string message = null;
            string idProduct = "C001";
            if (!a.Required(txtIDProduct))
            {
                message += "IDProduct is a required field\n";
            }
            else if (!a.Compare(txtIDProduct.Text.ToString(),idProduct))
            {
                message += "IDProduct is not existed\n";
            }
            if (!a.Required(txtQuantity))
            {
                message += "Quantity is a required field\n";
            }
            else if (!a.Range(1, 1, int.Parse(txtQuantity.Text.ToString())))
            {
                message += "Quantity is more than zero\n";
            }
            if (message != null)
            {
                MessageBox.Show(message);
            }
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = null;
            float moneyBill = 50000;
            if (!a.Required(txtReceived))
            {
                message += "Receive is a required field";
            }
            else if(!a.RangeMoney(moneyBill,float.Parse(txtReceived.Text.ToString())))
            {
                message += "Receive is more than billMoney";
            }
            if (message != null)
            {
                MessageBox.Show(message);
            }
            else MessageBox.Show("Success");
        }

        private void productToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C08_Product product = new C08_Product();
            product.ShowDialog();
            this.Close();
        }

        private void promotionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C07_Promotion promote = new C07_Promotion();
            promote.ShowDialog();
            this.Close();
        }

        private void priceHistoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C06_PriceHistory pricehis = new C06_PriceHistory();
            pricehis.ShowDialog();
            this.Close();
        }

        private void headImportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C04_HeadImport headImport = new C04_HeadImport();
            headImport.ShowDialog();
            this.Close();
        }

        private void branchImportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C05_BranchImport branchImport = new C05_BranchImport();
            branchImport.ShowDialog();
            this.Close();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statisticToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C02_Statistic statistic = new C02_Statistic();
            statistic.ShowDialog();
            this.Close();
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
