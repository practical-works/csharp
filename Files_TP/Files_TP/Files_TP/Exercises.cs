using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Files_TP
{
    public static class Exercises
    {
        public static void Ex1()
        {
            string path = @"ex1.txt";
            
            // Method 1 ==================================================
            using (FileStream fileStream = File.Create(path))
            {
                Console.WriteLine("A file created with name {0}", path);
            }

            // Method 2 ==================================================
            using (FileStream fileStream = File.Open(path, FileMode.Create))
            {
                Console.WriteLine("A file created with name {0}", path);
            }

            // Method 3 ==================================================
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                Console.WriteLine("A file created with name {0}", path);
            }

            // Method 4 ==================================================
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                Console.WriteLine("A file created with name {0}", path);
            }
        }
        public static void Ex2()
        {
            string path = @"ex2.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("The file {0} is deleted successfully", path);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        public static void Ex3()
        {
            string path = @"ex3.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("The file {0} is deleted successfully", path);
            }
            else
            {
                Console.WriteLine("File does not exist");
                using (FileStream fileStream = File.Create(path))
                {
                    Console.WriteLine("A file created with name {0}", path);
                }
            }
        }
        public static void Ex4()
        {
            string path = @"ex4.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("Hello World !");
                Console.WriteLine("A file created with content name {0}", path);
            }
        }
        public static void Ex5()
        {
            string path = @"ex5.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write("Hello and Welcome{0}It is the first content{0}nof the text file {1}", 
                    streamWriter.NewLine, path);
                Console.WriteLine("A file created with content name {0}", path);
            }
            
            // Method 1 ==================================================
            using (StreamReader streamReader = new StreamReader(path))
            {
                Console.WriteLine("Here is the content of the file {0} :", path);
                Console.WriteLine("*------------------------------------------*");
                while (!streamReader.EndOfStream)
                {
                    Console.WriteLine("\t" + streamReader.ReadLine());
                }
                Console.WriteLine("*------------------------------------------*");
            }
            
            // Method 2 ==================================================
            Console.WriteLine("Here is the content of the file {0} :", path);
            Console.WriteLine("*------------------------------------------*");
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("*------------------------------------------*");
            
            // Method 3 ==================================================
            Console.WriteLine("Here is the content of the file {0} :", path);
            Console.WriteLine("*------------------------------------------*");
            string content = File.ReadAllText(path);
            foreach (string line in content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("*------------------------------------------*");
        }
        public static void Ex6()
        {
            string path = @"ex6.txt";
            string[] stringArray = { "this is 1st line", "this is 2nd line", "this is 3rd line" };
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (string str in stringArray)
                {
                    streamWriter.WriteLine(str);
                }
            }
            Console.WriteLine("The content of the file is :");
            Console.WriteLine("*------------------------------------------*");
            foreach (string line in File.ReadLines(path))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("*------------------------------------------*");
        }
        public static void Ex7()
        {
            string path = @"ex7.txt";
            string[] sentences = { "the quick brown fox jumps", "over the lazy dog.", "LOL ^.^" };
            string ignoredLineWord = "fox";
            Console.WriteLine("Sentences to save :");
            foreach (string sentence in sentences)
            {
                Console.WriteLine("\t" + sentence);
            }
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (string sentence in sentences)
                {
                    if (!sentence.ToLower().Contains(ignoredLineWord))
                    {
                        streamWriter.WriteLine(sentence);
                    }
                    else
                    {
                        Console.WriteLine("The line has been ignored which contains the string : " + ignoredLineWord);
                    }
                }
            }
            Console.WriteLine("The content of the file is :");
            Console.WriteLine("*------------------------------------------*");
            foreach (string line in File.ReadLines(path))
            {
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("*------------------------------------------*");
        }
        public static void Ex8()
        {
            string path = @"ex8.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("Hello and Welcome{0}It is the first content{0}of the text file mytest.txt{0}", sw.NewLine);
                    Console.WriteLine("{0} file created.", path);
                }
            }
            using (StreamWriter sw = new StreamWriter(path, append:true))
            {
                sw.WriteLine("This is the line appended at last line at {0}", 
                    DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"));
                Console.WriteLine("A line is appended to {0} file.", path);
            }
        }
        public static void Ex9()
        {
            string path = @"ex9.txt";
            string copyPath = @"ex9_copy.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("Hello and Welcome{0}It is the first content{0}of the text file mytest.txt{0}", sw.NewLine);
                Console.WriteLine("{0} file created.", path);
            }
            if (!File.Exists(copyPath))
            {
                File.Copy(path, copyPath);
                Console.WriteLine("{0} file copied to {1} in the same directory.", path, copyPath);
            }
        }
        public static void Ex10()
        {
            string path = @"ex10.txt";
            string movePath = @"ex10_moved.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("Hello and Welcome{0}It is the first content{0}of the text file mytest.txt{0}", sw.NewLine);
                Console.WriteLine("{0} file created.", path);
            }
            if (!File.Exists(movePath))
            {
                File.Move(path, movePath);
                Console.WriteLine("{0} file moved to {1} in the same directory.", path, movePath);
            }
        }
        public static void Ex11()
        {
            string path = @"ex11.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("test line " + (i + 1));
                }
                Console.WriteLine("{0} file created.", path);
            }
            Console.WriteLine("The content of the first line of the file is :");
            Console.WriteLine("\t" + File.ReadLines(path).ToList()[0]);
        }
        public static void Ex12()
        {
            string path = @"ex12.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("This is the line number " + (i + 1));
                }
                Console.WriteLine("{0} file created.", path);
            }
            Console.WriteLine("The content of the last line of the file is :");
            Console.WriteLine("\t" + File.ReadLines(path).ToList()[File.ReadLines(path).Count() - 1]);
        }
        public static void Ex13()
        {
            string path = @"ex13.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("[{0}]==========> Line {1}", i, (i + 1));
                }
                Console.WriteLine("{0} file created.", path);
            }
            int lineNumber = 7;
            Console.WriteLine("The content of the line {0} of the file is :", lineNumber);
            if (lineNumber > 0 && lineNumber <= File.ReadLines(path).Count())
            {
                //using (StreamReader sr = new StreamReader(path))
                //{
                //    int i = 0;
                //    while (!sr.EndOfStream)
                //    {
                //        sr.ReadLine();
                //        i++;
                //        if (i == lineNumber - 1)
                //        {
                //            break;
                //        }
                //    }
                //    Console.WriteLine("\t" + sr.ReadLine());
                //}
                Console.WriteLine("\t" + File.ReadLines(path).ToList()[lineNumber - 1]);  
            } 
            else
	        {
                Console.WriteLine("Wrong line number");
	        }
        }
        public static void Ex14()
        {
            string path = @"ex14.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("[{0}]==========> The line number {1}", i, (i + 1));
                }
                Console.WriteLine("{0} file created.", path);
            }
            int numberOfLastLines = 3;
            Console.WriteLine("The content of the last {0} lines of the file is :", numberOfLastLines);
            if (numberOfLastLines > 0 && numberOfLastLines <= File.ReadLines(path).Count())
            {
                int totalLinesNumber = File.ReadLines(path).Count();
                int startIndex = totalLinesNumber - numberOfLastLines;
                for (int i = startIndex; i < totalLinesNumber; i++)
                {
                    Console.WriteLine("\t" + File.ReadLines(path).ToList()[i]);
                }
            }
            else
            {
                Console.WriteLine("Wrong line number");
            }
            // Extension
            int numberOfFirstLines = 3;
            Console.WriteLine("The content of the first {0} lines of the file is :", numberOfFirstLines);
            if (numberOfFirstLines > 0 && numberOfFirstLines <= File.ReadLines(path).Count())
            {
                int totalLinesNumber = File.ReadLines(path).Count();
                int endIndex = numberOfFirstLines;
                for (int i = 0; i < endIndex; i++)
                {
                    Console.WriteLine("\t" + File.ReadLines(path).ToList()[i]);
                }
            }
            else
            {
                Console.WriteLine("Wrong line number");
            }
        }
        public static void Ex15()
        {
            string path = @"ex15.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("[{0}]- The line number {1}", i, (i + 1));
                }
                Console.WriteLine("{0} file created.", path);
            }
            Console.WriteLine("The number of lines in the file is : " + File.ReadLines(path).Count());
        }
    }
}
