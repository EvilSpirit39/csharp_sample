using System;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your Name? ");
            var name = Console.ReadLine();

            Console.WriteLine("Hello, {0}", name);
        }
    }
}
