using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threads.UserMode
{
    class Volatile
    {
        public bool _lock = false;
        public void BeforeVolatileUsage()
        {
            Console.WriteLine("Starting...");
            Thread T=new Thread(WorkerThread);
            T.Start();
            Thread.Sleep(5000);
            _lock = true;
            T.Join();
            Console.WriteLine("Completed...");
        }

        public void WorkerThread()
        {
            int x = 0;
            while (!_lock)
            {
                 Console.WriteLine(x++);
            }
        }

        

    }

     class SimpleSpinLock
     {
         private int m_ResourceFlag=0;
          private void Enter()
         {
              while (true)
              {
                  if (Interlocked.Exchange(ref m_ResourceFlag, 0) == 0)
                      return;
              }
         }

         public void Exit()
         {
             Interlocked.Exchange(ref m_ResourceFlag, 1);
         }
}
     }
    

