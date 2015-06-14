using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    //database for Product, recives information from bl and updates/returns information from the database
    [Serializable]
    public class Product_Data
    {
        public List<Backend.Product> DB;
        public EmartDataContext emartDataContext;

        public Product_Data()
        {
            DB = new List<Backend.Product>();
            emartDataContext = new EmartDataContext();
        }

        public Product_Data(List<Backend.Product> PDB)
        {
            DB = PDB;
            emartDataContext = new EmartDataContext();
        }

        public void Add(Backend.Product p)
        {
            DB.Add(p);
            DAL.Product temp= Change.ProductBackendToDal(p);
            emartDataContext.Products.InsertOnSubmit(temp);
            emartDataContext.SubmitChanges();
          
        }

        public string getAllProducts()
        {
            StringBuilder allProducts = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "there are no products";
            }
            foreach (Backend.Product p in DB)
            {
                allProducts.Append(p.ToString());
                allProducts.Append("\r\n");
            }
            return allProducts.ToString();
        }
        public List<Backend.Product> getAllProductsList()
        {
            List<Backend.Product> list = new List<Backend.Product>();
            foreach (Backend.Product p in DB)
            {
                list.Add(p);
            }
            return list;
        }

        public void Remove(string id)
        {
            foreach (Backend.Product p in DB)
            {
                if (p.inventoryID == id)
                {
                    DB.Remove(p);
                    DAL.Product temp = Change.ProductBackendToDal(p);
                    emartDataContext.Products.DeleteOnSubmit(temp);
                    emartDataContext.SubmitChanges();
                    return;          
                }
                
            }
        }

        public bool Contains(string id)
        {
            foreach (Backend.Product p in DB)
            {
                if (p.inventoryID == id) return true;
            }
            return false;
        }

        public string Restock(string inventoryId, string addition)
        {
            var stock =
                from i in DB
                where i.inventoryID == inventoryId
                select i;
            foreach (Backend.Product p in stock)
            {
                p.stockCount += int.Parse(addition);
                if (p.stockCount > 0)
                {
                    p.inStock = true;
                }
            }
            if (stock.Count() == 0)
            {
                return "no product by this inventory id";
            }
            
            return "stock was added";
        }

        public Backend.Product getProductsInStockByName(string name)
        {
            StringBuilder product = new StringBuilder("");
            var pByName =
                from i in DB
                where i.name == name
                select i;
            foreach (Backend.Product p in pByName)
            {
                return p;
            }
            return null;
        }

        public string getProductsInStockByID(string id)
        {
            StringBuilder product = new StringBuilder("");
            var pByID =
                from i in DB
                where i.inventoryID == id
                select i;
            foreach (Backend.Product p in pByID)
            {
                product.Append(p.ToString());
                product.Append("\r\n");
            }
            if (product.ToString() == "")
            {
                product.Append("no product by this ID");
            }
            return product.ToString();
        }


        public string getProductsInStockByDepartment(string name)
        {
            StringBuilder product = new StringBuilder("");
            var pByDepartment =
                from i in DB
                where i.departmentID == name
                select i;
            foreach (Backend.Product p in pByDepartment)
            {
                product.Append(p.ToString());
                product.Append("\r\n");
            }
            if (product.ToString() == "")
            {
                product.Append("no product by this department ID");
            }
            return product.ToString();
        }

        

        public string getProductsInStockByPriceRange(string min, string max)
        {
            StringBuilder product = new StringBuilder("");
            var pByPriceRange =
                from i in DB
                where (i.price < double.Parse(max)) && (i.price > double.Parse(min))
                select i;
            foreach (Backend.Product p in pByPriceRange)
            {
                product.Append(p.ToString());
                product.Append("\r\n");
            }
            if (product.ToString() == "")
            {
                product.Append("no product in this price range");
            }
            return product.ToString();
        }

        public bool updateProduct(string id, string name, Backend.Product.Type type, string departmentId, double price)
        {
            if (!Contains(id))
            {
                return false;
            }
            var product =
               from p in DB
               where (p.inventoryID == id)
               select p;
            foreach (Backend.Product p in product)
            {
                p.name = name;
                p.type = type;
                p.departmentID = departmentId;
                p.price = price;
            }
            
            return true;
        }

        public void RemoveDepartment(string id)
        {
            foreach (Backend.Product p in DB)
            {
                if (p.departmentID == id)
                {
                    p.departmentID = "0";
                }

            }
        }

        public string getPriceByProductID(string id)
        {
            StringBuilder product = new StringBuilder("");
            var pById =
                from i in DB
                where i.inventoryID == id
                select i;
            foreach (Backend.Product p in pById)
            {
                product.Append(p.price);
                product.Append("\r\n");
            }
            if (product.ToString() == "")
            {
                product.Append("no product by this id");
            }
            return product.ToString();
        }

        public List<Backend.Product> getProductsListByType(Backend.Product.Type type)
        {
            List < Backend.Product > list= new List<Backend.Product>();
            foreach(Backend.Product p in DB)
            {
                if(p.type==type)
                {
                    list.Add(p);                
                }
            }

            return list;
        }
    }
}
