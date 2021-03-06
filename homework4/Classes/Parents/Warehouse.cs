﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework4.Classes;
using NLog;
namespace homework4.Classes
{
   public struct Address
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
   
    public abstract class Warehouse
    {
        public string Name;
        public Address Address;
        public double Area;
        public Employee MainEmployee;
        public List<Product> AllProducts=new List<Product> {};
        public Dictionary<string, double> AllProductsNumber;
        public event EventHandler<ProductEventArgs>ProductAdded;
        public event EventHandler<ProductEventArgs> ProductDeleted;
        public CommandManager CommandManager = new CommandManager();
        protected Logger log = LogManager.GetCurrentClassLogger();
        public abstract void AddProduct(Product p);

        public  void DeleteProduct(Product p)
        {
            AllProducts.Remove(p);
            OnProductDeleted(p);
        }

        public Warehouse(string name, Address address, double area, Employee main)
        {
            if (string.IsNullOrEmpty(name))
            {
                Exception ex = new Exception("Имя пустое или неопределено!");
                log.Error(ex, ex.Message);
                throw ex;
            }
            else
            {
                Name = name;
            }
            if (area < 0) { throw new Exception("Значение площади не может быть отрицательным числом!"); }
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
        protected virtual void OnProductDeleted(Product p)
        {
            if(ProductDeleted!=null)
            {
                ProductDeleted(this, new ProductEventArgs { product = p });
            }
        }
    }
}
