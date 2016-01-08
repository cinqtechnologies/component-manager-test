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
            listener.StartListening();
        }
    }
}
