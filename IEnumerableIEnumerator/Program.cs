using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace IEnumerableIEnumerator
{
    class Program
    {
        //test return yield
        //without return yield
        static IEnumerable<int> getData()
        {
            Console.WriteLine("Start getData");

            List<int> list = new List<int>();

            for(int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Preparation of value {0:}", i);
                list.Add(i);
            }
            Console.WriteLine("termination of the method getData");

            return list;
        }
        //with return yield
        static IEnumerable<int> getData2()
        {
            Console.WriteLine("Start getData");
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Preparation of value {0:}", i);
                yield return i;
            }
            Console.WriteLine("termination of the method getData");
        }

        //test return yield
        static void Main(string[] args)
        {
            //test return yield
            Console.WriteLine("Dowloading data");
            IEnumerable<int> data = getData();
            Console.WriteLine("Start processing");
            foreach(int i in data)
            {
                Console.WriteLine("Value reading {0:}", i);
                if (i == 3)
                    break;
            }

            Console.WriteLine("Completion of processing");
            //test IEnumerator first
            IEnumerator numer = "testIEnumerator".GetEnumerator();
            numer.MoveNext();
            char a = (char)numer.Current;
            while (numer.MoveNext())
            {
                Console.Write((char)numer.Current + ".");
            }

            //test IEnumerator second=>CustomCollection
            CustomCollection2 col = new CustomCollection2();
            IEnumerator number = col.GetEnumerator();

            Console.WriteLine();
            while (number.MoveNext())
            {
                Console.Write(number.Current + ".");
            }

            Console.ReadLine();
        }

        class CustomCollection : IEnumerable
        {
            string[] arr = { "Go", "For", "Expert", "Is", "Best", "Online", "Resource" };

            public IEnumerator GetEnumerator() 
            {
                foreach (string s in arr)
                    yield return s;
            }
        }
        class CustomCollection2 : IEnumerable<int>
        {
            int[] arr = { 1, 3, 5, 7, 9 };

            public IEnumerator<int> GetEnumerator()
            {
                foreach (int i in arr)
                    yield return i;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

    }
}
