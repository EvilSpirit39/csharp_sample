using System;
using System.Linq;

namespace ConsoleTest {

  static class ArrayFuncSample {

    public static void Run() {
      var array0To10 = Enumerable.Range(3, 54).ToArray();

      var searchedIndex = Array.BinarySearch(array0To10, 30);
      Console.WriteLine("BinarySearch: {0}, {1}", searchedIndex, array0To10[searchedIndex]);

      var sampleArray1 = Enumerable.Range(1, 10).ToArray();
      Console.WriteLine("Before Clear: {0}", string.Join(",", sampleArray1));
      Array.Clear(sampleArray1, 3, 3);
      Console.WriteLine("After Clear: {0}", string.Join(",", sampleArray1));
      var sampleArray2 = Enumerable.Range(5, 10).ToArray();
      Console.WriteLine("Before Copy: {0}", string.Join(",", sampleArray2));
      Array.Copy(sampleArray1, sampleArray2, 5);
      Console.WriteLine("After Copy: {0}", string.Join(",", sampleArray2));
      Array.Resize(ref sampleArray2, 8);
      Console.WriteLine("Resize: {0}", string.Join(",", sampleArray2));
      Array.Reverse(sampleArray2);
      Console.WriteLine("Reverse: {0}", string.Join(",", sampleArray2));
      Array.Sort(sampleArray2);
      Console.WriteLine("Sort: {0}", string.Join(",", sampleArray2));
    }
  }
}