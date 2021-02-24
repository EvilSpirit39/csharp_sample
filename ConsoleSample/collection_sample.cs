using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest {

  public static class CollectionSample {

    public static void Run() {

      // 初期化
      var list1 = new List<string>{"a", "b", "c"};
      Console.WriteLine("List: {0}", string.Join(",", list1));
      var dict1 = new Dictionary<string, int>{
        ["aaa"] = 1,
        ["bbb"] = 6,
        ["ccc"] = 5,
      };
      Console.WriteLine("Dictionary: {0}", string.Join(",", dict1.Select(kv => $"{kv.Key}-{kv.Value}")));

      // foreachで列挙できる
      foreach (var v in list1) {
        Console.WriteLine("foreach : {0}", v);
      }
      // 等価なwhileのコード
      var enu = list1.GetEnumerator();
      while (enu.MoveNext()) {
        var v = enu.Current;
        Console.WriteLine("while: {0}", v);
      }

      // List: サイズ可変のリスト
      Console.WriteLine("GetRange: {0}", string.Join(",", list1.GetRange(1, 2)));

      Console.WriteLine("Capacity: {0}", list1.Capacity);

      Console.WriteLine("Count: {0}", list1.Count);

      list1.Add("newItem");
      Console.WriteLine("After Add: {0}", string.Join(",", list1));

      list1.AddRange(new string[]{"newItem1", "newItem2", "newItem3"});
      Console.WriteLine("After AddRange: {0}", string.Join(",", list1));

      list1.Insert(3, "insertItem");
      Console.WriteLine("After Insert: {0}", string.Join(",", list1));

      Console.WriteLine("Contains: {0}", list1.Contains("c"));

      Console.WriteLine("IndexOf: {0}", list1.IndexOf("c"));

      list1.Reverse();
      Console.WriteLine("After Reverse: {0}", string.Join(",", list1));

      list1.Sort();
      Console.WriteLine("After Sort: {0}", string.Join(",", list1));

      list1.Remove("newItem1");
      Console.WriteLine("After Remove: {0}", string.Join(",", list1));

      list1.RemoveRange(2, 3);
      Console.WriteLine("After RemoveRange: {0}", string.Join(",", list1));

      list1.Clear();
      Console.WriteLine("After Clear: {0}", string.Join(",", list1));

      // LinkedList 連結リスト
      var linkedList1 = new LinkedList<string>();
      linkedList1.AddLast("aaa");
      linkedList1.AddLast("bbb");
      linkedList1.AddLast("ccc");
      Console.WriteLine("LinkedList: {0}", string.Join(",", linkedList1));

      Console.WriteLine("Count: {0}", linkedList1.Count);

      Console.WriteLine("Contains: {0}", linkedList1.Contains("ccc"));

      Console.WriteLine("First.Value: {0}", linkedList1.First.Value);

      Console.WriteLine("Last.Value: {0}", linkedList1.Last.Value);

      linkedList1.AddFirst("newItem");
      Console.WriteLine("After AddFirst: {0}", string.Join(",", linkedList1));

      linkedList1.AddAfter(linkedList1.First, "insertItem");
      Console.WriteLine("After AddAfter: {0}", string.Join(",", linkedList1));

      linkedList1.RemoveFirst();
      Console.WriteLine("After RemoveFirst: {0}", string.Join(",", linkedList1));

      linkedList1.Clear();
      Console.WriteLine("After Clear: {0}", string.Join(",", linkedList1));

      // Stack スタック。先入後出のデータ構造
      var stack1 = new Stack<string>();
      stack1.Push("aaa");
      stack1.Push("bbb");
      stack1.Push("ccc");
      Console.WriteLine("Stack: {0}", string.Join(",", stack1));

      Console.WriteLine("Peek: {0}", stack1.Peek());

      Console.WriteLine("Contains: {0}", stack1.Contains("bbb"));

      Console.WriteLine("Pop: {0}", stack1.Pop());
      Console.WriteLine("After Pop: {0}", string.Join(",", stack1));

      // Queue キュー。先入先出のデータ構造
      var queue1 = new Queue<string>();
      queue1.Enqueue("aaa");
      queue1.Enqueue("bbb");
      queue1.Enqueue("ccc");
      Console.WriteLine("Queue: {0}", string.Join(",", queue1));

      Console.WriteLine("Peek: {0}", queue1.Peek());

      Console.WriteLine("Contains: {0}", queue1.Contains("bbb"));

      Console.WriteLine("Dequeue: {0}", queue1.Dequeue());
      Console.WriteLine("After Dequeue: {0}", string.Join(",", queue1));

      // HashSet 重複を許さない集合。
      var hashSet1 = new HashSet<string>{"aaa", "bbb", "ccc"};
      Console.WriteLine("HashSet: {0}", string.Join(",", hashSet1));

      Console.WriteLine("Add(存在しないデータ): {0}", hashSet1.Add("ddd"));
      Console.WriteLine("Add(存在するデータ): {0}", hashSet1.Add("bbb"));
      Console.WriteLine("After Add: {0}", string.Join(",", hashSet1));
      hashSet1.Remove("bbb");
      Console.WriteLine("After Remove: {0}", string.Join(",", hashSet1));

      var hashSet2 = new HashSet<string>{"a", "aa", "aaa", "aaaa", "aaaaa"};

      hashSet1.ExceptWith(hashSet2);
      Console.WriteLine("After ExceptWith: {0}", string.Join(",", hashSet1));

      hashSet1.UnionWith(hashSet2);
      Console.WriteLine("After UnionWith: {0}", string.Join(",", hashSet1));

      Console.WriteLine("IsSupersetOf: {0}", hashSet1.IsSupersetOf(hashSet2));
      Console.WriteLine("IsSubsetOf: {0}", hashSet1.IsSubsetOf(hashSet2));

      // SortedSet ソート済の集合。
      var sortedSet1 = new SortedSet<string>{"a", "dfdf", "bb", "fer", "zzz", "AB", "faa"};
      Console.WriteLine("SortedSet: {0}", string.Join(",", sortedSet1));
      Console.WriteLine("Min: {0}", sortedSet1.Min);
      Console.WriteLine("Max: {0}", sortedSet1.Max);

      // Dictionary キーバリューペア
      Console.WriteLine("Dictionary: {0}", string.Join(",", dict1.Select(kv => $"{kv.Key}-{kv.Value}")));

      Console.WriteLine("Count: {0}", dict1.Count);

      dict1.Add("newKey", 3000);
      Console.WriteLine("After Add: {0}", string.Join(",", dict1.Select(kv => $"{kv.Key}-{kv.Value}")));

      dict1.Remove("bbb");
      Console.WriteLine("After Remove: {0}", string.Join(",", dict1.Select(kv => $"{kv.Key}-{kv.Value}")));

      Console.WriteLine("ContainsKey: {0}", dict1.ContainsKey("ccc"));

      Console.WriteLine("ContainsValue: {0}", dict1.ContainsValue(5));

      // SortedDictionary ソート済Dicrionary
      var sortedDict1 = new SortedDictionary<string, int>{
        ["abc"] = 1,
        ["def"] = 3,
        ["AAA"] = 2,
        ["bdgd"] = 4,
        ["bae"] = 3,
      };

      Console.WriteLine("SortedDictionary: {0}", string.Join(",", sortedDict1.Select(kv => $"{kv.Key}-{kv.Value}")));

      var sortedList1 = new SortedList<string, int>{
        ["abc"] = 1,
        ["def"] = 3,
        ["AAA"] = 2,
        ["bdgd"] = 4,
        ["bae"] = 3,
      };

      Console.WriteLine("SortedList: {0}", string.Join(",", sortedList1.Select(kv => $"{kv.Key}-{kv.Value}")));
    }
  }
}