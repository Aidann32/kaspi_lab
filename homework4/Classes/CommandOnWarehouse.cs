using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    public class CommandOnWarehouse
    {
        //Receiver
        private Warehouse warehouse;

        private Product CurrentProduct;

        public CommandOnWarehouse(Warehouse w,Product p)
        {
            warehouse = w;
            CurrentProduct = p;
        }
        public void Execute()
        {
            warehouse.AddProduct(CurrentProduct);
        }
        public void Undo()
        {
            warehouse.DeleteProduct(CurrentProduct);
        }

    }
}
