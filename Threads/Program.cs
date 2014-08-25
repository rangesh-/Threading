using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using Threads.Albharai;
using Threads.KerenelMode.WaitHandle;
using Threads.UserMode;

namespace Threads
{
    internal class Program
    {
          public static volatile int sum = 1;

        //Main Thread-ForeGround Thread
        private static void Main(string[] args)
        {
            InvokeManualResetEvent();
           // InvokeAutoResetEvent();
            // BeforeVolatile();
            //  BeforeInterlockedExample();
        }

        private static void InvokeManualResetEvent()
        {
           ManualResetEventSample sample=new ManualResetEventSample();
            sample.CreateThread();
        }

        private static void InvokeAutoResetEvent()
        {
            AutoResetEventSample sample=new AutoResetEventSample();
            sample.CreateThread();

        }

        private  void InvokeExample()
        {
            Example e=new Example();
new Thread(e.Go).Start();
            e.Go();
         }

        private static void BeforeVolatile()
        {
            Volatile v=new Volatile();
            v.BeforeVolatileUsage();
        }

        private static void BeforeInterlockedExample()
        {
            Thread[] T = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                T[i] = new Thread(Add);
                T[i].Start();
            }
        }

        private static void Add()
        {
           
            int temp = 0;
            temp = sum;
            temp++;
            Thread.Sleep(3);
            sum = temp;
            Console.WriteLine(sum);
        }

        
    }
}
