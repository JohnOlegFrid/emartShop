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
        private Dictionary<string, double> _products;
        private Dictionary<string, int> _amount;

        public Dictionary<string, double> product
        {
            get { return _products; }
            set { _products = value; }
        }

        public Dictionary<string, int> amount
        {
            get { return _amount; }
            set { _amount = value; }
        } 

        public Receipt()
        {

        }

        public Receipt(Dictionary<string, double> product, Dictionary<string,int> amount)
        {
            _products = product;
            _amount = amount;
        }

        public override string ToString()
        {
            StringBuilder receipt = new StringBuilder("");
            foreach (KeyValuePair<string, double> product in _products)
            {
                receipt.Append(product.Key);
                receipt.Append(" ");
                receipt.Append(product.Value);
                receipt.Append("\r\n");
            }
            return receipt.ToString();
        }
    }
}
