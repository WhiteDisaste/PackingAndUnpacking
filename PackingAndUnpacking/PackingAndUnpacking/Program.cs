using System;

namespace PackingAndUnpacking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var service = new PackingUnpackingService();
            service.MethodExecute();
        }
    }
}
