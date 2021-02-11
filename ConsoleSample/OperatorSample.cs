
using System;
using System.Text;
using System.Linq;

namespace ConsoleTest {

  class OperatorSample {

    public static void Run() {
      // 演算子サンプル
      Console.WriteLine("9 + 4 = {0}", 9 + 4);
      Console.WriteLine("9 - 4 = {0}", 9 - 4);
      Console.WriteLine("9 * 4 = {0}", 9 * 4);
      Console.WriteLine("9 / 4 = {0}", 9 / 4);
      Console.WriteLine("9 % 4 = {0}", 9 % 4);

      // インクリメント、デクリメント
      int sampleVal = 0;
      Console.WriteLine("sampleVal: {0}", sampleVal);
      Console.WriteLine("++sampleVal: {0}", ++sampleVal);
      Console.WriteLine("sampleVal: {0}", sampleVal);
      Console.WriteLine("sampleVal++: {0}", sampleVal++);
      Console.WriteLine("sampleVal: {0}", sampleVal);
      Console.WriteLine("--sampleVal: {0}", --sampleVal);
      Console.WriteLine("sampleVal: {0}", sampleVal);
      Console.WriteLine("sampleVal--: {0}", sampleVal--);
      Console.WriteLine("sampleVal: {0}", sampleVal);

      // 文字列連結
      Console.WriteLine("\"Hello\" + \"World\": {0}", "Hello" + "World");

      // 除算と型
      Console.WriteLine("3 / 4 = {0}", 3 / 4);
      Console.WriteLine("3d / 4 = {0}", 3d / 4);
      // ゼロ除算
      int zero = 0;
      try {
        Console.WriteLine("3 / 0 = {0}", 3 / zero);
      } catch (DivideByZeroException e) {
        Console.WriteLine(e);
      }
      try {
        Console.WriteLine("3 % 0 = {0}", 3 % zero);
      } catch (DivideByZeroException e) {
        Console.WriteLine(e);
      }
      Console.WriteLine("3d / 0 = {0}", 3d / 0);
      Console.WriteLine("3d % 0 = {0}", 3d % 0);

      // 浮動小数点誤差
      Console.WriteLine("Math.Floor((0.7 + 0.1) * 10): {0}" , Math.Floor((0.7 + 0.1) * 10));
      Console.WriteLine("0.2 * 3 == 0.6: {0}", 0.2 * 3 == 0.6);
      Console.WriteLine("Math.Floor((0.7M + 0.1M) * 10): {0}" , Math.Floor((0.7M + 0.1M) * 10));
      Console.WriteLine("0.2M * 3 == 0.6M: {0}", 0.2M * 3 == 0.6M);

      // 代入
      int x;
      x = 0;
      Console.WriteLine("x = 0: {0}", x);
      x += 10;
      Console.WriteLine("x += 10: {0}", x);
      x -= 2;
      Console.WriteLine("x += 2: {0}", x);
      x *= 5;
      Console.WriteLine("x *= 5: {0}", x);
      x /= 2;
      Console.WriteLine("x /= 2: {0}", x);
      x %= 3;
      Console.WriteLine("x %= 3: {0}", x);
      x &= 0x02;
      Console.WriteLine("x &= 0x02: {0}", x);
      x |= 0x08;
      Console.WriteLine("x |= 0x08: {0}", x);
      x ^= 0x10;
      Console.WriteLine("x ^= 0x10: {0}", x);
      x <<= 1;
      Console.WriteLine("x <<= 1: {0}", x);
      x >>= 1;
      Console.WriteLine("x >>= 1: {0}", x);

      // 値型と参照型の代入の違い
      var val1 = 10;
      var val2 = val1;
      val2 += 5;
      Console.WriteLine("val1: {0}, val2: {1}", val1, val2);
      var arr1 = new int[]{10};
      var arr2 = arr1;
      arr2[0] += 5;
      Console.WriteLine("arr1[0]: {0}, arr2[0]: {1}", arr1[0], arr2[0]);

      // 関係演算子
      Console.WriteLine("5 == 5: {0}", 5 == 5);
      Console.WriteLine("5 != 5: {0}", 5 != 5);
      Console.WriteLine("5 < 6: {0}", 5 < 6);
      Console.WriteLine("5 > 6: {0}", 5 > 6);
      Console.WriteLine("5 <= 6: {0}", 5 <= 6);
      Console.WriteLine("5 >= 6: {0}", 5 >= 6);
      Console.WriteLine("True ? 3 : 5: {0}", true ? 3 : 5);
      Console.WriteLine("null ?? \"ABC\": {0}", null ?? "ABC");

      // Equalsとの違い
      var builder1 = new StringBuilder("abc");
      var builder2 = new StringBuilder("abc");
      Console.WriteLine("compare by ==: {0}", builder1 == builder2);
      Console.WriteLine("compare by Equals: {0}", builder1.Equals(builder2));

      // SequenceEqual
      Console.WriteLine("SequenceEqual Test: {0}", (new int[]{1, 2, 3}).SequenceEqual(new int[]{1, 2, 3}));

      // 論理演算子
      Console.WriteLine("true && false: {0}", true && false);
      Console.WriteLine("true || false: {0}", true || false);
      Console.WriteLine("true ^ true: {0}", true ^ true);
      Console.WriteLine("!true: {0}", !true);

      // 短絡演算
      string str1 = null;
      // && だと短絡評価される
      if (str1 != null && str1.StartsWith("abc")) {
        // 通らない 
      } else {
        Console.WriteLine("not starts with abc");
      }
      try {
        // & だと短絡評価されない
        if (str1 != null & str1.StartsWith("abc")) {
          // 通らない 
        } else {
          // こちらも通らない
        }
      } catch (NullReferenceException e) {
        // 例外になる
        Console.WriteLine("null reference exception", e);
      }


      // ビット演算子
      Console.WriteLine("2 & 1: {0}", 2 & 1);
      Console.WriteLine("2 | 1: {0}", 2 | 1);
      Console.WriteLine("2 ^ 1: {0}", 2 ^ 1);
      Console.WriteLine("~2: {0}", ~2);
      Console.WriteLine("2<<1: {0}", 2 << 1);
      Console.WriteLine("2>>1: {0}", 2 >> 1);

      // sizeof
      Console.WriteLine("sizeof(int): {0}", sizeof(int));
      Console.WriteLine("sizeof(decimal): {0}", sizeof(decimal));

      Console.WriteLine("nameof(Console): {0}", nameof(Console));
    }

  }
}