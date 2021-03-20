#define SAMPLE_DEF

using System;
using System.Text;
using System.Linq;

namespace ConsoleTest {

  class ControllSample {

    public static void Run() {

      var var1 = 1;

      // if文: trueの場合ifブロックを実行
      if (var1 == 1) {
        Console.WriteLine("var1 is 1");
      }
      if (var1 == 5) {
        Console.WriteLine("var1 is 5");
      }

      // if-else文: trueの場合ifブロックを、falseの場合elseブロックを実行
      if (var1 == 2) {
        Console.WriteLine("var1 is 2");
      } else {
        Console.WriteLine("var1 is not 2");
      }

      // if-else if...文: 複数の条件分岐の複合
      if (var1 == 3) {
        Console.WriteLine("var1 is 3");
      } else if (var1 == 4) {
        Console.WriteLine("var1 is 4");
      } else if (var1 == 1) {
        Console.WriteLine("var1 is 1");
      } else {
        Console.WriteLine("var1 is other");
      }

      // 注意: ブロックを省略すると次の行がif文の対象に
      if (var1 == 2)
        Console.WriteLine("var1 is 2");
      else 
        Console.WriteLine("var1 is not 2");


      // switch文: 値により分岐
      switch(var1) {
        case 1:
          Console.WriteLine("switch: var1 is 1");
          break;
        case 2:
          Console.WriteLine("switch: var1 is 2");
          break;
        default:
          Console.WriteLine("switch: var1 is other");
          break;
      }

      // フォールスルーは連続したcaseラベルのみ
      switch(var1) {
        case 1:
        case 2:
          Console.WriteLine("switch: var1 is 1 or 2");
          break;
        default:
          Console.WriteLine("switch: var1 is other");
          break;
      }

      // objectの型による分岐
      object obj1 = "sample";
      switch(obj1) {
        case int i:
          Console.WriteLine("integer {0}", i);
          break;
        case string s:
          Console.WriteLine("string {0}", s);
          break;
      }

      // objectを型で分岐し、更に条件を付ける
      object obj2 = 100;
      switch(obj2) {
        case int i when i < 10:
          Console.WriteLine("integer < 10: {0}", i);
          break;
        case int i when i >= 10:
          Console.WriteLine("integer >= 10: {0}", i);
          break;
        case string s:
          Console.WriteLine("string {0}", s);
          break;
      }


      // while文: 条件を満たす限りループ。最初から条件を満たさない場合一切実行されない
      var counter = 0;
      while (counter < 10) {
        Console.WriteLine("while counter: {0}", counter);
        ++counter;
      }
      Console.WriteLine("while Loop Finished");
      while (counter < 10) {
        Console.WriteLine("while counter: {0}", counter);
        ++counter;
      }
      Console.WriteLine("while Loop Finished");

      // do-while文: 判定をループの最後に行う。最初から条件を満たさない場合初回のみ実行される
      counter = 0;
      do {
        Console.WriteLine("while counter: {0}", counter);
        ++counter;
      } while (counter < 10);
      Console.WriteLine("while Loop Finished");
      do {
        Console.WriteLine("while counter: {0}", counter);
        ++counter;
      } while (counter < 10);
      Console.WriteLine("while Loop Finished");

      // for文: 初期化、条件、反復子を指定したループ
      for (int i = 0; i < 10; ++i) {
        Console.WriteLine("for loop i: {0}", i);
      }

      // foreach: リストなど、列挙可能なものを使ったループ
      var data = new string[] {"A", "B", "C"};
      foreach (var d in data) {
        Console.WriteLine("foreach: {0}", d);
      }

      // break: ループを脱出
      for (var i=0; i<30; ++i) {
        Console.WriteLine("for: {0}", i);
        if (i == 20) {
          Console.WriteLine("break");
          break;
        }
      }

      // continue: ループのその周回をスキップ
      for (var i=0; i<10; ++i) {
        if (i%2 == 0) {
          Console.WriteLine("continue");
          continue;
        }
        Console.WriteLine("for: {0}", i);
      }

      for (var i=0; i<10; ++i) {
        if (i == 5) {
          goto GOTO_LABEL;
        }
        Console.WriteLine("for: {0}", i);
      }

      GOTO_LABEL:
      Console.WriteLine("goto");

      // プリプロセッサ シンボルが定義されている場所のみ実行
#if SAMPLE_DEF
      Console.WriteLine("SAMPLE_DEF defined");
#else
      Console.WriteLine("SAMPLE_DEF not defined");
#endif


      // コードを折り畳みするための区間
#region 

      Console.WriteLine("in region");

#endregion
    }
  }
}