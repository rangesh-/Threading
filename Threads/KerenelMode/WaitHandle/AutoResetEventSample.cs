using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threads.KerenelMode.WaitHandle
{
   public class AutoResetEventSample
   {
       public int CriticalSection = 0;
      public EventWaitHandle Autoevent=new AutoResetEvent(true);
        public void DoWorkerThread()
        {

            Console.WriteLine("Ready To Start Working....{0}",Thread.CurrentThread.Name);
            Autoevent.WaitOne();
            Console.WriteLine("Raised AutoResetEvent{0}",Thread.CurrentThread.Name);
            var temp = CriticalSection;
            temp++;
            CriticalSection = temp;

            Console.WriteLine("Completed Task..{0}",Thread.CurrentThread.Name);
    //    InvokeLeave();
        }

        private void InvokeLeave()
        {
            Console.WriteLine("Invoking Set....");
            Autoevent.Set();
        }

       public void CreateThread()
       {
           Thread firsThread=new Thread(DoWorkerThread);
           firsThread.Name = "First";
           Thread secondThread=new Thread(DoWorkerThread);
           secondThread.Name = "Second";
           Thread thirdThread = new Thread(DoWorkerThread);
           thirdThread.Name = "Third";
           firsThread.Start();
           secondThread.Start();
           thirdThread.Start();
           Thread.Sleep(7000);
           Console.WriteLine("After Task Complted{0}",CriticalSection);
       }
    }
}
