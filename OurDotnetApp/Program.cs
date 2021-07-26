using System;

namespace OurDotnetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implicit
            var personName = "Samantha";
            var score = 95;

            // Explicit
            string explicityName = "Frank";
            int price = 42;

            var total = score + price;

            bool isExpensive = true;
            bool isTuesday = false;

            var sentence = "The quick brown fox jumped over the lazy dog";
            var howLong = sentence.Length;

            var rightNow = DateTime.Now;
            var currentMonth = rightNow.Month;

            // This is a name of a variable
            // and I wan't it to be omg, what is happening

            Console.Write("What is your name? ");
            var name = Console.ReadLine();

            Console.Write("It is a pleasure to meet you, ");
            Console.WriteLine(name);

            var greeting = $"It is a pleasure to meet you, {name}";
            Console.WriteLine(greeting);

            Console.Write("What is your favorite number? ");
            var firstNumberAsString = Console.ReadLine();

        }
    }
}
