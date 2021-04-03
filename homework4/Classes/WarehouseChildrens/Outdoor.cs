using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    [Serializable]
    class CannotStoreException:Exception
    {
        public CannotStoreException(string message):
            base(message)
        { }
    }
    class Outdoor : Warehouse
    {
        public event EventHandler<ProductEventArgs> IncorrectProductAdded;
        public override void AddProduct(Product p)
        {
            if(p is Bulk)
            {
                OnIncorrectProductAdded(p);
                throw new CannotStoreException("В открытые склады нельзя добавлять сыпучие товары!"); 
            }
            else 
            {
                AllProducts.Add(p);
                AllProductsNumber[p.ToString()] += p.Number;
                SingletonCatalog.Instance.AddToCatalog(p);
                OnProductAdded(p);
            }
        }
        public bool CanContain(Product p)
        {
            if(p is Bulk) { return false; }
            else { return true; }
        }

        public Outdoor(string name, Address address, double area, Employee main) :base(name,address,area,main)
        {
            AllProductsNumber = new Dictionary<string, double>
            { {"Liquid",0.0},{"Piece",0.0},{"Overall",0.0} };
        }
        protected virtual void OnIncorrectProductAdded(Product p) 
        {
            if (IncorrectProductAdded != null)
            {
                IncorrectProductAdded(this, new ProductEventArgs { product = p });
            }
        }
    }
}
