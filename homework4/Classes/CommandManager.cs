using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4.Classes
{
    public class CommandManager
    {
        private Queue<CommandOnWarehouse> commands=new Queue<CommandOnWarehouse>();
        public event EventHandler QueueExecuted;

        public void AddCommandToQueue(CommandOnWarehouse c)
        {
            commands.Enqueue(c);
        }
        
        public void ExecuteQueue()
        {
            foreach(var i in commands)
            {
                i.Execute();
            }
            OnQueueExecuted();
        }
        protected virtual void OnQueueExecuted()
        {
            if (QueueExecuted != null)
            {
                QueueExecuted(this,new EventArgs { });
            }
        }
    }
}
