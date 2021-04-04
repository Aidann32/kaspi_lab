using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework4.Classes
{
    public class CommandManager
    {
        private ConcurrentQueue<CommandOnWarehouse> commands=new ConcurrentQueue<CommandOnWarehouse>();
        public event EventHandler QueueExecuted;
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private CancellationToken token = cancelTokenSource.Token;

        public void AddCommandToQueue(CommandOnWarehouse c)
        {
            Task addToQueue = new Task(() =>
            {
                commands.Enqueue(c);
                if(token.IsCancellationRequested)
                {
                    Stop();
                }
            });
            addToQueue.Start();
            addToQueue.Wait();
        }
        
        private void executeQueue()
        {
            foreach(var i in commands)
            {
                i.Execute();
            }
            
        }

        public void ExecuteQueue()
        {
            Task execQueue = new Task(() =>
            {
                executeQueue();
                if(cancelTokenSource.IsCancellationRequested)
                {
                    Stop();
                }
                OnQueueExecuted();
            });
            execQueue.Start();
            execQueue.Wait();        
        }
        public void Stop()
        {
            cancelTokenSource.Cancel();
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
