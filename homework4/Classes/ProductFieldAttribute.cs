using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ProductFieldAttribute : Attribute
    {
        public string FieldName{ get; set; }
        public ProductFieldAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
        
    }
}
