using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework4.Classes;
namespace homework4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Address a1 = new Address("KZ", "Aktobe", "Aktobe", "Bogenbay batyr", "33");
            Employee e = new Employee("Георгий", Positions.Main);
            Outdoor o = new Outdoor("Склад1", a1, 500.1, e);
            Liquid l1 = new Liquid("Вода",12345,1000,"Питьевая вода",10000,Units.Liters);
            Liquid l2 = new Liquid("Напиток",1234567,1000,"Яблочный сок",2000,Units.Liters);
            Piece p1 = new Piece("Мячи",45632,1000,"Футбольные мячи",90,Units.Pieces);
            Overall ov = new Overall("Диван",64367,100000,"Для дома",40,Units.Pieces);
            Bulk bb = new Bulk("Песок", 43243, 1000, "Строительный песок", 54545, Units.CubicMeters);
            o.ProductAdded += OnProductAdded;
            o.IncorrectProductAdded += OnIncorrectProductAdded;
            try
            {
                o.AddProduct(l1);
                o.AddProduct(l2);
                o.AddProduct(p1);
                o.AddProduct(ov);
                o.AddProduct(bb);
                Console.WriteLine("Продукты успешно добавлены!\n");
            }
            catch(CannotStoreException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Все товары кроме сыпучих успешно добавлены!\n");
            }

            Console.WriteLine("Открытый склад:");
            Console.WriteLine("Все товары в открытом складе:");
            foreach (Product p in o.AllProducts)
            {
                Console.WriteLine(p.Description);
            }
            Console.WriteLine($"На общую сумму:{o.CountTotalPrice()}");

            Console.WriteLine("Количество товаров по типам:");
            foreach(KeyValuePair<string,double> entry in o.AllProductsNumber)
            {
                Console.WriteLine($"Тип:{entry.Key}\tКоличество:{entry.Value}");
            }

            Console.WriteLine("Ищу товар по коду 12345:");
            Product finded = o.Search(12345);
            Console.WriteLine(finded.Description);
            Console.WriteLine("Ищу товар по коду 1234567:");
            finded = o.Search(1234567);
            Console.WriteLine(finded.Description);

            Address a2 = new Address("KZ", "Almaty", "Almaty", "Abylai khan", "145");
            Console.WriteLine("\nЗакрытый склад:");
            Employee e2 = new Employee("Василий", Positions.Guard);
            Indoor i = new Indoor("Склад2", a2, 3000, e2);
            Bulk b = new Bulk("Песок",46778,1000,"Строительный песок",10000,Units.CubicMeters);
            Liquid l3 = new Liquid("Энергетик",46732,500,"RedBull",100,Units.Liters);
            i.ProductAdded += OnProductAdded;

            i.AddProduct(b);
            i.AddProduct(l3);

            Console.WriteLine("Все товары в закрытом складе:");
            foreach (Product p in i.AllProducts)
            {
                Console.WriteLine(p.Description);
            }
            Console.WriteLine($"На общую сумму:{i.CountTotalPrice()}");
            Console.WriteLine("Количество товаров по типам:");
            foreach (KeyValuePair<string, double> entry in i.AllProductsNumber)
            {
                Console.WriteLine($"Тип:{entry.Key}\tКоличество:{entry.Value}");
            }
            Console.ReadKey();
        }
        public static void OnProductAdded(object sender, ProductEventArgs e)
        {
            Console.WriteLine($"Продукт {e.product.Name} добавлен на склад");
        }

        public static void OnIncorrectProductAdded(object sender, ProductEventArgs e)
        {
            Console.WriteLine($"Продукт {e.product.Name} нельзя добавлять на склад! Так как он сыпучий");
        }
    }
}
