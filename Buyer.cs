using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp19
{
    class Buyer
    {
        public event Error Error;
        public static int BUYER_ID = 1;
        private double balance;
        private Cheque cheque;
        private List<Product> basket;
        private int id;
        public Buyer(double balance)
        {
            this.balance = balance;
            id = BUYER_ID++;
        }
        public void withdraw(double amount)
        {
            balance -= amount;
        }
        public int getID()
        {
            return id;
        }
        public void addProductToBasket(Shop shop, Product product)
        {
            if (shop.hasProduct(product))
            {
                basket.Add(product);

            }
            else
            {
                Error?.Invoke("Продукта нету на складе.");
            }
        }
        public void removeProductFromBasket(Product product)
        {
            if (basket.Contains(product))
            {
                basket.Remove(product);
            }
            else
            {
                Error?.Invoke("Продукта и не было в корзине.");
            }
        }
        public List<Product> getBasket()
        {
            return basket;
        }
        public double getBalance()
        {
            return balance;
        }
        public void giveCheque(Cheque cheque)
        {
            this.cheque = cheque;
        }
        public Cheque getCheque(Cheque cheque)
        {
            if (cheque != null)
            {
                Error?.Invoke("У этого покупателя нету чека");
            }
            return cheque;
        }
        public bool returnBasket(Shop shop)
        {
            if (shop.getCheques().Contains(cheque))
            {
                balance += cheque.getPrice();
                foreach(Product product in basket)
                {
                    shop.addProduct(product);
                }
                return true;
            }
            else
            {
                Error?.Invoke("Такого чека не существует");
                return false;
            }
        }
    }
}
