using System;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {

            Developer bartoszNguyen = new Developer("Bartosz");
            Console.WriteLine($"Pozycja bartosza to {bartoszNguyen.DeveloperPosition}");

            bartoszNguyen.changeDeveloperPosition();
            Console.WriteLine($"Pozycja bartosza to {bartoszNguyen.DeveloperPosition}");

            bartoszNguyen.changeDeveloperPosition();
            Console.WriteLine($"Pozycja bartosza to {bartoszNguyen.DeveloperPosition}");

        }
    }
}
