using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threads.KerenelMode.WaitHandle
{
    class ManualResetEventSample
    {
        public int CriticalSection = 0;
        public EventWaitHandle ManualEvent = new ManualResetEvent(true);
        public void DoWorkerThread()
        {

            Console.WriteLine("Ready To Start Working....{0}", Thread.CurrentThread.Name);
            //ManualEvent.WaitOne();
            ManualEvent.Reset();
            Console.WriteLine("Raised ManualResetEvent{0}", Thread.CurrentThread.Name);
            var temp = CriticalSection;
            temp++;
            CriticalSection = temp;
            Thread.Sleep(2000);
            Console.WriteLine("Completed Task..{0}", Thread.CurrentThread.Name);
             InvokeLeave();
        }

        private void InvokeLeave()
        {
            Console.WriteLine("Invoking Set....");
            ManualEvent.Set();
        }

        public void CreateThread()
        {
            Thread firsThread = new Thread(DoWorkerThread);
            firsThread.Name = "First";
            Thread secondThread = new Thread(DoWorkerThread);
            secondThread.Name = "Second";
   //         Thread thirdThread = new Thread(DoWorkerThread);
 //           thirdThread.Name = "Third";
            firsThread.Start();
            secondThread.Start();
             Thread.Sleep(7000);
            Console.WriteLine("After Task Complted{0}", CriticalSection);
        }
    }
}
