using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Threads.Albharai
{
    class Example
    {
        private bool done = true;
        public void Go()
        {
            while (done)
            {
                Console.WriteLine("Hello");
                done = false;
            }
        }
        
    }
}
