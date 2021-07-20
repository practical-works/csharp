using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LINQ_TP
{
    public partial class Exercises
    {
        public static void Ex11()
        {
            Console.Clear();
            int[] numbers = { 5, 7, 13, 24, 6, 9, 8, 7 };
            Console.WriteLine("The members of the list are :");
            numbers.ToList().ForEach(n => Console.Write(n + " "));
            int dispNum = 3;
            Console.WriteLine("\nThe top {0} records from the list are :", dispNum);
            //IEnumerable<int> queryHelper = from n in numbers
            //                         orderby n descending
            //                         select n;
            //IEnumerable<int> query = from n in queryHelper
            //                         where n > queryHelper.ToList()[dispNum]
            //                         select n;
            IEnumerable<int> query = numbers.OrderByDescending(n => n).Take(3);
            query.ToList().ForEach(n => Console.Write(n + " "));
        }
        public static void Ex12()
        {
            Console.WriteLine(Environment.NewLine);
            string theString = "this IS a STRING";
            Console.WriteLine("The UPPER CASE words in the string \"{0}\" are :", theString);
            //IEnumerable<string> query = from word in theString.Split(' ')
            //                            where word == word.ToUpper()
            //                            select word;
            IEnumerable<string> query = theString.Split(' ').Where(word => word == word.ToUpper());
            query.ToList().ForEach(word => Console.WriteLine(word));
        }
        public static void Ex13()
        {
            string[] stringArray = { "cat", "dog", "rat" };
            Console.WriteLine("A string array of {0} elements :", stringArray.Length);
            stringArray.ToList().ForEach(str => Console.WriteLine("\t" + str));
            Console.WriteLine("Here is the string below created with elements of the above array :");
            Console.WriteLine(string.Join(", ", stringArray)); ;
        }
        class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public double GradePoints { get; set; }
        }
        public static void Ex14()
        {
            List<Student> students = new List<Student>()
            {
                new Student() { ID = 1, Name = "Joseph", GradePoints = 650 },
                new Student() { ID = 2, Name = "Roma", GradePoints = 340 },
                new Student() { ID = 3, Name = "Kiara", GradePoints = 750 },
                new Student() { ID = 4, Name = "Lupiz", GradePoints = 189 },
                new Student() { ID = 5, Name = "Donald", GradePoints = 689 },
                new Student() { ID = 6, Name = "Krish", GradePoints = 450 },
                new Student() { ID = 7, Name = "David", GradePoints = 750 },
                new Student() { ID = 8, Name = "Raz", GradePoints = 750 },
                new Student() { ID = 9, Name = "Ken", GradePoints = 750 },
                new Student() { ID = 10, Name = "Jenny", GradePoints = 750 },
            };
            int cap = 3;
            Console.WriteLine("\n\nTop {0} students with the maximum grade points :", cap);
            //IEnumerable<Student> queryHelper = from std in students
            //                             where std.GradePoints == students.Max(s => s.GradePoints)
            //                             select std;
            //IEnumerable<Student> query = from std in queryHelper
            //                             where queryHelper.ToList().IndexOf(std) < cap
            //                             select std;
            IEnumerable<Student> query = students.Where(std => std.GradePoints == students.Max(s => s.GradePoints)).Take(cap);
            query.ToList().ForEach(std => 
                Console.WriteLine("Id : {0}, Name : {1}, Achieved Grade Points : {2}", std.ID, std.Name, std.GradePoints));
        }
        public static void Ex15()
        {
            Console.WriteLine("\nThe files are :");
            string[] files = 
            { 
                "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" 
            };
            Console.WriteLine("Here is the group of extension of the files :");
            //IEnumerable<IGrouping<string, string>> query = from f in files
            //                                               group f by f.ToLower().Substring(f.IndexOf(".") + 1);
            IEnumerable<IGrouping<string, string>> query = files.GroupBy(f => f.ToLower().Substring(f.IndexOf(".") + 1));
            foreach (IGrouping<string, string> fileGroup in query)
            {
                Console.WriteLine("{0} File(s) with {1} Extension.", fileGroup.Count(), fileGroup.Key);
            }
        }
        public static void Ex16()
        {
            string[] files = Directory.GetFiles(@"C:\Users\Ambratolm\Desktop\FILES\");
            Console.WriteLine("\n\nFiles in the folder :");
            IEnumerable<FileInfo> query = from f in files
                                          select new FileInfo(f);
            query.ToList().ForEach(fo => Console.WriteLine("\t" + fo.Name));
            Console.WriteLine("The Average file size is : {0} MB.", query.Average(fo => fo.Length/(double)1048576)); 
        }
        public static void Ex17()
        {
            Console.WriteLine("\n\n\n[Passing object to Remove function]");
            List<char> list = new List<char>() { 'm', 'n', 'o', 'p', 'q' };
            Console.WriteLine("Here is the list of items :");
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
            char itemToRemove = 'o';
            Console.WriteLine("Here is the list after removing the item {0} from the list :", itemToRemove);
            list.Remove(itemToRemove);
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
        }
        public static void Ex18()
        {
            Console.WriteLine("\n[Creating an object internally by filtering]");
            List<char> list = new List<char>() { 'm', 'n', 'o', 'p', 'q' };
            Console.WriteLine("Here is the list of items :");
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
            char itemToRemove = 'p';
            Console.WriteLine("Here is the list after removing the item {0} from the list :", itemToRemove);
            list.Remove(list.Find(c => c == itemToRemove));
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
        }
        public static void Ex19()
        {
            Console.WriteLine("\n[Passing filters]");
            List<char> list = new List<char>() { 'm', 'n', 'o', 'p', 'q' };
            Console.WriteLine("Here is the list of items :");
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
            char itemToRemove = 'q';
            Console.WriteLine("Here is the list after removing the item {0} from the list :", itemToRemove);
            list.RemoveAll(c => c == itemToRemove);
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
        }
        public static void Ex20()
        {
            Console.WriteLine("\n[Passing the item index]");
            List<char> list = new List<char>() { 'm', 'n', 'o', 'p', 'q' };
            Console.WriteLine("Here is the list of items :");
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
            int itemToRemoveIndex = 3;
            Console.WriteLine("Here is the list after removing the item {0} from the list :", itemToRemoveIndex);
            list.RemoveAt(itemToRemoveIndex);
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
        }
    }
}
