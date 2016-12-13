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
using Cmart.BUS;

namespace Cmart.Cmart_GUI
{
    public partial class C04_HeadImport : Form
    {
        C04_HeadImportBUS bus = new C04_HeadImportBUS();
        CMART1Entities db = new CMART1Entities();
        HeadImport head = new HeadImport();
        validation a = new validation();

        public C04_HeadImport()
        {
            InitializeComponent();
            LoadList();
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
        private void headImportToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            C01_Login a = new C01_Login();
            a.ShowDialog();
            this.Close();
        }
        /*-------------------------- PROGRAMMING -----------------------*/
        private void LoadList() {
            list.DataSource = bus.loadHead();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            list.DataSource = bus.searchHead(txtSearch.Text);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (list.SelectedRows.Count == 1)
            {
                var row = list.SelectedRows[0];
                var cell = row.Cells["IDHead"];
                String id = (String)cell.Value;
                head = db.HeadImports.Single(st => st.IDHead == id);
                db.HeadImports.Remove(head);
                db.SaveChanges();
                this.LoadList();
            }
            else
            {
                MessageBox.Show("You should select!");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
