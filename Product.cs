using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp19
{
    public delegate void Error(string msg);
    class Product
    {
        public event Error Error;
        public int Count { private set; get; }
        public string Name { private set; get; }
        public DateTime ShelfLife { private set; get; }
        public double Price { private set; get; }
        public string Provider { private set; get; }
        public Product(string name, double price, DateTime shelfLife, string provider)
        {
            if(price < 0)
            {
                Error("Нельзя установить отрицательную цену. Измените цену");
            }
            else
            {
                Name = name;
                Price = price;
                ShelfLife = shelfLife;
                Provider = provider;
            }
        }
        public void changePrice(double price)
        {
            if(price < 0)
            {
                Error("Нельзя установить отрицательную цену");
            }
            else
            {
                Price = price;
            }
        }
        public void setShelfTime(DateTime shelfLife)
        {
            ShelfLife = shelfLife;
        }
    }
}
