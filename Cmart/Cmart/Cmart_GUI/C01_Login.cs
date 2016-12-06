using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmart
{
    public partial class C01_Login : Form
    {
        C01_Login C01 = new C01_Login();
        public C01_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!C01.RequireLogin())
            {
                MessageBox.Show("Information is require");
            }
        }
    }
}
