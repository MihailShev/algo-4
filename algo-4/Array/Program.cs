using System;
using System.Collections;
using System.Diagnostics;

namespace algo_4
{
    internal struct TestItem
    {
        public string Name;
        public IArray<int> Array;
        public int TestAddCount;
        public int TestDeleteCount;
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var testItems = new TestItem[]
            {
                new TestItem()
                {
                    Array = new SingleArray<int>(),
                    Name = "Single array",
                    TestAddCount = 3,
                    TestDeleteCount = 3,
                },
                new TestItem()
                {
                    Array = new VectorArray<int>(1000),
                    Name = "Vector array with vector value 1000",
                    TestDeleteCount = 4,
                },
                new TestItem()
                {
                    Array = new VectorArray<int>(10000),
                    Name = "Vector array with vector value 10 000",
                    TestAddCount = 7,
                    TestDeleteCount = 4,
                },
                new TestItem()
                {
                    Array = new FactorArray<int>(2),
                    Name = "Factor array with factor value 2",
                    TestDeleteCount = 4,
                },
                new TestItem()
                {
                    Array = new FactorArray<int>(4),
                    Name = "Factor array with factor value 4",
                    TestDeleteCount = 4,
                },
                new TestItem()
                {
                    Array = new MatrixArray<int>(1000),
                    Name = "Matrix array with line size 1000",
                    TestDeleteCount = 3,
                },
                new TestItem()
                {
                    Array = new MatrixArray<int>(10_000),
                    Name = "Matrix array with line size 10 000",
                    TestDeleteCount = 3,
                },
                new TestItem()
                {
                    Array = new ArrayList<int>(),
                    Name = "List array",
                    TestDeleteCount = 4,
                }
            };
            
            Test(testItems);
        }

        private static void Test(TestItem[] testItems)
        {
            var testValues = new[] {100_000, 200_000, 300_000, 1000_000, 2000_000, 3000_000, 10000_000};


            foreach (var item in testItems)
            {
                var maxTestCount = item.TestAddCount > 0 ? item.TestAddCount : testValues.Length;
                Console.Write(" \n*** Test: " + item.Name + " ***\n");

                for (var i = 0; i < testValues.Length && i < maxTestCount; i++)
                {
                    Console.WriteLine("Test №: " + (i + 1));
                    Console.WriteLine("Test values: " + testValues[i]);
                    AddElements(item.Array, testValues[i]);
                    if (i < item.TestDeleteCount)
                    {
                        RemoveElements(item.Array);
                    }
                    else
                    {
                        item.Array.Clear();
                    }
                    Console.WriteLine("-----------------");
                }
            }
        }
        
        private static void RemoveElements(IArray<int> array)
        {
            var watch = new Stopwatch();
            watch.Start();
          
            while (array.Size > 0)
            {
                var index = array.Size / 2;
                array.Remove(index > 0 ? index : 0);
            }
            watch.Stop();
            PrintExecutionTime("Delete", watch);
        }

        private static void AddElements(IArray<int> array, int total)
        {
            var watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < total; i++)
            {
                array.Append(i);
            }

            watch.Stop();
            PrintExecutionTime("Add", watch);
        }

        private static void PrintExecutionTime(string operation, Stopwatch watch)
        {
            var str = operation +  " time: " + watch.ElapsedMilliseconds;
            Console.WriteLine(str);
        }
    }
}