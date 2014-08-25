using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threads
{
    class ThreadPool
    {
        public static void ThreadPools()
        {
            for (int i = 0; i < 10; i++)
            {
                int Rand = new Random().Next(250, 500);
                Thread.Sleep(Rand);
                //Console.WriteLine("Thread Invoked"+Thread.CurrentThread+Thread.E);
            }
        }

        public static void SampleThread(object o)
        {
            Console.WriteLine(Thread.CurrentThread.IsBackground);
            Thread.Sleep(50000);
        }

        public static void Samplethreadpool(object n)
        {
            int Rand = new Random().Next(250, 500);
            Thread.Sleep(Rand);
            Console.WriteLine("I m in{0}{1}{2}",Thread.CurrentThread.ManagedThreadId,Thread.CurrentThread.IsBackground,(int)n);
        }

        public static void limitingthreadpool()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(SampleThread);
            System.Threading.ThreadPool.SetMaxThreads(100, 3);
        }
    }
}
