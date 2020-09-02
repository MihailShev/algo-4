using System;
using System.Collections;
using System.Diagnostics;

namespace algo_4
{
    internal struct TestItem
    {
        public string Name;
        public IArray<int> Array;
        public int TestCount;
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
                    TestCount = 2,
                },
                new TestItem()
                {
                    Array = new VectorArray<int>(1000),
                    Name = "Vector array with vector value 1000",
                    TestCount = 6
                },
                new TestItem()
                {
                    Array = new VectorArray<int>(10000),
                    Name = "Vector array with vector value 10 000",
                    TestCount = 6
                },
                new TestItem()
                {
                    Array = new FactorArray<int>(2),
                    Name = "Factor array with factor value 2",
                },
                new TestItem()
                {
                    Array = new FactorArray<int>(4),
                    Name = "Factor array with factor value 4",
                },
                new TestItem()
                {
                    Array = new MatrixArray<int>(1000),
                    Name = "Matrix array with line size 1000"
                },
                new TestItem()
                {
                    Array = new MatrixArray<int>(10_000),
                    Name = "Matrix array with line size 10 000"
                },
                new TestItem()
                {
                    Array = new ArrayList<int>(),
                    Name = "List array"
                }
            };
            
            Test(testItems);
        }

        private static void Test(TestItem[] testItems)
        {
            var testValues = new[]{100_000, 200_000, 300_000, 1000_000, 2000_000, 3000_000, 10000_000};
           

            foreach (var item in testItems)
            {
                var maxTestCount = item.TestCount > 0 ? item.TestCount : testValues.Length;
                Console.Write(" \n*** Test: " + item.Name + " ***\n");
             
                for (var i = 0; i < testValues.Length && i < maxTestCount; i++)
                {
                    Console.WriteLine("Test №: " + i);
                    Console.WriteLine("Test values: " + testValues[i]);
                    TestAppend(item.Array, testValues[i]);
                    Console.WriteLine("-----------------");
                }
            }
        }

        private static void TestAppend(IArray<int> array, int total)
        {
           
            var watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < total; i++)
            {
                array.Append(i);
            }

            watch.Stop();
            var str = "Execution time: " + watch.ElapsedMilliseconds;
            Console.WriteLine(str);
        }
        
        
    }
}