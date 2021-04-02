using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace homework4.Classes
{
    enum Units
    {
        Liters,
        Pieces,
        SquareMeters,
        CubicMeters
    }
    public class Product:IComparable
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
        public   int CompareTo(object obj)
        {
            if(obj is Product)
            {
                Product p = (Product)obj;
                return SKU.CompareTo(p.SKU);
            }
            else
            {
                throw new ArgumentException("Объект не является объектом класса Product");
            }
        }


        public override bool Equals(object other)
        {
            if(other is Product)
            {
                Product p = (Product)other;
                return this.SKU == p.SKU; 
            }
            else
            {
                throw new ArgumentException("Объект не является объектом класса Product");
            }
        }

        public override int GetHashCode()
        {
            return SKU.GetHashCode();
        }

     
    }
}
