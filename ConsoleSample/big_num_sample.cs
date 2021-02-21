using System;
using System.Numerics;

namespace ConsoleTest {

  static class BigNumSample {

    public static void Run() {
      var l1 = 12345678901L;
      var l2 = 12345678901L;
      Console.WriteLine("long: {0}",  l1 * l2);
      Console.WriteLine("BigInteger: {0}",  new BigInteger(l1) * new BigInteger(l2));
    }
  }
}