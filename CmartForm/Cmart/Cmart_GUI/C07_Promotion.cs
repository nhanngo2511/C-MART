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
    public partial class C07_Promotion : Form
    {
        validation a = new validation();
        public C07_Promotion(string name)
        {
            InitializeComponent();
            label1.Text = name;
            importManagementToolStripMenuItem.Visible = false;
            billToolStripMenuItem.Visible = false;
        }
  

        
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C08_Product product = new C08_Product(label1.Text);
            product.ShowDialog();
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = null;
            string idData = "C001" ;
            if (!a.Required(txtID))
            {
                message += "ID is a required field\n";
            }
            else if (!a.Compare(txtID.Text.ToString(),idData))
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
            if (!a.compareDate(DateTime.Now,dateTimeStart.Value))
            {
                message += "startDate is equal or more than now\n";
            }
            else if (!a.compareDate(dateTimeStart.Value,dateTimeEnd.Value))
            {
                message += "startDate is less than endDate\n";
            }
            if (!a.Required(txtContent))
            {
                message += "Content is a required field\n";
            }
            if (message == null)
            {
                MessageBox.Show("Success");
            }
            else MessageBox.Show(message);
        }

        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void priceHistoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            C06_PriceHistory pricehis = new C06_PriceHistory(label1.Text);
            pricehis.ShowDialog();
            this.Close();
        }

        private void headImportToolStripMenuItem_Click_1(object sender, EventArgs e)
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
            this.Hide();
            C02_Statistic statistic = new C02_Statistic(label1.Text);
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
