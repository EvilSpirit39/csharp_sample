using System;

namespace ConsoleTest {

  public static class EventSample {

    public static void Run() {

      var evCaller = new EventCaller();

      evCaller.HandlerSample += (_, _) => {
        Console.WriteLine("Event Occurred 1");
      };

      evCaller.HandlerSample += (_, _) => {
        Console.WriteLine("Event Occurred 2");
      };

      evCaller.Test();

      // イベントは外部から呼び出すことはできない
      // 以下はエラーとなる
      // evCaller.HandlerSample(new object(), new EventArgs());
    }
  }

  public class EventCaller {

    public event EventHandler HandlerSample = (_, _) => {};

    public void Test() {

      HandlerSample(this, new EventArgs());
    }
  }
}