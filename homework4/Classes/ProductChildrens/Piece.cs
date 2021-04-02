using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    class Piece : Product
    {
        //Properties
        public Units Unit;

        //Methods
        public Piece(string name, uint sku, decimal price, string desc, double number, Units unit)
            : base(name, sku, price, desc, number)
        {
            Unit = unit;
        }
     
        public override string ToString()
        {
            return "Piece";
        }
    }
}
