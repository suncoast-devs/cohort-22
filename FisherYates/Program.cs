using System;
using System.Collections.Generic;

namespace FisherYates
{
  class Program
  {
    static void Main(string[] args)
    {
      var students = new List<string>() {
"Janos Rawlings",
"Burk Jantet",
"Bernardo Denerley",
"Hartley Stroton",
"Rozanna Tuer",
"Fredericka Troppmann",
"Haroun Mariotte",
"Neilla MacConchie",
"Christopher Quant",
"Dennie Fedorchenko",
"Harmonie Provis",
"Michele Clatworthy",
"Remy McLeese",
"Moishe Seint",
"Bertrand Norheny",
"Mart I'anson",
"Ernesta Igoe",
"Layton Delacour",
"Emmanuel Beare",
"Hettie Lardeur",
"Carmelia Camosso",
"Annalise Doram",
"Milt Caulier",
"King Kocher",
"Gothart Edeler",
"Marika Rishbrook",
"Karalynn McBride",
"Theresita Habbal",
"Janot Edens",
"Juline Henker",
"Pearl Figge",
"Maxi Clayworth",
"Cory Ciciotti",
"Jeffry Heineking",
"Oates Bales",
"Reta Menauteau",
"Lori Fulop",
"Rickard Larvin",
"Clayton Dogg",
"Agathe Vedyasov",
"Ingar Dyzart",
"Mile Wrassell",
"Shirl Niblo",
"Ryon Dorn",
"Neila Spancock",
"Linzy Portwaine",
"Darcee Mortimer",
"Lottie Twiddell",
"Dominik Tyres",
"Fiorenze Balsom",
"Simonette MacGaughie",
"Vivyan Folca",
};
      // numberOfStudents = length of our students
      var numberOfStudents = students.Count;

      // for rightIndex from numberOfStudents - 1 down to 1 do:
      for (var rightIndex = numberOfStudents - 1; rightIndex >= 1; rightIndex--)
      {
        //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")
        var randomNumberGenerator = new Random();
        var leftIndex = randomNumberGenerator.Next(rightIndex);

        //   Now swap the values at rightIndex and leftIndex by doing this:
        //     leftStudent = the value from students[leftIndex]
        var leftStudent = students[leftIndex];

        //     rightStudent = the value from students[rightIndex]
        var rightStudent = students[rightIndex];

        //     students[rightIndex] = leftStudent
        students[rightIndex] = leftStudent;

        //     students[leftIndex] = rightStudent
        students[leftIndex] = rightStudent;
      }

      var firstStudent = students[0];
      Console.WriteLine(firstStudent);

      // foreach (var student in students)
      // {
      //   Console.WriteLine(student);
      // }
    }
  }
}
