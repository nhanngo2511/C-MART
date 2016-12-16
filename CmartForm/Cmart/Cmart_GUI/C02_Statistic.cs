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
    public partial class C02_Statistic : Form
    {
        public C02_Statistic(string name)
        {
            InitializeComponent();
            lblName.Text = name;
            importManagementToolStripMenuItem.Visible = false;
            billToolStripMenuItem.Visible = false;
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C08_Product product = new C08_Product(lblName.Text);
            product.ShowDialog();
            this.Close();
        }

        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C07_Promotion promote = new C07_Promotion(lblName.Text);
            promote.ShowDialog();
            this.Close();
        }

        private void priceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C06_PriceHistory pricehis = new C06_PriceHistory(lblName.Text);
            pricehis.ShowDialog();
            this.Close();
        }
    }
}
