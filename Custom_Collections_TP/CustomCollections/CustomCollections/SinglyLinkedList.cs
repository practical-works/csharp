using System;
using System.Collections;

namespace CustomCollections
{
    public class SinglyLinkedList : IEnumerable, IEnumerator
    {
        private Node firstNode;
        public bool IsEmpty 
        { 
            get 
            { 
                return (firstNode == null);
            } 
        }
        public int Count 
        {
            get
            {
                Node currentNode = firstNode;
                int count = 0;
                while (currentNode != null)
                {
                    count++;
                    currentNode = currentNode.Next;
                }
                return count;
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

        public object this[int index]
        {
            get
            {
                Node currentNode = firstNode;
                int count = 0;
                while (count < index)
                {
                    count++;
                    currentNode = currentNode.Next;
                }
                return currentNode.Data;
            }
            set
            {
                Node currentNode = firstNode;
                int count = 0;
                while (count < index)
                {
                    count++;
                    currentNode = currentNode.Next;
                }
                currentNode.Data = value;
            }
        }

        public void DisplayInConsole()
        {
            Node currentNode = firstNode;
            System.Console.Write("{ ");
            while (currentNode != null)
            {
                System.Console.Write(currentNode + " ");
                currentNode = currentNode.Next;
            }
            System.Console.Write(" }\n");
        }
        
        public void AddFirst(object data)
        {
            firstNode = new Node(data, firstNode);
        }
        public void AddLast(object data)
        {
            if (IsEmpty)
            {
                AddFirst(data);
            }
            else
            {
                Node currentNode = firstNode;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                // current node is the last node
                currentNode.Next = new Node(data, next: null);
            }
        }
        public void Add(object data)
        {
            AddLast(data);
        }
        public void Insert(object data, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                Node cuurentNode = firstNode;
                int count = 0;
                while (count < index - 1)
                {
                    count++;
                    cuurentNode = cuurentNode.Next;
                }
                // current node is the node before node of index argument
                cuurentNode.Next = new Node(data, cuurentNode.Next);
            }
        }
        public Node DeleteFirst()
        {
            if (IsEmpty)
            {
                return null;
            }
            else
            {
                Node deletedNode = firstNode;
                firstNode = firstNode.Next;
                return deletedNode;
            }
        }
        public Node DeleteLast()
        {
            if (IsEmpty)
            {
                return null;
            }
            else
            {
                Node currentNode = firstNode;
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                Node deletedNode = currentNode.Next;
                currentNode.Next = null;
                return deletedNode;
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
            else if (Current == null)
            {
                Current = firstNode;
                return true;
            }
            else if (((Node)Current).Next == null)
            {
                return false;
            }
            else
            {
                Current = ((Node)Current).Next;
                return true;
            }
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

    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }

        public Node() { }
        public Node(object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public Node(Node node)
        {
            this.Data = node.Data;
            this.Next = node.Next;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
