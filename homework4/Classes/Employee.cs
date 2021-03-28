using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    public enum Positions
    {
        Main,
        Loader,
        Cleaner,
        Guard
    }
    class Employee
    {
        public string Name;
        public Positions Position;
        public Employee(string name,Positions position)
        {
            if (string.IsNullOrEmpty(name)) { throw new Exception("Значение имени не может быть неопределеное или пустым!"); }
            else { Name = name; }
            Position = position;
        }
    }
}
