using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace Cmart.BUS
{
    class C01_Login
    {
        CMART1Entities db;
        Account account;
        string userName;
        string passWord;
        private string[] position = { "President", "Inspector", "Staff", "Branch", "Secretary" };
        public C01_Login(string userName,string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        public bool checkAccount()
        {
            //db = new CMART1Entities();
            //account = db.Accounts.Single(st=>st.Username==userName&&st.Password==passWord);
            SqlConnection con = new SqlConnection("Data Source=cmu.vanlanguni.edu.vn;Initial Catalog=CMART1;User ID=cmart1;Password=dridrachoc");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Auth FROM Account WHERE Username='" + userName + "' AND Password='" + passWord + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >0)
            {
                dt.ToString();
                return true;
            }
            else return false;
        }
    }
}
