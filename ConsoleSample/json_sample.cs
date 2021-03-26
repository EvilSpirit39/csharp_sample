using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest {

  public static class JsonSample {

    public static void Run() {

      var sampleData = new {
        i = 100,
        s = "abcde",
        obj = new {
          a = 20,
          b = false,
        },
        a = new [] { 1, 3, 5}, 
      };

      var serialized = JsonSerializer.Serialize(sampleData);
      Console.WriteLine(serialized);

      var jsonStr = @"{
          ""A"": 1000,
          ""B"": ""dgereg"",
          ""C"": false
        }";
      
      var deserialized = JsonSerializer.Deserialize<SampleJsonSchema>(jsonStr);
      Console.WriteLine(string.Join(",", deserialized));
    }
  }

  class SampleJsonSchema {

    public int A {get; set;}

    public string B {get; set;}
    
    public bool C {get; set;}

    public override string ToString()
    {
      return $"{A} {B} {C}";
    }
  }
}