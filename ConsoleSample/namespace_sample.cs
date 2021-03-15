// 静的クラスのインポート
using static System.Console;

// 別の名前空間
namespace AnotherNSSample {
  static class SampleClass {
    public static void Hello() {
      // インポートした静的クラスのメソッドを関数のように使える
      WriteLine("AnotherNSSample");
    }
  }
}