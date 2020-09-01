using System;
using System.Diagnostics;

namespace algo_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var singleArray = new SingleArray<int>();
            var vectorArray = new VectorArray<int>(500);
            var factorArray = new FactorArray<int>(2);
            var matrixArray = new MatrixArray<int>(10000);

            // TestAppend(singleArray, 10);
            // TestAppend(vectorArray, 10);
            // TestAppend(factorArray, 10);
            TestAppend(vectorArray, 500_000);
            TestAppend(factorArray, 1000_000);
            TestAppend(matrixArray, 1000_000);
        //     singleArray.Remove(7);
        //
        //     singleArray.Append(10);
        //     // vectorArray.AppendAt(11, 9);
        //     // factorArray.Remove(7);
        //     // matrixArray.Append(9);
        //     matrixArray.Remove(9);
        //     // Console.WriteLine(singleArray);    
        //     // Console.WriteLine(vectorArray);
        //     // Console.WriteLine(matrixArray);
        //
        // factorArray.Append(10);
        // // factorArray.Remove(5);
        //
        //     Console.WriteLine(vectorArray);
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