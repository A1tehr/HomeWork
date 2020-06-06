using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp19
{
    class Cheque
    {
        private List<Product> products;
        private DateTime timeSale;
        private int buyerID;
        public Cheque(List<Product> products, DateTime timeSale, int buyerID)
        {
            this.products = products;
            this.timeSale = timeSale;
            this.buyerID = buyerID;
        }
        public double getPrice()
        {
            double price = 0;
            foreach(Product product in products)
            {
                price += product.Price;
            }
            return price;
        }
    }
}
