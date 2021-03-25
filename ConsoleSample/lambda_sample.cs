using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleTest {

  static class LambdaSample {

    public static void Run() {

      var l = new List<int>{2, 5, 3, 10, 66, 4, 23, 45};

      // ForEach: 各要素にそれぞれ実行
      l.ForEach(i => {
        Console.WriteLine($"ForEach: {i}");
      });
      // ConvertAll: 各要素に変換を適用
      Console.WriteLine(string.Join(",", l.ConvertAll(i => i.ToString("X2"))));
      // Find: 条件を満たす対象を見つける
      Console.WriteLine(l.Find(i => i >= 20));
      // なければデフォルト値
      Console.WriteLine(l.Find(i => i >= 80));
      // FindAll: すべて見つける
      Console.WriteLine(string.Join(",", l.FindAll(i => i >= 20)));
      Console.WriteLine(string.Join(",", l.FindAll(i => i >= 80)));
      // FindIndex: 条件を満たす対象のインデックスを返す
      Console.WriteLine(l.FindIndex(i => i >= 20));
      // なければ-1
      Console.WriteLine(l.FindIndex(i => i >= 80));
      // FindLastIndex: 後ろから探して条件を満たす対象のインデックスを返す
      Console.WriteLine(l.FindLastIndex(i => i >= 20));
      // Exists: 条件を満たすものがあるかどうか判定
      Console.WriteLine(l.Exists(i => i >= 20));
      // TrueForAll: すべての要素が条件を満たすか判定
      Console.WriteLine(l.TrueForAll(i => i >= 20));

      // メソッドチェーンでLINQ
      Console.WriteLine(string.Join(",", l.Where(i => i >= 20).OrderByDescending(i => i).Select(i => i.ToString("X4"))));
      // SQLのようなクエリ形式での検索も可能
      var queryResult = from i in l where i >= 20 orderby i descending select i.ToString("X4");
      Console.WriteLine(string.Join(",", queryResult));

      // Single: 条件を満たすものを1つだけ取得
      Console.WriteLine(l.Single(i => i > 50));

      // 複数あったり、1つも無かったりすると例外
      try {
        Console.WriteLine(l.Single(i => i > 2));
      } catch(InvalidOperationException ex) {
        Console.WriteLine(ex);
      }

      // SingleOrDefaultなら条件を満たさない場合にデフォルト値
      Console.WriteLine(l.SingleOrDefault(i => i < 0));
      
      // Select: 値をそれぞれ変換する
      Console.WriteLine(string.Join(",", l.Select(l => l * 2)));

      var points = new[] {
        new { X = 10, Y = 5},
        new { X = 10, Y = 2},
        new { X = 5, Y = 5},
        new { X = 8, Y = 5},
        new { X = 8, Y = 20},
        new { X = 10, Y = 6},
        new { X = 12, Y = 5},
      };
      // OrderBy, ThenBy: 昇順に並べ替える
      Console.WriteLine(string.Join(",", points.OrderBy(point => point.Y).ThenBy(point => point.X).Select(point => $"({point.X},{point.Y})")));
      // OrderByDescending, ThenByDescending: 降順に並べ替える
      Console.WriteLine(string.Join(",", points.OrderByDescending(point => point.Y).ThenByDescending(point => point.X).Select(point => $"({point.X},{point.Y})")));

      var a2 = new[] {3, 4, 2, 6, 4, 6, 2, 1};
      Console.WriteLine(string.Join(",", a2.Distinct()));

      // Take: 指定件数だけ取り出す
      Console.WriteLine(string.Join(",", l.Take(2)));
      // Skip: 指定件数だけ無視する
      Console.WriteLine(string.Join(",", l.Skip(2)));
      // First: 条件を満たす最初を取得
      Console.WriteLine(l.First(i => i > 20));
      try {
        // 条件を満たすものが無いと例外
        Console.WriteLine(l.First(i => i > 2000));
      } catch(InvalidOperationException ex) {
        Console.WriteLine(ex);
      }
      // FirstOrDefault: Firstと似ているが、条件を満たすものが無い場合デフォルト値
      Console.WriteLine(l.FirstOrDefault(i => i > 2000));

      // 逆にLast, LastOrDefaultもある
      Console.WriteLine(l.Last(i => i > 20));
      Console.WriteLine(l.LastOrDefault(i => i > 5));

      Console.WriteLine(string.Join(" ,", points.GroupBy(p => p.X).Select(pair => string.Join("_", pair))));


      var arr1 = new [] {
        new { Id = 1, Name = "aaa"},
        new { Id = 2, Name = "bbb"},
        new { Id = 3, Name = "ccc"},
        new { Id = 4, Name = "ddd"},
      };
      var arr2 = new [] {
        new { Id = 2, Value = 2000},
        new { Id = 3, Value = 1234},
      };
      var joined = arr1.Join(arr2, item1 => item1.Id, item2 => item2.Id, (a, b) => {
        return new {
          Id = a.Id,
          Name = a.Name,
          Value = b.Value,
        };
      });
      Console.WriteLine(string.Join(",", joined));
    }
  }

  // 右辺がブロックでない場合、ラムダ式でクラスメンバを定義できる
  class LambdaMemberTest {

    public LambdaMemberTest() => this._Val = 1000;

    public int Val {
      get => this._Val;
      set => this._Val = value;
    }
    private int _Val;

    public int DoubledVal => this.Val * 2;

    public string Test() => this.Val.ToString();

  }
}

