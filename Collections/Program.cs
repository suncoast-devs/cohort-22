using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");

            var names = new List<string>() { "Mark", "Paula", "Sandy", "Bill" };

            var firstName = names[0];
            var secondName = names[1];
            var finalName = names[3];

            Console.WriteLine(firstName);
            Console.WriteLine(names.Count);

            names.Add("George");
            Console.WriteLine(names.Count);

            names.Insert(2, "Frank"); // "Mark", "Paula", "Frank", "Sandy", "Bill", "George"
            Console.WriteLine(names);

            var scores = new List<int>();
            scores.Add(12);
            scores.Add(100);
            scores.Add(55);
            scores.Add(44);
            scores.Add(12);

            var lastIndex = scores.Count - 1;
            var lastScore = scores[lastIndex];

            var indexOfFiftyFive = scores.IndexOf(55);
            Console.WriteLine($"Found 55 at index {indexOfFiftyFive}");

            var indexOfFourtyTwo = scores.IndexOf(42);
            Console.WriteLine($"Found 42 at index {indexOfFourtyTwo}");

            var indexOfTwelve = scores.IndexOf(12);
            Console.WriteLine($"Found 12 at index {indexOfTwelve}");

            var playerScores = new Dictionary<string, int>();

            playerScores.Add("Robbie Lakeman", 1_247_700);

            // This is an ERROR since Robbie is already ADDed
            // playerScores.Add("Robbie Lakeman", 3);

            // Look up Robbie Lakeman and CHANGE his score
            playerScores["Robbie Lakeman"] = 3;

            // Look up Gavin Stark and set his score, doesn't
            // matter that we haven't added him yet.
            playerScores["Gavin Stark"] = 42;

            var robbiePlayerScore = playerScores["Robbie Lakeman"];
            Console.WriteLine(robbiePlayerScore);

            var gavinScore = playerScores["Gavin Stark"];
            Console.WriteLine($"Gavin's score is {gavinScore}");

            var hasKey = playerScores.ContainsKey("Billy Mitchell");
            if (hasKey == true)
            {
                var billyScore = playerScores["Billy Mitchell"];
                Console.Write(billyScore);
            }

            var students = new Queue<string>();
            students.Enqueue("Mary");
            students.Enqueue("Bill");
            students.Enqueue("Paul");

            var firstStudent = students.Dequeue();
            Console.WriteLine(firstStudent);

            Console.Write("What is your name? (type quit to end) ");

            // When we write this:
            //
            // var name = Console.ReadLine();
            //
            // C# is _REALLY_ doing this for us:
            string name;
            name = Console.ReadLine();

            while (name != "quit")
            {
                Console.WriteLine($"Hello {name}");

                Console.Write("What is your name? ");
                name = Console.ReadLine();
            }
        }
    }
}
