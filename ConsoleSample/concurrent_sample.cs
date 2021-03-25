using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{

  static class ConcurrentSample
  {

    public static void Run()
    {
      CallThreads();
      CallTasks();
      Console.WriteLine(CountNoLock());
      CallTasksAsync().Wait();
    }

    private static void CallThreads()
    {
      var threads = new[] {
        new Thread(() => TestMethod("Thread_a", 100)),
        new Thread(() => TestMethod("Thread_b", 100)),
        new Thread(() => TestMethod("Thread_c", 100)),
      };

      foreach (var t in threads)
      {
        t.Start();
      }

      foreach (var t in threads)
      {
        t.Join();
      }
    }

    private static void CallTasks()
    {
      var tasks = new[]{
        Task.Run(() => TestMethod("Task_a", 100)),
       Task.Run(() => TestMethod("Task_b", 100)),
       Task.Run(() => TestMethod("Task_c", 100)),
      };

      Task.WaitAll(tasks);
    }

    private static async Task CallTasksAsync() {
      var tasks = new[]{
        Task.Run(() => TestMethod("Task_a", 100)),
       Task.Run(() => TestMethod("Task_b", 100)),
       Task.Run(() => TestMethod("Task_c", 100)),
      };

      foreach(var t in tasks) {
        await t;
      }
    }

    private static void TestMethod(string str, int count)
    {

      foreach (var val in Enumerable.Range(0, count))
      {
        Console.WriteLine($"{str}: {val}");
      }
    }

    private static int CountNoLock()
    {
      var t1 = Task.Run(() =>
      {
        foreach (var val in Enumerable.Range(0, 200))
        {
          lock(LockObj) {
            ++Count1;
          }
        }
      });
      var t2 = Task.Run(() =>
      {
        foreach (var val in Enumerable.Range(0, 200))
        {
          lock(LockObj) {
            ++Count1;
          }
        }
      });

      t1.Wait();
      t2.Wait();
      return Count1;
    }

    private static object LockObj = new object();

    private static int Count1 = 0;
  }
}