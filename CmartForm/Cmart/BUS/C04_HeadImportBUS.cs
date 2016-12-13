using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmart.BUS
{
    class C04_HeadImportBUS
    {
        CMART1Entities db = new CMART1Entities();
        HeadImport head = new HeadImport();
        RequestImport request = new RequestImport();
        public List<HeadImport> loadHead()
        {
            return db.HeadImports.ToList();
        }
        public List<HeadImport> searchHead(string sTmp)
        {
            return db.HeadImports.Where(st => st.IDHead.Contains(sTmp)).ToList();
        }
        public bool addHead(string idRequest)
        {
            request = db.RequestImports.Single(st => st.IDRequest.Equals(idRequest));
            try
            {
                head.IDHead = DateTime.Now.ToString();
                /*head.TENSP = ten;
                head.HINHANH = hinhanh;
                head.MALOAI = maloai;
                head.MANCC = mancc;
                db.SANPHAMs.AddObject(SP);
                lsp.SOLUONGSP = lsp.SOLUONGSP + 1;
                db.SaveChanges();*/
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
