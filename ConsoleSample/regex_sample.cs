using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleTest {
  class RegexSample {

    public static void Run() {
      // 正規表現
      var regex = new Regex(@"([A-Z]+)-([A-Z]+)-([A-Z]+)");

      // Match: マッチする文字列を抜き出し
      var match1 = regex.Match("AAA-BBB-CCC");
      Console.WriteLine("Match(マッチする): {0} {1} {2} {3} {4}", match1.Success, match1.Index, match1.Value, match1.Length, match1.Name);
      foreach(var g in match1.Groups) {
        Console.WriteLine("group: {0}", g);
      }
      var match2 = regex.Match("ggggggg");
      Console.WriteLine("Match(マッチしない): {0} {1} {2} {3} {4}", match2.Success, match2.Index, match2.Value, match2.Length, match2.Name);

      // IsMatch: マッチするかどうか判定
      Console.WriteLine("IsMatch(マッチする): {0}", regex.IsMatch("332.445.abc"));
      Console.WriteLine("IsMatch(マッチしない): {0}", regex.IsMatch("ggggggg"));

      var regex2 = new Regex(@"[A-Z]+");
      var matches1 = regex2.Matches("ABC_DEF--423DFDF7GDA");
      Console.WriteLine("Matches: {0}", string.Join(" ", matches1));

      // 大文字小文字を無視する
      Console.WriteLine(new Regex("abcd", RegexOptions.IgnoreCase).Match("--aBcD---"));

      // 正規表現の置換
      Console.WriteLine(new Regex(@"[0-9]+").Replace("123   456", "ABCDE"));
      // ラムダ式を引き渡すとマッチ結果を変換
      Console.WriteLine(new Regex(@"[0-9]+").Replace("123   456", m => (int.Parse(m.Value) * 10).ToString()));

      // 正規表現で分割
      Console.WriteLine(string.Join(' ', new Regex(@"[0-9]+").Split("ABC12DEF4GHI")));
    }
  }
}
