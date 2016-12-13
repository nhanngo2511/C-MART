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
    public partial class C06_PriceHistory : Form
    {
        validation a = new validation();
        public C06_PriceHistory()
        {
            InitializeComponent();
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = null;
            string idData = "C001";
            if (!a.Required(txtID))
            {
                message += "ID is a required field\n";
            }
            else if (!a.Compare(txtID.Text.ToString(), idData))
            {
                message += "ID is not exist\n";
            }
            if (!a.Required(txtPrice))
            {
                message += "Price is a required field\n";
            }
            else if (!a.checkNumber(txtPrice.Text.ToString()))
            {
                message += "Price fills numbers\n";
            }
            else if (!a.RangeMoney(1000, float.Parse(txtPrice.Text.ToString())))
            {
                message += "Price begins 1000vnd\n";
            }
            if (!a.compareDate(dateTime.Value,DateTime.Now))
            {
                message += "Available Day is equal or less than now\n";
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
