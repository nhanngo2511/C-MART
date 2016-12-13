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
    public partial class C08_Product : Form
    {
        validation a = new validation();
        public C08_Product()
        {
            InitializeComponent();
        }
        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C07_Promotion promote = new C07_Promotion();
            promote.ShowDialog();
            this.Close();
        }

        private void priceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C06_PriceHistory pricehis = new C06_PriceHistory();
            pricehis.ShowDialog();
            this.Close();
        }

        private void headImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C04_HeadImport headImport = new C04_HeadImport();
            headImport.ShowDialog();
            this.Close();
        }

        private void branchImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C05_BranchImport branchImport = new C05_BranchImport();
            branchImport.ShowDialog();
            this.Close();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C03_Bill bill = new C03_Bill();
            bill.ShowDialog();
            this.Close();
        }
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C02_Statistic statistic = new C02_Statistic();
            statistic.ShowDialog();
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = null;
            if (!a.Required(txtName))
            {
                message += "Name is a required field\n";
            }
            else if (!a.MinLength(3, txtName.Text.ToString()))
            {
                message += "Name contains more than three charaters\n";
            }
            else if (!a.MaxLength(30, txtName.Text.ToString()))
            {
                message += "Name contains less than thirty charaters\n";
            }
            else if (a.checkSpecialCharater(txtName.Text.ToString()))
            {
                message += "Name does not have special charaters\n";
            }
            if (!a.Required(txtSupplier))
            {
                message += "Supplier is a required field\n";
            }
            else if (!a.MinLength(3, txtSupplier.Text.ToString()))
            {
                message += "Supplier contains more than three charaters\n";
            }
            else if (!a.MaxLength(30, txtSupplier.Text.ToString()))
            {
                message += "Supplier contains less than thirty charaters\n";
            }
            else if (a.checkSpecialCharater(txtSupplier.Text.ToString()))
            {
                message += "Supplier does not have special charaters\n";
            }
            if (message == null)
            {
                MessageBox.Show("Success");
            }
            else MessageBox.Show(message);
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
