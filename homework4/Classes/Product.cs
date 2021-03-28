using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    enum Units
    {
        Liters,
        Pieces,
        SquareMeters,
        CubicMeters
    }
    abstract class Product
    {
        // Properties
        public string Name;
        public uint SKU;
        public string Description;
        public decimal Price;
        public double Number;

        // Methods
        public decimal CountTotalPrice() { return Convert.ToDecimal(Number) * Price; }

        public double GetTotalQuantity() { return Number; }

        public Product(string name, uint sku, decimal price, string desc, double number)
        {
            if (string.IsNullOrEmpty(name)) { throw new Exception("Имя пустое или неопределено!"); }
            else { Name = name; }
            if (price < 0) { throw new Exception("Значение цены не может быть отрицательным числом!"); }
            else { Price = price; }
            SKU = sku;
            Description = desc;
            if (number < 0) { throw new Exception("Значение количества не может быть отрицательным числом!"); }
            else { Number = number; }
        }

       
    }
}
