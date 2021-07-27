using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;

            while (counter < 4)
            {
                Console.WriteLine("Doing something");

                // counter = counter + 1;
                counter++;
            }
        }
    }
}
