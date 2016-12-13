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
namespace Cmart
{
    public partial class C01_Login : Form
    {
        validation a = new validation();
        public C01_Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string message = null;
            string UserName = "taikhoan";
            string Password = "12345";
            if (!a.Required(txtName))
            {
                message += "Name is a required field\n";
            }
            else
            {
                if (!a.Compare(txtName.Text.ToString(), UserName))
                {
                    message += "UserName is not exist\n";
                }
            }
            if (!a.Required(txtSupplier))
            {
                message += "Password is a required field\n";
            }
            else
            {
                if (!a.Compare(txtSupplier.Text.ToString(), Password))
                {
                    message += "Password is wrong\n ";
                }
            }
            if (a.Compare(txtName.Text.ToString(), UserName) && a.Compare(txtSupplier.Text.ToString(), Password))
            {
                this.Hide();
                C08_Product product = new C08_Product();
                product.ShowDialog();
                this.Close();
            }
            if (message != null)
            {
                MessageBox.Show(message);
            }
        }
    }
}
