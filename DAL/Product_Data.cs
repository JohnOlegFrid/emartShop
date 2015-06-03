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
        public List<Product> DB;
        public string path = @"product.bin";

        public Product_Data()
        {
            DB = new List<Product>();
        }

        public Product_Data(List<Product> PDB)
        {
            DB = PDB;
            Encryption.encryption(DB, path);
        }

        public string Add(string name, Product.Type type, string id, string departmentID, bool inStock, int stockCount, double price)
        {
            DB.Add(new Product(name, type, id, departmentID, inStock, stockCount, price));
            Encryption.encryption(DB, path);

            return id;
        }

        public string getAllProducts()
        {
            StringBuilder allProducts = new StringBuilder("");
            if (DB.Count() == 0)
            {
                return "there are no products";
            }
            foreach (Product p in DB)
            {
                allProducts.Append(p.ToString());
                allProducts.Append("\r\n");
            }
            return allProducts.ToString();
        }
        public List<Product> getAllProductsList()
        {
            return DB;
        }

        public void Remove(string id)
        {
            foreach (Product p in DB)
            {
                if (p.inventoryID == id)
                {
                    DB.Remove(p);
                    Encryption.encryption(DB, path);
                    return;
                }
            }
        }

        public bool Contains(string id)
        {
            foreach (Product p in DB)
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
            foreach (Product p in stock)
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
            Encryption.encryption(DB, path);
            return "stock was added";
        }

        public Product getProductsInStockByName(string name)
        {
            StringBuilder product = new StringBuilder("");
            var pByName =
                from i in DB
                where i.name == name
                select i;
            foreach (Product p in pByName)
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
            foreach (Product p in pByID)
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
            foreach (Product p in pByDepartment)
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

        public string getProductsInStockByType(string type)
        {
            StringBuilder product = new StringBuilder("");
            var pByType =
                from i in DB
                where (i.type == (Product.Type)Enum.Parse(typeof(Product.Type), type))
                select i;
            foreach (Product p in pByType)
            {
                product.Append(p.ToString());
                product.Append("\r\n");
            }
            if (product.ToString() == "")
            {
                product.Append("no product of this type");
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
            foreach (Product p in pByPriceRange)
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

        public bool updateProduct(string id, string name, Product.Type type, string departmentId, double price)
        {
            if (!Contains(id))
            {
                return false;
            }
            var product =
               from p in DB
               where (p.inventoryID == id)
               select p;
            foreach (Product p in product)
            {
                p.name = name;
                p.type = type;
                p.departmentID = departmentId;
                p.price = price;
            }
            Encryption.encryption(DB, path);
            return true;
        }

        public void RemoveDepartment(string id)
        {
            foreach (Product p in DB)
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
            foreach (Product p in pById)
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

        public List<Product> getProductsListByType(Product.Type type)
        {
            List < Product > list= new List<Product>();
            foreach(Product p in DB)
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
