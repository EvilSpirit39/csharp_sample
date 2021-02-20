using System;
using System.Globalization;

namespace ConsoleTest {

  class DateSample {

    public static void Run() {

      // Nowで現在日時
      Console.WriteLine(DateTime.Now);
      // Todayで現在日付のみ
      Console.WriteLine(DateTime.Today);
      // 明示的に指定
      Console.WriteLine(new DateTime(2000, 5, 10, 3, 40, 17));
      // Parse 
      Console.WriteLine(DateTime.Parse("2011-02-12 13:44:21"));
      // 読めないときはfalseを返すTryParse
      DateTime date1;
      var parseResult1 = DateTime.TryParse("2011-02-12 13:44:21", out date1);
      Console.WriteLine("Tryparse Result: {0} {1}",  parseResult1, date1);
      parseResult1 = DateTime.TryParse("aaaaaaaaaaa", out date1);
      Console.WriteLine("Tryparse Result: {0} {1}",  parseResult1, date1);
      // 書式を指定してParseExact
      Console.WriteLine("ParseExact: {0}", DateTime.ParseExact("20140522132142", "yyyyMMddHHmmss", CultureInfo.InvariantCulture));

      // 個別に取得
      var now = DateTime.Now;
      Console.WriteLine("Year: {0}", now.Year);
      Console.WriteLine("Month: {0}", now.Month);
      Console.WriteLine("Day: {0}", now.Day);
      Console.WriteLine("DayOfWeek: {0}", now.DayOfWeek);
      Console.WriteLine("Hour: {0}", now.Hour);
      Console.WriteLine("Minute: {0}", now.Minute);
      Console.WriteLine("Second: {0}", now.Second);
      Console.WriteLine("Millisecond: {0}", now.Millisecond);
      Console.WriteLine("Ticks: {0}", now.Ticks);
      Console.WriteLine("DayOfYear: {0}", now.DayOfYear);

      // 文字列化
      Console.WriteLine("toString(\"F\"): {0}", now.ToString("F"));
      // 和暦表示
      var japaneseCul = new CultureInfo("ja-JP");
      japaneseCul.DateTimeFormat.Calendar = new JapaneseCalendar();
      Console.WriteLine("和暦表示: {0}", now.ToString("ggyy", japaneseCul));
      // 日付操作
      Console.WriteLine("AddDays: {0}", now.AddDays(5));
      Console.WriteLine("DateTime.Add TimeSpan: {0}", now.Add(new TimeSpan(1, 2, 3)));
      Console.WriteLine("DateTime.Subtract TimeSpan: {0}", now.Subtract(new TimeSpan(1, 2, 3)));
      Console.WriteLine("DateTime.Subtract DateTime: {0}", now.Subtract(new DateTime(2021, 1, 2, 3, 4, 5)));
      // 演算子でも同様のことができる
      Console.WriteLine("DateTime + TimeSpan: {0}", now + new TimeSpan(1, 2, 3));
      Console.WriteLine("DateTime - TimeSpan: {0}", now - new TimeSpan(1, 2, 3));
      Console.WriteLine("DateTime - DateTime: {0}", now - new DateTime(2021, 1, 2, 3, 4, 5));
    }
  }
}