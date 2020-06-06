using System;
using System.Collections.Generic;

namespace ConsoleApp19
{
    class Shop
    {
        public event Error Error;
        private List<Product> products;
        private List<Cheque> chequesBase;
        private double cashbox;
        private double sale;
        private bool isSale;

        public Shop()
        {
            chequesBase = new List<Cheque>();
            products = new List<Product>();
            cashbox = 0;
            isSale = false;
            sale = 0;
        }
        public List<Cheque> getCheques()
        {
            return chequesBase;
        }
        public bool byeProducts(Buyer buyer)
        {
            double allPrice = 0;
            foreach (Product product in buyer.getBasket())
            {
                allPrice += product.Price;
            }
            if(buyer.getBalance() >= allPrice)
            {
                buyer.withdraw(allPrice);
                cashbox += allPrice;
                removeBasketFromBase(buyer.getBasket());
                Cheque cheque = new Cheque(buyer.getBasket(), new DateTime(), buyer.getID());
                chequesBase.Add(cheque);
                buyer.giveCheque(cheque);
                return true;
            }
            else
            {
                Error?.Invoke("Недостаточно средств");
                return false;
            }
        }
        public List<Product> getAviableProducts()
        {
            return products;
        }
        private void removeBasketFromBase(List<Product> prodcts)
        {
            foreach(Product product in prodcts)
            {
                products.Remove(product);
            }
        }
        public void addProduct(Product product)
        {
            products.Add(product);
        }
        public void removeProduct(Product product)
        {
            if (hasProduct(product))
            {
                products.Remove(product);
            }
        }
        public bool hasProduct(Product product)
        {
            return products.Contains(product);
        }
        public void setSale(double sale)
        {
            this.sale = sale;
            isSale = true;
        }
        static void Main(string[] args)
        {
        }
    }
}
