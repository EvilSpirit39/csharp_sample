using System;
using System.Linq;
using System.IO;

namespace ConsoleTest
{
  class VariableSample {

    public static void Run() {
      // 変数宣言
      int data1;
      // 代入
      data1 = 100;
      Console.WriteLine("data1: {0}", data1);

      // 宣言と同時に代入
      int data2 = 200;
      Console.WriteLine("data2: {0}", data2);

      // 逐語的識別子(キーワードでも使える)
      int @if = 300;
      Console.WriteLine("if: {0}", @if);

      // 定数(変更不可)
      const string TEST_CONST = "test";
      Console.WriteLine("const: {0}", TEST_CONST);

      // さまざまな型
      bool variableBool = true;
      Console.WriteLine("bool: {0}", variableBool);
      char variableChar = 'a';
      Console.WriteLine("char: {0}", variableChar);
      sbyte variableSbyte = sbyte.MaxValue;
      Console.WriteLine("sbyte: {0}", variableSbyte);
      short variableShort = short.MaxValue;
      Console.WriteLine("short: {0}", variableShort);
      int variableInt = int.MaxValue;
      Console.WriteLine("int: {0}", variableInt);
      long variableLong = long.MaxValue;
      Console.WriteLine("long: {0}", variableLong);
      byte variableByte = byte.MaxValue;
      Console.WriteLine("byte: {0}", variableByte);
      ushort variableUshort = ushort.MaxValue;
      Console.WriteLine("ushort: {0}", variableUshort);
      uint variableUint = uint.MaxValue;
      Console.WriteLine("uint: {0}", variableUint);
      ulong variableUlong = ulong.MaxValue;
      Console.WriteLine("ulong: {0}", variableUlong);
      float variableFloat = float.MaxValue;
      Console.WriteLine("float: {0}", variableFloat);
      double variableDouble = double.MaxValue;
      Console.WriteLine("double: {0}", variableDouble);
      decimal variableDecimal = decimal.MaxValue;
      Console.WriteLine("decimal: {0}", variableDecimal);
      string variableString = "abcde";
      Console.WriteLine("string: {0}", variableString);
      object variableObj = new object();
      Console.WriteLine("object: {0}", variableObj);

      // オブジェクトは何でも入れられる
      object variableObj2 = 100;
      Console.WriteLine("object int: {0}", variableObj2);

      // 型推論
      var variable = "aaaaa";
      Console.WriteLine("var: {0}", variable);

      // 数値リテラルにセパレータを入れられる
      int separated = 123_456_789;
      Console.WriteLine("separated: {0}", separated);

      // 実数表記
      double real1 = .5e10;
      double real2 = .25e-8;
      Console.WriteLine("real: {0} {1}", real1, real2);

      // 型を決めるサフィックス
      long variableLong1 = 10L;
      uint variableUint1 = 10U;
      ulong variableUlong1 = 10UL;
      float variableFloat1 = 10F;
      double variableDouble1 = 10D;
      decimal variableDecimal1 = 10M;
      Console.WriteLine("literal: {0}, {1}, {2}, {3}, {4}, {5}", variableLong1, variableUint1, variableUlong1, variableFloat1, variableDouble1, variableDecimal1);

      // 文字リテラル
      char variableChar1 = '\u3042';
      Console.WriteLine(variableChar1);

      // 逐語的文字列リテラル
      Console.WriteLine(@"C:\Windows");

      // 変数展開
      var name = "John";
      Console.WriteLine($"Hello, {name}");

      // 逐語的+変数展開
      Console.WriteLine($@"C:\{name}");

      // キャスト
      int variableInt1 = 100;
      byte variableByte1 = (byte)variableInt1;
      Console.WriteLine(variableByte1);

      // 文字列から数値への変換
      Console.WriteLine("converted: {0}", int.Parse("100"));

      int converted1;
      var tryParseResult1 = int.TryParse("100", out converted1);
      Console.WriteLine("converted1: {0}, {1}", converted1, tryParseResult1);

      int converted2 = Convert.ToInt32("100");
      Console.WriteLine("converted2: {0}", converted2);

      // 変換できないケース
      try {
        int.Parse("Hello");
      } catch(FormatException e) {
        Console.WriteLine(e);
      }

      int converted3;
      var tryParseResult2 = int.TryParse("Hello", out converted3);
      Console.WriteLine("converted3: {0} {1}", converted3, tryParseResult2);

      try {
        Convert.ToInt32("Hello");
      } catch(FormatException e) {
        Console.WriteLine(e);
      }

      // インスタンス生成
      var fileInfo = new FileInfo("C:\\data");
      Console.WriteLine("fie Exists: {0}", fileInfo.Exists);

      // null
      string stringNull = null;
      Console.WriteLine("null: {0}", stringNull);

      // null条件演算子
      Console.WriteLine("null?.Trim(): {0}", stringNull?.Trim());
      Console.WriteLine("   abcd   ?.Trim(): {0}", "  abcd"?.Trim());

      // Nullable型
      int? variableNullable1 = 100;
      int? variableNullable2 = null;
      Console.WriteLine("nullable: {0}, {1}", variableNullable1, variableNullable2);

      // 配列
      var variableArray1 = new int[5];
      for(int i = 0; i < variableArray1.Length; ++i) {
        variableArray1[i] = i * 10;
      }
      Console.WriteLine("array: {0}, Length: {1}, Rank: {2}, UpperBound0: {3}", 
        variableArray1.Aggregate<int, string>(null, (acc, item) =>  acc != null ? acc + ", " + item.ToString() : item.ToString()), 
        variableArray1.Length,
        variableArray1.Rank,
        variableArray1.GetUpperBound(0));

      int[] variableArray2 = {2, 4, 6, 8, 10};
      Console.WriteLine("array: {0}", variableArray2.Aggregate<int, string>(null, (acc, item) =>  acc != null ? acc + ", " + item.ToString() : item.ToString()));
      
      var variableArray3 = new int[]{100, 200, 300};
      Console.WriteLine("array: {0}", variableArray3.Aggregate<int, string>(null, (acc, item) =>  acc != null ? acc + ", " + item.ToString() : item.ToString()));

      // 多次元配列
      int[,] multiDimArray = new int [3, 4];
      for (int i = 0; i <= multiDimArray.GetUpperBound(0); ++i) {
        for (int j = 0; j <= multiDimArray.GetUpperBound(1); ++j) {
          multiDimArray[i, j] = i * 10 + j;
        }
      }
      Console.WriteLine("multiDimArray: Length: {0}, Rank: {1}, UpperBound0: {2}, UpperBound1: {3}", 
        multiDimArray.Length, 
        multiDimArray.Rank, 
        multiDimArray.GetUpperBound(0), 
        multiDimArray.GetUpperBound(1));
      Console.WriteLine("multiDimArray [0,0]: {0}, [0,1]: {1}, [1,0]: {2}", multiDimArray[0,0], multiDimArray[0,1], multiDimArray[1,0]);

      var multiDimArray2 = new int [,] {
        {1, 8, 6},
        {2, 4, 3},
      };
      Console.WriteLine("multiDimArray2 [0,0]: {0}, [0,1]: {1}, [1,0]: {2}", multiDimArray2[0,0], multiDimArray2[0,1], multiDimArray2[1,0]);

      // ジャグ配列
      int[][] jagArray = new int[3][];
      jagArray[0] = new int[]{1, 2, 3, 4};
      jagArray[1] = new int[]{5, 6};
      jagArray[2] = new int[]{7, 8, 9};
      Console.WriteLine("jagArray [0][0]: {0}, [0][1]: {1}, [1][0]: {2}", jagArray[0][0], jagArray[0][1], jagArray[1][0]);

      // dynamic型: 動的型付けが可能な型
      dynamic dynamicVar;

      dynamicVar = "abc";
      Console.WriteLine($"{dynamicVar} {dynamicVar.Length}");
      dynamicVar = DateTime.Now;
      Console.WriteLine($"{dynamicVar} {dynamicVar.Year}");
    }
  }
}