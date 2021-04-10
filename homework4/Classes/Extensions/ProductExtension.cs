using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    public static class ProductExtension
    {
        public static string GetInfo(this Product p)
        {
            return $"SKU:{p.SKU}\nName:{p.Name}";
        }

        
    }
}
