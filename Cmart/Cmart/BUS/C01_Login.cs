using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmart.BUS
{
    class C01_Login
    {
        public bool RequireLogin(TextBox username, TextBox pass)
        {
            string a = username.Text.ToString();
            string b = pass.Text.ToString();
            if ((string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a)) 
                && (string.IsNullOrEmpty(b) || string.IsNullOrWhiteSpace(b)))
                return false;
            else
                return true;
        }
        public bool Login()
        {
            


            return true;
        }
    }
}
