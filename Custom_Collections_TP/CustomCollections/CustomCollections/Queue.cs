using System;
using System.Collections;

namespace CustomCollections
{
    public class Queue : IEnumerable, IEnumerator
    {
        private object[] queueArray;
        public int FrontIndex { get; private set; }
        public int RearIndex { get; private set; }
        public object Front { get { return queueArray[FrontIndex]; } }
        public object Rear { get { return (RearIndex != -1) ? queueArray[RearIndex] : null; } }
        public int Count { get; private set; }
        public int Size { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return (Count == 0);
            }
        }
        public bool IsFull
        {
            get
            {
                return (Count == Size);
            }
        }
        public bool RearReachedLimit
        {
            get
            {
                return (RearIndex == Size - 1);
            }
        }
        public bool FrontReachedLimit
        {
            get
            {
                return (FrontIndex == Size - 1);
            }
        }

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
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    if (index < Size - FrontIndex)
                    {
                        return queueArray[index + FrontIndex];
                    }
                    else
                    {
                        return queueArray[index - (Size - FrontIndex)];
                    }
                }
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    if (index < RearIndex)
                    {
                        queueArray[index + FrontIndex] = value;
                    }
                    else
                    {
                        queueArray[index - RearIndex] = value;
                    }
                }
            }
        }

        public Queue(int size)
        {
            Size = size;
            Count = 0;
            FrontIndex = 0;
            RearIndex = -1;
            CurrentIndex = -1;
            queueArray = new object[Size];
        }

        public void DisplayInConsole()
        {
            Console.WriteLine("<-------------------------------------------------------*");
            foreach (object item in this)
            {
                Console.Write("     {0}.{1}   ", CurrentIndex, item);
            }
            Console.WriteLine("\n<-------------------------------------------------------*");
        }

        public object Peek()
        {
            return queueArray[FrontIndex];
        }

        public void Add(object data)
        {
            Enqueue(data);
        }
        public void Enqueue(object data)
        {
            if (IsFull)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (RearReachedLimit)
                {
                    RearIndex = -1;
                }
                RearIndex++;
                queueArray[RearIndex] = data;
                Count++;
            }
        }
        public object Dequeue()
        {
            if (IsEmpty)
            {
                return null;
            }
            else
            {
                int oldFrontIndex = FrontIndex;
                if (FrontReachedLimit)
                {
                    FrontIndex = -1;
                }
                FrontIndex++;
                Count--;
                return queueArray[oldFrontIndex];
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
            if (CurrentIndex >= Count - 1)
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
