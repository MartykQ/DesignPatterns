using System;

namespace EntityFrameworkTrial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EntityFrameworkTest.Create();

            EntityFrameworkTest.Read();
        }
    }
}
