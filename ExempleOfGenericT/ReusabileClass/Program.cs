using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReusabileClass
{

    // Declare the generic class.
    public class GenericListType<T>
    {
        public void Add(T input) { }
    }
    // type parameter T in angle brackets
    public class GenericList<T>
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        // constructor
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type:
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    class TestGenericList
    {
        private class ExampleClass { }
        static void Main()
        {
            

            GenericList<int> list1 = new GenericList<int>();


            for (int x = 0; x < 10; x++)
            {
                list1.AddHead(x);
            }

            GenericList<string> list2 = new GenericList<string>();
            for (int x = 0; x < 2; x++)
            {
                list2.AddHead("Shahin");
            }

            foreach (int i in list1)
            {
                System.Console.Write(i + " ");
            }
            foreach (var item in list2)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine("\nDone");

        }
    }
}
