using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_TP
{
    public static partial class Exercises
    {
        public static void Ex1()
        {
            Console.WriteLine("The numbers which produce the remainder 0 after divided by 2 are :");
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //IEnumerable<int> query = from n in numbers
            //                         where n % 2 == 0
            //                         select n;
            IEnumerable<int> query = numbers.Where(n => n % 2 == 0);
            foreach (int n in query)
            {
                Console.WriteLine(n);
            }
        }
        public static void Ex2()
        {
            Console.WriteLine("The numbers within the range of 1 to 11 are :");
            int[] numbers = { -3, -2, -1, 0, 1, 22, 3, 4, 5, 9, -200, -70, 10, 11, 17, 20 };
            //IEnumerable<int> query = from n in numbers
            //                         where n >= 1 && n <= 11
            //                         select n;
            IEnumerable<int> query = numbers.Where(n => n >= 1 && n <= 11);
            foreach (int n in query)
            {
                Console.WriteLine(n);
            }
        }
        public static void Ex3()
        {
            Console.WriteLine("The numbers of the array with the square of each one :");
            int[] numbers = { 9, 8, 6, 5 };
            //var query = from n in numbers
            //            select new { Number = n, SqrNo = Math.Pow(n, 2) };
            var query = numbers.Select(n => new { Number = n, SqrNo = Math.Pow(n, 2) }); 
            foreach (var n in query)
            {
                Console.WriteLine(n);
            }
        }
        public static void Ex4()
        {
            Console.WriteLine("The number and the Frequency are :");
            int[] numbers = { 5, 9, 5, 5, 9, 1, 10, 7, 7, 7, 7, 7, 7, 7 };
            //IEnumerable<IGrouping<int, int>> query = from n in numbers
            //                                         group n by n;
            IEnumerable<IGrouping<int, int>> query = numbers.GroupBy(n => n);
            foreach (IGrouping<int, int> group in query)
            {
                Console.WriteLine("Number {0} appears {1} times.", group.Key, group.Count());
            }
        }
        public static void Ex5()
        {
            string word = "apple";
            Console.WriteLine("[{0}] The frequency of the characters are :", word);
            //IEnumerable<IGrouping<char, char>> query = from c in word
            //                                           group c by c;
            IEnumerable<IGrouping<char, char>> query = word.GroupBy(c => c);
            foreach (IGrouping<char, char> group in query)
            {
                Console.WriteLine("Character {0} : {1} times.", group.Key, group.Count());
            }
            Console.WriteLine("Alternative :");
            //var query2 = from c in word
            //             group c by c into wordGroup
            //             select new { Number = wordGroup.Key, Frequency = wordGroup.Count() };
            var query2 = word.GroupBy(c => c).Select((g, c) => new { Number = g.Key, Frequency = g.Count() });
            foreach (var g in query2)
            {
                Console.WriteLine("Character {0} : {1} times.", g.Number, g.Frequency);
            }
        }
        public static void Ex6()
        {
            Console.WriteLine("Days of a week :");
            string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            //foreach (string day in daysOfWeek)
            //{
            //    Console.WriteLine(day);
            //}
            daysOfWeek.ToList<string>().ForEach(day => Console.WriteLine(day));
        }
        public static void Ex7()
        {
            List<int> numbers = new List<int>() { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };
            Console.WriteLine();
            Console.WriteLine("Number \tNumber*Frequency \tFrequency");
            Console.WriteLine("------------------------------------------");
            //var query = from n in numbers
            //            group n by n into numbersGroups
            //            select new 
            //            {
            //                Number = numbersGroups.Key, 
            //                NumberXFrequency = numbersGroups.Key*numbersGroups.Count(),
            //                Frequency = numbersGroups.Count()
            //            };
            var query = numbers.GroupBy(n => n).Select((g, n) => new 
                { 
                    Number = g.Key, 
                    NumberXFrequency = g.Key*g.Count(),
                    Frequency = g.Count()
                });
            foreach (var g in query)
            {
                Console.WriteLine("{0} \t{1} \t\t\t{2}", g.Number, g.NumberXFrequency, g.Frequency);
            }
        }
        public static void Ex8()
        {
            List<string> cities = new List<string>()
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI","PARIS"
            };
            Console.WriteLine("\nThe cities are :");
            cities.ForEach(city => Console.WriteLine(city));
            char startingChar = 'A'; 
            char endingChar = 'M';
            Console.WriteLine("The city starting with {0} and ending with {1} is :", startingChar, endingChar);
            //IEnumerable<string> query = from city in cities
            //                            where city[0] == startingChar && city[city.Length - 1] == endingChar
            //                            select city;
            IEnumerable<string> query = cities.Where(city =>
                city.StartsWith(startingChar.ToString()) && city.EndsWith(endingChar.ToString()));
            query.ToList<string>().ForEach(city => Console.WriteLine(city));
        }
        public static void Ex9()
        {
            int[] numbers = { 55, 200, 740, 76, 230, 482, 95 };
            Console.WriteLine("\nThe numbers of the list are :");
            numbers.ToList<int>().ForEach(num => Console.Write(num + " "));
            int cap = 80;
            Console.WriteLine("\nThe numbers greater than {0} are :", cap);
            //IEnumerable<int> query = from num in numbers
            //                         where num > cap
            //                         select num;
            IEnumerable<int> query = numbers.Where(num => num > cap);
            query.ToList<int>().ForEach(num => Console.Write(num + " "));
        }
        public static void Ex10()
        {
            int[] numbers = { 10, 48, 52, 94, 63 };
            Console.WriteLine("\n\nThe numbers of the list are :");
            numbers.ToList<int>().ForEach(num => Console.Write(num + " "));
            int cap = 59;
            Console.WriteLine("\nThe numbers greater than {0} are :", cap);
            //IEnumerable<int> query = from num in numbers
            //                         where num > cap
            //                         select num;
            IEnumerable<int> query = numbers.Where(num => num > cap);
            query.ToList<int>().ForEach(num => Console.Write(num + " "));
        }
    }
}
