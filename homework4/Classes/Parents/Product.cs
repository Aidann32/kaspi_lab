using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
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
        protected static Logger log = LogManager.GetCurrentClassLogger();

        // Methods
        public decimal CountTotalPrice() { return Convert.ToDecimal(Number) * Price; }

        public double GetTotalQuantity() { return Number; }

        public Product(string name, uint sku, decimal price, string desc, double number)
        {
            if (string.IsNullOrEmpty(name)) 
            {
                Exception ex = new Exception("Имя пустое или неопределено!");
                log.Error(ex, ex.Message);
                throw ex;
            }
            else { Name = name; }
            if (price < 0) 
            { 
                Exception ex= new Exception("Значение цены не может быть отрицательным числом!");
                log.Error(ex, ex.Message);
                throw ex;
                
            }
            else { Price = price; }
            SKU = sku;
            Description = desc;
            if (number < 0) 
            { 
                Exception ex= new Exception("Значение количества не может быть отрицательным числом!");
                log.Error(ex,ex.Message);
                throw ex;
            }
            else { Number = number; }
            log.Debug("Product children created");
        }
        public int CompareTo(object obj)
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
