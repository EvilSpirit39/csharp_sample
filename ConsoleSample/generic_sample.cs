using System;
using System.Collections.Generic;

namespace ConsoleTest
{


  static class GenericSample
  {

    public static void Run()
    {
      var sample1 = new Test1<int>();
      Console.WriteLine(sample1.SampleFunc());
      var sample2 = new Test1<string>();
      Console.WriteLine(sample2.SampleFunc());

      IEnumerable<string> l1 = new List<string> { "a", "b", "c"};
      // IEnumerableの共変性により、IEnumerable<string> -> IEnumerable<object>への変換が可能
      IEnumerable<object> enuObj = l1;

      IComparable<object> c1 = new Comp();
      // IComparableの反変性により、IComparable<object> -> IComparable<string>への変換が可能
      IComparable<string> c2 = c1;

    }

  }
  class Test1<T>
  {

    public T SampleFunc()
    {
      T test = default;

      return test;
    }


  }

  // Genericの型を限定することが可能
  class Test2<T> where T : class, IComparable<T>, new()
  {

    public void Test(T arg)
    {

      // new() ならばコンストラクタが使える
      T test = new T();

      // IComparebleのメソッドが使える
      test.CompareTo(arg);
    }
  }

  class Comp : IComparable<object> {
    public int CompareTo(object val) {
      return 0;
    }
  }
}