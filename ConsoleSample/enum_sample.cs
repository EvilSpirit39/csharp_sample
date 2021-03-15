using System;

namespace ConsoleTest {
  
  static class EnumSample {

    static public void Run() {

      Console.WriteLine(MonthEnum.Jan);

      Console.WriteLine((MonthEnum)3);

      Console.WriteLine(Enum.Parse<MonthEnum>("Apr"));

      Console.WriteLine(string.Join(",", Enum.GetValues<MonthEnum>()));

      Console.WriteLine(FlagEnum.FlagA | FlagEnum.FlagB);
    }
  }
  // 列挙型。数値の定数のグループを用意する
  enum MonthEnum {
    // 値を明示的に与えることもできる
    Jan = 1,
    // 明示しなければ順番の値となる
    Feb,
    Mar,
    Apr,
    May,
    Jun,
    Jul,
    Aug,
    Sep,
    Oct,
    Nov,
    Dec,

  }

  // ビットフィールド。 各ビットが意味を持つデータ
  // 型指定することでenumの元となる型を指定
  [Flags]
  enum FlagEnum : Byte {
    FlagA = 0x01,
    FlagB = 0x02,
    FlagC = 0x04,
  }
}