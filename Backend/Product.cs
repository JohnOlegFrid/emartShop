using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    //object represantation of Product
    [Serializable]
    public class Product
    {
        public enum Type
        {
            cosmetics,
            electronics,
            toys,
            cloths,
            food
        };

        private string _name;
        private Type _type;
        private string _inventoryID;
        private string _departmentID;
        private bool _inStock;
        private int _stockCount;
        private double _price;
        private bool _isBestSeller;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Type type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string inventoryID
        {
            get { return _inventoryID; }
            set { _inventoryID = value; }
        }
        public string departmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }
        public bool inStock
        {
            get { return _inStock; }
            set { _inStock = value; }
        }

        public int stockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        public bool isBestSeller
        {
            get { return _isBestSeller; }
            set { _isBestSeller = value; }
        }

        public Product()
        {

        }

        public Product(string name, Type type, string inventoryID, string departmentID, bool inStock, int stockCount, double price)
        {
            _name = name;
            _type = type;
            _inventoryID = inventoryID;
            _departmentID = departmentID;
            _inStock = inStock;
            _stockCount = stockCount;
            _price = price;
            _isBestSeller = false;
        }

        public override string ToString()
        {
            StringBuilder product = new StringBuilder("");
            product.Append(name);
            product.Append(" ");
            product.Append(price);
            product.Append("$ ");
            if(_isBestSeller)
            {
                product.Append(" BEST SELLER!!!!!");
            }
            return product.ToString();
        }
    }
}
