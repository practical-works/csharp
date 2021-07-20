using System;
using System.Collections;
using CustomCollections;

namespace CustomCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //SinglyLinkedListTest();
            //ArrayTest();
            //StackTest();
            //QueueTest();
            
            Console.ReadLine();
        }

        public static void SinglyLinkedListTest()
        {
            SinglyLinkedList myList = new SinglyLinkedList();

            myList.AddLast("I");
            myList.AddLast("am");
            myList.AddLast("in");
            myList.AddLast("love");
            myList.AddLast("with");
            myList.AddLast("you");


            myList.DisplayInConsole();
            Console.WriteLine("\nIsEmpty : " + myList.IsEmpty);
            Console.WriteLine("Count : " + myList.Count);

            Console.WriteLine("\nGet Item {0} : {1}", 5, myList[5]);

            Console.WriteLine("\nAdd First Item : Honey");
            myList.AddFirst("Honey");
            myList.DisplayInConsole();

            Console.WriteLine("\nGet Item {0} : {1}", 5, myList[5]);

            Console.WriteLine("\nAdd Last Item : <3");
            myList.AddLast("<3");
            myList.DisplayInConsole();

            Console.WriteLine("\nGet Item {0} : {1}", 5, myList[5]);

            Console.WriteLine("\nInsert Item at index 3 : YEAH");
            myList.Insert("YEAH", 3);
            myList.DisplayInConsole();

            Console.WriteLine("\nGet Item {0} : {1}", 5, myList[5]);

            Console.WriteLine("\nDelete First Item : " + myList.DeleteFirst());
            myList.DisplayInConsole();

            Console.WriteLine("\nGet Item {0} : {1}", 5, myList[5]);

            Console.WriteLine("\nDelete Last Item : " + myList.DeleteLast());
            myList.DisplayInConsole();

            Console.WriteLine("\nGet Item {0} : {1}", 5, myList[5]);


            SinglyLinkedList list = new SinglyLinkedList() { "Hi", 17, true, "hhhhhhhhhh", 334 };

            Console.WriteLine("Iteration using enumeration implementations :");
            foreach (var item in list)
            {
                Console.WriteLine(" => " + item);
            }
            Console.ReadLine();

            Console.ReadLine();
        }
        private static void ArrayTest()
        {
            Array myArray = new Array(10);
            myArray.Add("I");
            myArray.Add("Love");
            myArray.Add("You");
            myArray.Add("meow");

            Console.WriteLine("Length : " + myArray.Capacity);
            Console.WriteLine("Count : " + myArray.Count);
            myArray.DisplayInConsole();

            Console.WriteLine();

            Console.WriteLine("Delete last Item : " + myArray.Delete());

            Console.WriteLine();

            Console.WriteLine("Length : " + myArray.Capacity);
            Console.WriteLine("Count : " + myArray.Count);
            myArray.DisplayInConsole();
        }
        private static void StackTest()
        {
            Stack myStack = new Stack(10) { 0, 1, 2, 3, 4, 5, 6 };
            myStack.Push(7);
            myStack.DisplayInConsole();

            int index = 0;
            Console.WriteLine("Item at index {0} : {1}", index, myStack[index]);
            Console.WriteLine("Item at Top : {0}", myStack.Peek());
            
            Console.WriteLine("Pop : " + myStack.Pop());
            myStack.DisplayInConsole();

            Console.WriteLine("Pop : " + myStack.Pop());
            myStack.DisplayInConsole();
        }
        private static void QueueTest()
        {
            Queue myQ = new Queue(4);
            Action frontRear = () => Console.WriteLine("(Front, Rear) : ({0}, {1})\n", myQ.Front, myQ.Rear);
            
            // ----------------------------------------------------------------------

            myQ.DisplayInConsole(); frontRear();
            myQ.Enqueue("x"); Console.WriteLine("\t[+] Enqueuing : x");
            myQ.DisplayInConsole(); frontRear();

            Console.WriteLine("\t[-] Dequeuing : " + myQ.Dequeue());
            myQ.DisplayInConsole(); frontRear();

            Console.WriteLine("\tCreating a queue of : {0} places", myQ.Size);
            myQ.Enqueue("#####"); Console.WriteLine("\t[+] Enqueuing : #####");
            myQ.Enqueue("AAAAA"); Console.WriteLine("\t[+] Enqueuing : AAAAA");
            myQ.Enqueue("BBBBB"); Console.WriteLine("\t[+] Enqueuing : BBBBB");
            myQ.DisplayInConsole(); frontRear();

            Console.WriteLine("\t[-] Dequeuing : " + myQ.Dequeue());
            myQ.DisplayInConsole(); frontRear();

            myQ.Enqueue("CCCCC"); Console.WriteLine("\t[+] Enqueuing : CCCCC");
            myQ.DisplayInConsole(); frontRear();

            myQ.Enqueue("DDDDD"); Console.WriteLine("\t[+] Enqueuing : DDDD");
            myQ.DisplayInConsole(); frontRear();

            Console.WriteLine("\t[-] Dequeuing : " + myQ.Dequeue());
            myQ.DisplayInConsole(); frontRear();

            Console.WriteLine("\t[-] Dequeuing : " + myQ.Dequeue());
            myQ.DisplayInConsole(); frontRear();

            Console.WriteLine("\t[-] Dequeuing : " + myQ.Dequeue());
            myQ.DisplayInConsole(); frontRear();

            Console.WriteLine("\t[-] Dequeuing : " + myQ.Dequeue());
            myQ.DisplayInConsole(); frontRear();
        }
    }
}
