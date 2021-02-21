using System;

namespace ConsoleTest {

  class MathSample {
    public static void Run() {
      // 数学関数
      Console.WriteLine("Abs: {0}", Math.Abs(-1));
      Console.WriteLine("Acos: {0}", Math.Acos(1));
      Console.WriteLine("Acosh: {0}", Math.Acosh(1));
      Console.WriteLine("Asin: {0}", Math.Asin(1));
      Console.WriteLine("Asinh: {0}", Math.Asinh(1));
      Console.WriteLine("Min: {0}", Math.Min(3, 5));
      Console.WriteLine("Max: {0}", Math.Max(3, 5));
      Console.WriteLine("Sin: {0}", Math.Sin(Math.PI / 2));
      Console.WriteLine("Log10: {0}", Math.Log10(1000));
      Console.WriteLine("Round: {0}", Math.Round(153.53));
    }
  }
}