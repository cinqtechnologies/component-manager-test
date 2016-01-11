using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.GenericReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new AsynchronousSocketListener();
            Task.Run(() => listener.StartListening());
            Console.WriteLine("Generic reader is running");
            Console.Read();
        }
    }
}
