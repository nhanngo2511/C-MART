using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cmart.BUS;
using Cmart.Cmart_GUI;
namespace Cmart
{
    public partial class C01_Login : Form
    {
        validation a = new validation();
        BUS.C01_Login login;
        public C01_Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string message = null;
            string UserName = txtName.Text;
            string Password = txtSupplier.Text;
            if (!a.Required(txtName))
            {
                message += "Name is a required field\n";
            }
            if (!a.Required(txtSupplier))
            {
                message += "Password is a required field\n";
            }
            else{
                login = new BUS.C01_Login(UserName, Password);
                var acc = login.checkAccount();
                if (acc)
                {
                    this.Hide();
                    Cmart_GUI.C08_Product product = new Cmart_GUI.C08_Product();
                    product.ShowDialog();
                    this.Close();
                }
                else
                {
                    message += "User or Password is wrong\n ";
                }
            }
            if (message != null)
            {
                MessageBox.Show(message);
            }

        }
    }
}
