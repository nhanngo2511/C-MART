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
    public partial class C05_BranchImport : Form
    {
        validation a = new validation();
        public C05_BranchImport()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = null;
            string idExisted = "C001";
            if (!a.Required(txtIDHead))
            {
                message += "IDHead is a required field";
            }
            else if (a.Compare(txtIDHead.Text.ToString(),idExisted))
            {
                message += "IDHead is existed";
            }
            if (message == null)
            {
                MessageBox.Show("Success");
            }
            else MessageBox.Show(message);
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

        private void branchImportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void billToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C03_Bill bill = new C03_Bill();
            bill.ShowDialog();
            this.Close();
        }

        private void statisticToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C02_Statistic statistic = new C02_Statistic();
            statistic.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            C01_Login a = new C01_Login();
            a.ShowDialog();
            this.Close();
        }
    }
}
