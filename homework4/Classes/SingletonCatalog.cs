using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace homework4.Classes
{
    public class SingletonCatalog
    {
        private static SingletonCatalog instance=null;
        public static SingletonCatalog Instance
        {
            get
            {
                if (instance == null) { instance = new SingletonCatalog(); }
                return instance;
            }
        }

        public static Dictionary<uint, Product> Catalog;

        private SingletonCatalog()
        {
            Catalog = new Dictionary<uint, Product>();
        }

        public void AddToCatalog(Product p)
        {
            if (!Catalog.ContainsKey(p.SKU)) { Catalog.Add(p.SKU, p); }
        }

        public Product GetProductBySKU(uint sku)
        {
            if (Catalog.ContainsKey(sku)) { return Catalog[sku]; }
            else { return null; }
        }
        
    }
}
