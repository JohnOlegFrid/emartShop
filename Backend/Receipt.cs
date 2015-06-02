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
        private Dictionary<string, double[]> _products;

        public Dictionary<string, double[]> product
        {
            get { return _products; }
            set { _products = value; }
        }

        public Receipt()
        {

        }

        public Receipt(Dictionary<string, double[]> product)
        {
            _products = product;
        }

        public override string ToString()
        {
            StringBuilder receipt = new StringBuilder("");
            foreach (KeyValuePair<string, double[]> product in _products)
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
