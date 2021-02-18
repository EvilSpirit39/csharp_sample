using System;
using System.Globalization;
using System.Linq;

namespace ConsoleTest {

  class StringSample {

    public static void Run() {
      // Length: 長さを測る
      Console.WriteLine("\"あいうえお\".Length: {0}", "あいうえお".Length);

      // Compare: 辞書順の前後を判定、 StringComparison: 大文字小文字の判定有無を設定
      Console.WriteLine("大文字小文字区別する場合: {0}", string.Compare("abcde", "ABCDE"));
      Console.WriteLine("大文字小文字区別しない場合: {0}", string.Compare("abcde", "ABCDE", StringComparison.OrdinalIgnoreCase));

      // CompareInfo.Compare: 半角全角や、ひらがなカタカナの判定を含む比較
      // CompareOptions: 判定での区別有無を指定
      var ci = CultureInfo.InvariantCulture.CompareInfo;
      Console.WriteLine("半角全角を区別する場合: {0}", ci.Compare("ＡＢＣＤＥ", "ABCDE", CompareOptions.None));
      Console.WriteLine("半角全角を区別しない場合: {0}", ci.Compare("ＡＢＣＤＥ", "ABCDE", CompareOptions.IgnoreWidth));

      Console.WriteLine("ひらがなカタカナを区別する場合: {0}", ci.Compare("あいうえお", "アイウエオ", CompareOptions.None));
      Console.WriteLine("ひらがなカタカナを区別しない場合: {0}", ci.Compare("あいうえお", "アイウエオ", CompareOptions.IgnoreKanaType));

      // IsNullOrEmpty: nullか空文字列を判定する
      // IsNullOrWhiteSpace: 上記に加え、空白のみの文字列も判定する
      Console.WriteLine("nullの場合: IsNullOrEmpty -> {0}, IsNullOrWhiteSpace -> {1}", String.IsNullOrEmpty(null), String.IsNullOrWhiteSpace(null));
      Console.WriteLine("空文字列の場合: IsNullOrEmpty -> {0}, IsNullOrWhiteSpace -> {1}", String.IsNullOrEmpty(""), String.IsNullOrWhiteSpace(""));
      Console.WriteLine("半角スペースの場合: IsNullOrEmpty -> {0}, IsNullOrWhiteSpace -> {1}", String.IsNullOrEmpty(" "), String.IsNullOrWhiteSpace(" "));
      Console.WriteLine("全角スペースの場合: IsNullOrEmpty -> {0}, IsNullOrWhiteSpace -> {1}", String.IsNullOrEmpty("　"), String.IsNullOrWhiteSpace("　"));
      Console.WriteLine("タブ文字の場合: IsNullOrEmpty -> {0}, IsNullOrWhiteSpace -> {1}", String.IsNullOrEmpty("\t"), String.IsNullOrWhiteSpace("\t"));
      Console.WriteLine("aの場合: IsNullOrEmpty -> {0}, IsNullOrWhiteSpace -> {1}", String.IsNullOrEmpty("a"), String.IsNullOrWhiteSpace("a"));
      Console.WriteLine("  aの場合: IsNullOrEmpty -> {0}, IsNullOrWhiteSpace -> {1}", String.IsNullOrEmpty("  a"), String.IsNullOrWhiteSpace("  a"));

      // IndexOf: 指定文字列を先頭から検索して位置を返す。-1は見つからなかった場合
      Console.WriteLine("IndexOf(見つかる場合): {0}", "abcdefghabcdefgh".IndexOf("def"));
      Console.WriteLine("LastIndexOf(見つかる場合): {0}", "abcdefghabcdefgh".LastIndexOf("def"));
      Console.WriteLine("IndexOf(見つからない場合): {0}", "abcdefghabcdefgh".IndexOf("aaaa"));
      Console.WriteLine("LastIndexOf(見つからない場合): {0}", "abcdefghabcdefgh".LastIndexOf("aaaa"));
      Console.WriteLine("IndexOf(範囲指定5～13文字目): {0}", "abcdefghabcdefgh".IndexOf("def", 4, 9));
      Console.WriteLine("IndexOf(範囲指定5～14文字目): {0}", "abcdefghabcdefgh".IndexOf("def", 4, 10));

      // Contains: 引数で与える文字列が含まれるか
      Console.WriteLine("Contains(含まれる): {0}", "abcde".Contains("bcd"));
      Console.WriteLine("Contains(含まれない): {0}", "bcd".Contains("abcde"));
      // StartsWith: 引数で与える文字列で始まるか
      Console.WriteLine("StartsWith(始まる場合):{0}", "abc".StartsWith("ab"));
      Console.WriteLine("StartsWith(始まらない場合):{0}", "abc".StartsWith("b"));
      // EndsWith: 引数で与える文字列で終わる
      Console.WriteLine("EndsWith(終わる場合):{0}", "abc".EndsWith("bc"));
      Console.WriteLine("EndsWith(終わらない場合):{0}", "abc".StartsWith("b"));

      // 文字関数
      // IsDigit(数字[0-9]か)
      Console.WriteLine("Char.IsDigit('a'): {0}", Char.IsDigit('a'));
      Console.WriteLine("Char.IsDigit('0'): {0}", Char.IsDigit('0'));
      Console.WriteLine("Char.IsDigit('①'): {0}", Char.IsDigit('①'));
      // IsNumber(より広い範囲で数値か(①など))
      Console.WriteLine("Char.IsNumber('a'): {0}", Char.IsNumber('a'));
      Console.WriteLine("Char.IsNumber('0'): {0}", Char.IsNumber('0'));
      Console.WriteLine("Char.IsNumber('①'): {0}", Char.IsNumber('①'));
      // IsLetter(文字か)
      Console.WriteLine("Char.IsLetter('a'): {0}", Char.IsLetter('a'));
      Console.WriteLine("Char.IsLetter(' '): {0}", Char.IsLetter(' '));
      // IsWhiteSpace(空白か)
      Console.WriteLine("Char.IsWhiteSpace('a'): {0}", Char.IsWhiteSpace('a'));
      Console.WriteLine("Char.IsWhiteSpace(' '): {0}", Char.IsWhiteSpace(' '));
      // IsControl(制御文字か)
      Console.WriteLine("Char.IsControl('a'): {0}", Char.IsControl('a'));
      Console.WriteLine("Char.IsControl('\t'): {0}", Char.IsControl('\t'));
      // IsLower(小文字か)
      Console.WriteLine("Char.IsLower('a'): {0}", Char.IsLower('a'));
      Console.WriteLine("Char.IsLower('A'): {0}", Char.IsLower('A'));
      // IsUpper(大文字か)
      Console.WriteLine("Char.IsUpper('a'): {0}", Char.IsUpper('a'));
      Console.WriteLine("Char.IsUpper('A'): {0}", Char.IsUpper('A'));

      // 文字列にLinqが使える
      Console.WriteLine("文字列にWを含むか: {0}", "HelloWorld".Any(c => c == 'W'));

      // 部分文字列の取得
      Console.WriteLine("部分文字列: {0}", "abcdefg".Substring(1, 3));
      // ブラケット構文で文字取得
      Console.WriteLine("文字を取得: {0}", "abcdefg"[1]);
      // Splitで分割
      var splitted = "abc,def,ghi".Split(',');
      foreach(var s in splitted) {
        Console.WriteLine(s);
      }
      // Joinで結合
      Console.WriteLine(string.Join("|||", splitted));
      // 複数の文字を指定
      Console.WriteLine(string.Join("|||", "abc.,ghi,jkl.,.".Split(new char[]{'.', ','})));
      // カウントを指定
      Console.WriteLine(string.Join("|||", "abc.,ghi,jkl.,.".Split(new char[]{'.', ','}, 3)));
      // 空白文字列を除去するオプション
      Console.WriteLine(string.Join("|||", "abc.,ghi,jkl.,.".Split(new char[]{'.', ','}, 3, StringSplitOptions.RemoveEmptyEntries)));

      // Formatで整形
      Console.WriteLine(string.Format("Format Sample: {0} {1} {2}", 100, 1.5, "abcd"));

    }
  }
}