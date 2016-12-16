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
    public partial class C08_Product : Form
    {
        validation a = new validation();
        C08_ProductBUS bus = new C08_ProductBUS();
        int i = 0;
        string IDproduct;
        string image;
        string Name;
        string IDSupplier;
        string IDType;

        public C08_Product(string name)
        {
            InitializeComponent();
            loadList();
            lblFullName.Text = name;
            importManagementToolStripMenuItem.Visible = false;
            billToolStripMenuItem.Visible = false;
            cbbSupplier.DataSource = bus.loadSuppliertList();
            this.cbbSupplier.ValueMember = "IDSupplier";
            this.cbbSupplier.DisplayMember = "Name";
            cbbTypes.DataSource = bus.loadProducTypetList();
            this.cbbTypes.ValueMember = "IDTye";
            this.cbbTypes.DisplayMember = "Name";
            this.tabList.TabIndex = 0;
            this.tabPage2.TabIndex = 1;


        }
        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C07_Promotion promote = new C07_Promotion(lblFullName.Text);
            promote.ShowDialog();
            this.Close();
        }

        private void priceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C06_PriceHistory pricehis = new C06_PriceHistory(lblFullName.Text);
            pricehis.ShowDialog();
            this.Close();
        }

        private void headImportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void branchImportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            C02_Statistic statistic = new C02_Statistic(lblFullName.Text);
            statistic.ShowDialog();
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                string message = null;
                if (!a.Required(txtName))
                {
                    message += "Name is a required field\n";
                }
                else
                {
                    if (bus.checkExistedProduct(txtName.Text))
                    {
                        if (bus.addProduct(txtName.Text, image, cbbSupplier.SelectedValue.ToString(), cbbTypes.SelectedValue.ToString()))
                        {
                            message += "Add New Product successfully\n";
                            loadList();
                            tabControl1.SelectedIndex = 0;
                        }
                        else message += "Add New Product fail";
                    }
                    else message += "Add New Product fail";
                }
                if (message == null)
                {
                    MessageBox.Show("Success");
                }
                else MessageBox.Show(message);
            }
            if (i==1)
            {
                string message = null;
                if (!a.Required(txtName))
                {
                    message += "Name is a required field\n";
                }
                else
                {
                    if (bus.checkExistedProduct(txtName.Text))
                    {
                        string id = (string)list.SelectedRows[0].Cells[0].Value;
                        if (bus.editProduct(id, txtName.Text, image, cbbSupplier.SelectedValue.ToString(), cbbTypes.SelectedValue.ToString()))
                        {

                            message += "Update Product successfully\n";
                            loadList();
                            this.tabPage2.Text = "Add";
                            tabControl1.SelectedIndex = 0;
                        }
                        else message += "Product is existed";
                    }
                    else message += "Update Product fail";
                }
                if (message == null)
                {
                    i = 0;
                    MessageBox.Show("Success");
                }
                else MessageBox.Show(message);
            }
        }
        public void loadList()
        {
            list.DataSource = bus.loadListProduct();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            C01_Login a = new C01_Login();
            a.ShowDialog();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            list.DataSource = bus.searchProductList(txtSearch.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                img.Image = new Bitmap(open.FileName);
                // image file path
                image = open.FileName;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string id = (string)list.SelectedRows[0].Cells[0].Value;
            if (bus.deleteProduct(id))
            {
                MessageBox.Show("Delete Product successfully! ");
                loadList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            image = null;
            txtName.Text = null;
            img.Image = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            i = 1;
            CMART1Entities db = new CMART1Entities();
            string id = (string)list.SelectedRows[0].Cells[0].Value;
            Product product = db.Products.Single(st => st.IDProduct.Equals(id));
            txtName.Text = product.Name;
            image = product.Image;
            img.ImageLocation = image;
            cbbTypes.Text = product.ProductType.Name;
            cbbSupplier.Text = product.Supplier.Name;
            this.tabPage2.Text = "Edit";
            tabControl1.SelectedIndex = 1;

        }
    }
}
