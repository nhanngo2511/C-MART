using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmart.BUS
{
    class C08_ProductBUS
    {
        CMART1Entities db;
        public List<Product> loadListProduct()
        {
            db = new CMART1Entities();
            return db.Products.ToList();
        }
        public List<Product> searchProductList(string mp)
        {
            db = new CMART1Entities();
            return db.Products.Where(st=>st.Name.Contains(mp)|| st.Image.Contains(mp) || st.IDSupplier.Contains(mp) || st.IDType.Contains(mp) ).ToList();
        }
        public List<ProductType> loadProducTypetList()
        {
            db = new CMART1Entities();
            return db.ProductTypes.ToList();
        }
        public List<Supplier> loadSuppliertList()
        {
            db = new CMART1Entities();
            return db.Suppliers.ToList();
        }
        public bool checkExistedProduct(string stm)
        {
            db = new CMART1Entities();
            Product product = db.Products.FirstOrDefault(st=>st.Name.Equals(stm)||st.IDProduct.Equals(stm));
            if (product==null)
            {
                return true;
            }
            return false;
        }
        public bool addProduct(string Name, string image,string IDSupplier,string IDType)
        {
            db = new CMART1Entities();

            Product product = new Product();
            ProductType type = db.ProductTypes.Single(st=>st.IDTye.Equals(IDType));
            try
            {

                        Random d = new Random();
                        product.IDProduct = d.Next(100000000,999999999).ToString()+d.Next(1000,9999).ToString() ;
                        product.Name = Name;
                        product.Image = image;
                        product.IDSupplier = IDSupplier;
                        product.IDType = IDType;
                        type.Quantity = type.Quantity+ 1;
                        db.Products.Add(product);
                        db.SaveChanges();
                return true;               
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool editProduct(string id,string Name, string image, string IDSupplier, string IDType)
        {
            db = new CMART1Entities();
            Product product = db.Products.Single(st=>st.IDProduct.Equals(id));
            try
            {
                if (IDType!=product.IDType)
                {
                    ProductType type1 = db.ProductTypes.Single(st =>st.IDTye.Equals(IDType));
                    ProductType type2 = db.ProductTypes.Single(st => st.IDTye.Equals(product.IDType));
                    product.Image = image;
                    product.Name = Name;
                    product.IDSupplier = IDSupplier;
                    product.IDType = IDType;
                    type1.Quantity = type1.Quantity + 1;
                    type2.Quantity = type2.Quantity - 1;
                    db.SaveChanges();
                }

                else {
                    product.Name = Name;
                    product.Image = image;
                    product.IDSupplier = IDSupplier;
                    product.IDType = IDType;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteProduct(string id)
        {
            db = new CMART1Entities();
            Product product = db.Products.Single(st => st.IDProduct.Contains(id));
            ProductType type = db.ProductTypes.Single(st => st.IDTye.Equals(product.IDType));
            db.Products.Remove(product);
            type.Quantity = type.Quantity- 1;
            db.SaveChanges();
            return true;
        }
    }
}
