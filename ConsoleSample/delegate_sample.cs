using System;

namespace ConsoleTest {


  // デリゲートは、関数を型のように扱うことができる機能。
  // シグネチャ(戻り値の型、引数の個数と型)が一致する関数を変数に入れることができる。
  // delegateキーワードの後、関数のように指定する。
  delegate void TestDelegate(int i1, int i2);

  static class DelegateSample {

    public static void Run() {

      // 変数に入れることができる
      TestDelegate d = CalleeFunc;

      CallerFunc(d);

      // マルチキャストデリゲート
      // +=を使って複数の関数を一つの変数に入れることができる
      TestDelegate d2 = CalleeFunc;
      d2 += CalleeFunc2;

      CallerFunc(d2);

      // 匿名メソッドを使えばメソッド定義も不要
      CallerFunc(delegate (int i1, int i2) {
        Console.WriteLine($"Anon Method {i1} {i2}");
      });

      // ラムダ式でも同様
      ActionCaller((i) => {
        Console.WriteLine($"Lambda Func {i}");
      });

      var result = FuncCaller((i) => {
        return "Test Test" + i;
      });
      Console.WriteLine(result);
    }

    // 引数として渡すことができる
    static void CallerFunc(TestDelegate d) {
      d(100, 50);
    }

    static void CalleeFunc(int i1, int i2) {
      Console.WriteLine($"{i1}__{i2}");
    }

    static void CalleeFunc2(int i1, int i2) {
      Console.WriteLine($"{i1}:{i2}");
    }

    // 組み込みのデリゲートが使える。戻り値なしがAction
    static void ActionCaller(Action<int> act) {
      act(1000);
    }

    // 戻り値ありがFunc
    static string FuncCaller(Func<int, string> func) {
      return func(1000);
    }
  }
}