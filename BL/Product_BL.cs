using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;

namespace BL
{

    [Serializable]
    public class Product_BL
    {
        Product_Data itsDAL;

        public Product_BL(Product_Data dl)
        {
            itsDAL = dl;
        }

        //adds new product to database
        public string Add(string name, string type, string departmentID, string stockCount, string price)
        {
            string id = generateID();
            bool inStock = false;
            if (int.Parse(stockCount) > 0)
            {
                inStock = true;
            }
            return itsDAL.Add(name, (Product.Type)Enum.Parse(typeof(Product.Type), type), id, departmentID, inStock, int.Parse(stockCount), double.Parse(price));
        }

        //id generator
        private static string generateID()
        {
            DateTime date = DateTime.Now;
            string uniqueID = String.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            return uniqueID;
        }

        public bool exist(string productId)
        {
            return itsDAL.Contains(productId);
        }

        //removes product from database
        public void Remove(string productId)
        {
            if (exist(productId))
            {
                itsDAL.Remove(productId);
            }
        }

        /*
         * query functions for poduct database
         */
        public string getAllProducts()
        {
            return itsDAL.getAllProducts();
        }
        public List<Product> getAllProductsList()
        {
            return itsDAL.getAllProductsList();
        }

        public string Restock(string inventoryId, string addition)
        {
            return itsDAL.Restock(inventoryId, addition);
        }

        public string getProductsInStockByName(string name)
        {
            return itsDAL.getProductsInStockByName(name);
        }

        public string getProductsInStockByID(string id)
        {
            return itsDAL.getProductsInStockByID(id);
        }

        public string getProductsInStockByDepartment(string name)
        {
            return itsDAL.getProductsInStockByDepartment(name);
        }

        public string getProductsInStockByPriceRange(string min, string max)
        {
            return itsDAL.getProductsInStockByPriceRange(min, max);
        }

        public bool updateProduct(string id, string name, string type, string departmentId, string price)
        {
            return itsDAL.updateProduct(id, name, (Product.Type)Enum.Parse(typeof(Product.Type), type), departmentId, double.Parse(price));
        }

        public void RemoveDepartment(string id)
        {
            itsDAL.RemoveDepartment(id);
        }

        public string getPriceByProductID(string id)
        {
            return itsDAL.getPriceByProductID(id);
        }
    }
}
