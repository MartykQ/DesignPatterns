using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Rental r1 = new Rental("Maciek", 3, 10);

            Console.WriteLine($"Price: {r1.CalculatePrice()}");
        }
    }
}
