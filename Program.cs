using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        private const int NUM_TEST = 1000;
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<int> numbers = new List<int>();

            for (int i = 0; i < 1000000; i++)
                numbers.Add(rnd.Next(0, 100000000));

            IEnumerable<int> numbersIEnumerable = numbers.Where(n => true);


            Console.WriteLine("===IEnumerable Result===");

            DateTime test0Start = DateTime.UtcNow;
            IEnumerable<int> test0 = numbersIEnumerable.Where(n => n % 2 == 0);
            DateTime test0End = DateTime.UtcNow;
            Console.WriteLine($"IEnumerable.Where(): {(test0End - test0Start)} (Count:  {test0.Count()})");


            DateTime test1Start = DateTime.UtcNow;
            IEnumerable<int> test1 = numbers.Where(n => n % 2 == 0);
            DateTime test1End = DateTime.UtcNow;
            Console.WriteLine($"List.Where(): {(test1End - test1Start)} (Count: {test1.Count()})");



            Console.WriteLine("\n===With List and want a List as result===");

            DateTime test2Start = DateTime.UtcNow;
            List<int> test2 = numbers.Where(n => n % 2 == 0).ToList();
            DateTime test2End = DateTime.UtcNow;
            Console.WriteLine($"List.Where().ToList(): {(test2End - test2Start)} (Count: {test2.Count})");


            DateTime test3Start = DateTime.UtcNow;
            numbers.RemoveAll(n => n % 2 > 0);
            DateTime test3End = DateTime.UtcNow;
            Console.WriteLine($"List.RemoveAll(): {(test3End - test3Start)} (Count: {numbers.Count()})");



            Console.WriteLine("\n===With IEnumerable but want a List as result (test 1,000 times)===");

            List<int> newList = new List<int>();
            DateTime test4Start = DateTime.UtcNow;
            for (int i = 0; i < NUM_TEST; i++)
                numbersIEnumerable.ToList().RemoveAll(n => n % 2 > 0);            
            DateTime test4End = DateTime.UtcNow;
            Console.WriteLine($"IEnumerable.ToList().RemoveAll(): {(test4End - test4Start)} (Count: {newList.Count()})");


            List<int> newList1 = new List<int>();
            DateTime test5Start = DateTime.UtcNow;
            for (int i = 0; i < NUM_TEST; i++)
                newList1 = numbersIEnumerable.Where(n => n % 2 == 0).ToList();
            DateTime test5End = DateTime.UtcNow;
            Console.WriteLine($"IEnumerable.Where().ToList(): {(test5End - test5Start)} (Count: {newList1.Count})");

        }

    }
}
