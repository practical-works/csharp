using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main thread
            WriteCurrentThreadInfos();
            AsyncRepeater repeater = new AsyncRepeater(1000, WriteCurrentThreadInfos);
            while (true)
            {
                repeater.Start(WriteStartText);     // Start repeater (loop in another thread)
                Console.ReadLine();                 // Block main thread from ending

                repeater.Stop(WriteEndText);        
                Console.ReadLine();

                repeater.Start2(WriteStartText);    // Start (Method 2) repeater (loop in another thread)
                Console.ReadLine();

                repeater.Stop(WriteEndText);
                Console.ReadLine();
            }
        }

        #region DisplayMethods
        static void WriteCurrentThreadInfos()
        {
            Console.WriteLine(ThreadInfos.CurrentThreadInfos);
        }
        static void WriteStartText()
        {
            Console.WriteLine("*---< Start of Loop >---*");
        }
        static void WriteEndText()
        {
            Console.WriteLine("*----< End of Loop >----*");
        }
        #endregion
    }
}
