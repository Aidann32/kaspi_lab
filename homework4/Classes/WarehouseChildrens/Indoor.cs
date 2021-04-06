using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    class Indoor : Warehouse
    {
        public override void AddProduct(Product p)
        {
            AllProducts.Add(p);
            AllProductsNumber[p.ToString()] += p.Number;
            SingletonCatalog.Instance.AddToCatalog(p);
            log.Debug("Product added to warehouse");
            OnProductAdded(p);
        }

        
        public Indoor(string name, Address address, double area, Employee main):base(name,address,area,main)
        {
            AllProductsNumber = new Dictionary<string, double>
          { { "Bulk", 0.0 }, {"Liquid",0.0},{"Piece",0.0},{"Overall",0.0} };
        }
    }
}
