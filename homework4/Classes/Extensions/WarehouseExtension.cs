using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework4.Classes
{
    public static class WarehouseExtension
    {
        public static List<Product> GetIntersection(this Warehouse obj,Warehouse search)
        {
            List<Product> res = new List<Product>();
            res = obj.AllProducts.Intersect(search.AllProducts).ToList();
            return res;
        }
        public static void SaveProductsToFile(this Warehouse obj,string fileName)
        {
           string binPath = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
           string filePath = Directory.GetParent(binPath).ToString() + $@"\Files\{fileName}";
            string template;
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.WriteLine($"Name,SKU,Description,Price,Number");
                    foreach(var i in obj.AllProducts)
                    {
                        template = $"{i.Name},{i.SKU},{i.Description},{i.Price},{i.Number}";
                        sw.WriteLine(template);
                    }
                }
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
    }
}
