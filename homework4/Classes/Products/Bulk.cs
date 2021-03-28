using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    class Bulk : Product
    {
        //Properties
        public Units Unit;
   
        //Methods
        public Bulk(string name, uint sku, decimal price, string desc, double number,Units unit) 
            :base(name,sku,price,desc,number)
        {
            Unit = unit;
        }
        public override string ToString() { return "Bulk"; }
    }
}
