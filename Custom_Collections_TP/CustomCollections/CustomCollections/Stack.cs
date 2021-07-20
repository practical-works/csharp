using System;
using System.Collections;

namespace CustomCollections
{
    public class Stack : IEnumerable, IEnumerator
    {
        private object[] stackArray;
        public bool IsEmpty
        {
            get
            {
                return (TopIndex == -1);
            }
        }
        public bool IsFull
        {
            get
            {
                return (TopIndex == Size - 1);
            }
        }
        public int TopIndex { get; private set; }
        public int Size { get; private set; }
        // Résumé :
        //     Obtient l'élément actuel dans la collection.
        //
        // Retourne :
        //     Élément actuel dans la collection.
        //
        // Exceptions :
        //   System.InvalidOperationException:
        //     L'énumérateur précède le premier élément ou suit le dernier élément de la
        //     collection.
        public object Current { get; private set; }
        public int CurrentIndex { get; private set; }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index > TopIndex)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return stackArray[TopIndex - index];
                }
                
            }
            set
            {
                if (index >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    stackArray[index] = value;
                }
            }
        }

        public Stack(int size)
        {
            Size = size;
            TopIndex = CurrentIndex = -1;
            stackArray = new object[Size];
        }

        public void DisplayInConsole()
        {
            Console.WriteLine(Environment.NewLine);
            foreach (object item in this)
            {
                Console.WriteLine("{0}.\t[ {1} ]", CurrentIndex, item);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public object Peek()
        {
            return stackArray[TopIndex];
        }

        public void Add(object data)
        {
            Push(data);
        }
        public void Push(object data)
        {
            if (IsFull)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                TopIndex++;
                stackArray[TopIndex] = data;
            }
        }
        public object Pop()
        {
            if (IsEmpty)
            {
                return null;
            }
            else
            {
                int oldTopIndex = TopIndex;
                TopIndex--;
                return stackArray[oldTopIndex];
            }
        }

        // Résumé :
        //     Avance l'énumérateur à l'élément suivant de la collection.
        //
        // Retourne :
        //     true si l'énumérateur a pu avancer jusqu'à l'élément suivant ; false si l'énumérateur
        //     a dépassé la fin de la collection.
        //
        // Exceptions :
        //   System.InvalidOperationException:
        //     La collection a été modifiée après la création de l'énumérateur.
        public bool MoveNext()
        {
            if (IsEmpty)
            {
                return false;
            }
            if (CurrentIndex >= TopIndex)
            {
                Reset();
                return false;
            }
            CurrentIndex++;
            Current = this[CurrentIndex];
            return true;
        }
        // Résumé :
        //     Rétablit l'énumérateur à sa position initiale, qui précède le premier élément
        //     de la collection.
        //
        // Exceptions :
        //   System.InvalidOperationException:
        //     La collection a été modifiée après la création de l'énumérateur.
        public void Reset()
        {
            CurrentIndex = -1;
            Current = null;
        }
        // Résumé :
        //     Retourne un énumérateur qui itère au sein d'une collection.
        //
        // Retourne :
        //     Objet System.Collections.IEnumerator pouvant être utilisé pour itérer au
        //     sein de la collection.
        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
