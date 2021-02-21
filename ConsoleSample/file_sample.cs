using System;
using System.IO;
using System.Linq;

namespace ConsoleTest {

  class FileSample {
    public static void Run() {

      // usingとStreamWriterを使ってファイルへの書き込み
      using (var sw = new StreamWriter(@"C:\tmp\data.log")) {
        sw.WriteLine("samplesample");
      }
      // usingはブロックの後にDisposeを呼ぶのと同等
      var sw2 = new StreamWriter(@"C:\tmp\data2.log");
      try {
        sw2.WriteLine("sample2sample2");
      } finally {
        sw2.Dispose();
      }

      // StreamReaderを使ってファイルからの読み込み
      // ReadToEnd: 全部一気に読む
      using (var sr = new StreamReader(@"C:\tmp\sample.txt")) {
        Console.WriteLine("stream ReadToEnd: {0}", sr.ReadToEnd());
      }
      // ReadLine: 行ごとに読む
      using (var sr = new StreamReader(@"C:\tmp\sample.txt")) {
        while (!sr.EndOfStream) {

          Console.WriteLine("stream ReadLine: {0}", sr.ReadLine());
        }
      }
      // FileInfo: ファイル情報を取得
      var fileInfo = new FileInfo(@"C:\tmp\sample.txt");
      Console.WriteLine("Exists: {0}", fileInfo.Exists);
      Console.WriteLine("Name: {0}", fileInfo.Name);
      Console.WriteLine("DirectoryName: {0}", fileInfo.DirectoryName);
      Console.WriteLine("IsReadOnly: {0}", fileInfo.IsReadOnly);
      Console.WriteLine("LastAccessTime: {0}", fileInfo.LastAccessTime);
      Console.WriteLine("LastWriteTime: {0}", fileInfo.LastWriteTime);
      Console.WriteLine("Length: {0}", fileInfo.Length);

      // コピー
      fileInfo.CopyTo(@"C:\tmp\sample_copy.txt", true);

      // DirectoryInfo: ディレクトリ情報を表示
      var directoryInfo = new DirectoryInfo(@"C:\tmp\sample_dir");
      Console.WriteLine("Exists: {0}", directoryInfo.Exists);
      Console.WriteLine("Parent: {0}", directoryInfo.Parent);
      Console.WriteLine("Root: {0}", directoryInfo.Root);
      Console.WriteLine("CreationTime: {0}", directoryInfo.CreationTime);
      Console.WriteLine("LastAccessTime: {0}", directoryInfo.LastAccessTime);
      Console.WriteLine("LastWriteTime: {0}", directoryInfo.LastWriteTime);
      Console.WriteLine("GetDirectories Items: {0}",  string.Join(",", directoryInfo.GetDirectories().Select(d => d.FullName)));

      // サブディレクトリ作成
      directoryInfo.CreateSubdirectory("sub");

      // File: ファイル操作
      Console.WriteLine("File.Exists: {0}", File.Exists(@"C:\tmp\sample_copy.txt"));
      Console.WriteLine("File.GetLastAccessTime: {0}", File.GetLastAccessTime(@"C:\tmp\sample_copy.txt"));
      Console.WriteLine("File.ReadAllText: {0}", File.ReadAllText(@"C:\tmp\sample_copy.txt"));
      Console.WriteLine("File.GetAttributes: {0}", File.GetAttributes(@"C:\tmp\sample_copy.txt"));
      File.Delete(@"C:\tmp\sample_copy.txt");
      
      // Directory: ディレクトリ操作
      Console.WriteLine("Directory.Exists: {0}", Directory.Exists(@"C:\tmp\sample_dir\sub"));
      Console.WriteLine("Directory.GetParent: {0}", Directory.GetParent(@"C:\tmp\sample_dir\sub"));
      Console.WriteLine("Directory.GetLastAccessTime: {0}", Directory.GetLastAccessTime(@"C:\tmp\sample_dir\sub"));
      Console.WriteLine("Directory.GetFiles: {0}",  string.Join(",", Directory.GetFiles(@"C:\tmp\sample_dir\sub")));
      Directory.Delete(@"C:\tmp\sample_dir\sub");
    }
  }
}