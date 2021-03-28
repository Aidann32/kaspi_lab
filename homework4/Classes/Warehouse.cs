using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework4.Classes;
namespace homework4.Classes
{
    struct Address
    {
        public string Country;
        public string District;
        public string City;
        public string Street;
        public string BuildingNumber;

        public Address(string country,string district,
            string city,string street,string buildingNumber)
        {
            Country = country;
            District = district;
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;

        }
    }
   
    abstract class Warehouse
    {
        public string Name;
        public Address Address;
        public double Area;
        public Employee MainEmployee;
        public List<Product> AllProducts=new List<Product> {};
        public Dictionary<string, double> AllProductsNumber;
        public event EventHandler<ProductEventArgs>ProductAdded;

        public abstract void AddProduct(Product p);

        public Warehouse(string name, Address address, double area, Employee main)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Имя пустое или неопределено!");
            }
            else
            {
                Name = name;
            }
            if (area < 0) { throw new Exception("Значение цены не может быть отрицательным числом!"); }
            else { Area = area; }
            MainEmployee = main;
            Address = address;      
        }
        public Product Search(uint sku)
        {
            foreach (Product p in AllProducts){ if (p.SKU == sku) { return p; } }
            return null;
        }
        public decimal CountTotalPrice()
        {
            decimal result = 0;
            foreach(Product p in AllProducts) { result += p.CountTotalPrice(); }
            return result;
        }
        void SetMainEmployee(Employee main){ MainEmployee = main; }

        public void SendToAnother(Warehouse s,Product p)
        {
            AllProducts.Remove(p);
            s.AddProduct(p);
        }


        public static Warehouse SearchStore(List<Warehouse> stores,Product prod)
        {
            foreach(Warehouse s in stores)
            {
                foreach(Product p in s.AllProducts)
                {
                    if (prod.GetTotalQuantity() <= p.GetTotalQuantity()) { return s; }
                }
            }
            return null;
        }

        protected virtual void OnProductAdded(Product p)
        {
            if(ProductAdded!=null)
            {
                ProductAdded(this,new ProductEventArgs { product=p});
            }
        }
    }
}
