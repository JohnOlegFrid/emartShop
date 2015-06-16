using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class Receipt
    {
        private string _ID;
        private string _product;
        private int _amount;
        private double _price;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Receipt()
        {

        }

        public Receipt(string id, string product, int amount, double price)
        {
            _ID = id;
            _product = product;
            _amount = amount;
            _price = price;
        }

        public override string ToString()
        {
            StringBuilder receipt = new StringBuilder("");
            return receipt.ToString();
        }
    }
}
