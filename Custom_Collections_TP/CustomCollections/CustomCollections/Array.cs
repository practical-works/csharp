using System;
using System.Collections;

namespace CustomCollections
{
    public class Array : IEnumerable, IEnumerator
    {
        private object[] array;
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
                return (Count == Capacity);
            }
        }
        public int Count { get; private set; }
        public int Capacity { get; private set; }
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
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return array[index];
                }
                
            }
            set
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    array[index] = value;
                }
            }
        }

        public Array(int capacity)
        {
            Capacity = capacity;
            Count = 0;
            array = new object[Capacity];
            CurrentIndex = -1;
        }

        public void DisplayInConsole()
        {
            System.Console.Write("{ ");
            foreach (object item in this)
            {
                System.Console.Write(item + " ");
            }
            System.Console.Write(" }\n");
        }

        public void Add(object data)
        {
            if (IsFull)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                array[Count] = data;
                Count++;
            }
        }
        public object Delete()
        {
            if (IsEmpty)
            {
                return null;
            }
            else
            {
                object deletedItem = array[Count - 1];
                Count--;
                return deletedItem;
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
