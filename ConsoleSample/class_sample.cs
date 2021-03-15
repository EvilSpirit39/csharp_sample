using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace ConsoleTest {

  public static class ClassSample {

    public static void Run() {

      var a = new PublicClassA(10, "aaa");
      Console.WriteLine("Public Field: {0}", a.Field1);
      Console.WriteLine("Internal Field: {0}", a.Field4);
      Console.WriteLine("Static Field: {0}", PublicClassA.StaticField1);
      Console.WriteLine("Public Method: {0}", a.Hello());

      Console.WriteLine("Beep: {0}", PublicClassA.Beep(1000, 500));

      // ローカル関数
      int LocalFunc(int x) {
        return x * 2;
      }

      Console.WriteLine("LocalFunc: {0}", LocalFunc(2));

      // Disposableクラスのテスト
      using (var d = new DisposableSample()) { 

      }


      Console.WriteLine("Static Method: {0}", PublicClassA.StaticMethod());
      // 引数を明示指定も可能
      Console.WriteLine("x(1000) - y(100): {0}", a.Subtract(y: 100, x: 1000));
      // 引数を省略するとデフォルト値 
      a.Greet();
      // 可変長引数
      Console.WriteLine("Sum(1, 2, 3): {0}", a.Sum(1, 2, 3));

      int valByVal = 1;
      int valByRef = 1;
      int[] refByVal = new int[]{1};
      int[] refByRef = new int[]{1};

      PublicClassA.ArgumentTest(valByVal, ref valByRef, refByVal, ref refByRef);
      Console.WriteLine($"after func: {valByVal} {valByRef} {refByVal[0]} {refByRef[0]}");

      var testIntArray = new int[]{1, 3, 4};
      var result1 = PublicClassA.ReturnRef(testIntArray);
      Console.WriteLine($"ReturnRef: {result1}");

      PublicClassA.Multiple2(100, out var multipleResult);
      Console.WriteLine($"out variable: {multipleResult}");
      Console.WriteLine("Tuple: {0}", PublicClassA.GetMinMax(new int[]{100, 35, 32, 56, 43, 523, 112, 446}));

      // 匿名型
      var anonTypeSample = new { X = 100, Y = 200 };
      Console.WriteLine($"Anon Type {anonTypeSample}");

      // プロパティ
      a.PropTest = 100;
      Console.WriteLine($"PropTest: {a.PropTest}");
      Console.WriteLine($"PropTest2: {a.PropTest2}");

      // インデクサ
      var indexer = new IndexerSample(10);
      Console.WriteLine($"IndexerSample: {indexer[3]}");
      // yieldによる列挙
      Console.WriteLine("Iterator: {0}", string.Join(",", PublicClassA.IteratorSample));

      // 継承
      var derivedSample = new DerivedClassSample(20);
      var castedBaseSample = derivedSample as BaseClassSample;
      derivedSample.Method1();
      castedBaseSample.Method1();
      derivedSample.Method2();
      castedBaseSample.Method2();

      // ダウンキャスト
      var downCast1 = (BaseClassSample)derivedSample;
      // asでも可能
      var downCast2 = derivedSample as BaseClassSample;
      // isでも可能
      if (derivedSample is BaseClassSample downCast3) {
        Console.WriteLine("Cast Success!"); 
      }

      // アップキャスト
      var baseSample  = new BaseClassSample(1);
      try {
        // キャスト不能な場合失敗
        var failCast1 = (DerivedClassSample)baseSample;
      } catch(InvalidCastException ex) {
        Console.WriteLine(ex);
      }
      // as の場合はnullとなる
      var failCast2 = baseSample as DerivedClassSample;
      Console.WriteLine("cast Failed? {0}", failCast2 == null);
      if (baseSample is DerivedClassSample failcast3) {
        Console.WriteLine("Cast Success!"); 
      } else {
        Console.WriteLine("Cast Failure!"); 
      }
      // 型を取得
      var t = typeof(BaseClassSample);
      Console.WriteLine("typeof(BaseClassSample): {0}", t);

      // 拡張メソッド
      Console.WriteLine(1.IsEven());
      // 抽象クラスを継承したもの
      new OverrideSample().Test();

      // 例外処理
      try {
        PublicClassA.ThrowExSample(null);
      } catch(ArgumentNullException ex) {
        Console.WriteLine(ex);
      } finally {
        // finallyは必ず実行
        Console.WriteLine("finally!");
      }

      int overflowCheckTest = int.MaxValue;

      try {
        checked {
          ++overflowCheckTest;
        }
      } catch (OverflowException ex) {
        Console.WriteLine(ex);
      }
      Console.WriteLine($"overflow checked: {overflowCheckTest}");

      int overflowUncheckTest = int.MaxValue;
      ++overflowUncheckTest;
      Console.WriteLine($"overflow unchecked: {overflowUncheckTest}");

      var struct1 = new SampleStruct{ X = 100, Y = 20};
      var struct2 = struct1;
      struct2.X = 30;

      Console.WriteLine($"{struct1.X}, {struct1.Y}, {struct2.X}, {struct2.Y}");

      PartialClass.Test();
    }
  }

  // public: アセンブリ外部からでもアクセス可能
  public class PublicClassA {

    // クラス内クラス
    class ClassInClass {

      public string A {get; set;} = "World";
    }

    static PublicClassA() {
      Console.WriteLine("static constuctor");
    }
    public PublicClassA() {
      this.Field3 = 2.344;
    }

    // コンストラクタ
    public PublicClassA(int a, string b): this() {
      // thisはインスタンス自身を参照
      this.Field1 = a;
      this.Field2 = b;
    }

    // publicフィールド: クラス外からアクセス可能  
    public int Field1 = 10;


    // privateフィールド: クラス内からのみアクセス可能
    private string Field2 = "default";

    // protectedフィールド: クラス内or派生クラスからアクセス可能
    protected double Field3 = 3.5;

    // internalフィールド: 同一アセンブリ内からのみアクセス可能
    internal int Field4 = 303;

    // staticフィールド: インスタンスでなく、クラスに紐づく。
    public static int StaticField1 = 200;

    // 定数値
    public const int CONST_VAL = 100;

    // 読み取り専用値
    public readonly int readonlyVal = 100;
    
    // メソッド定義
    public string Hello() {
      var c = new ClassInClass();
      return "Hello!!" + c.A;
    }

    public static string StaticMethod () {
      return "static method";
    }

    public int Subtract(int x, int y) {
      return x - y;
    }

    public void Greet(string name = "John Doe") {
      Console.WriteLine($"Hello, {name}");
    }

    public int Sum(params int[] args) {
      return args.Sum();
    }


    [DllImport("kernel32.dll")]
    public static extern bool Beep(uint dwFreq, uint dwDuration);


    // 引数の渡し方による違い確認
    public static void ArgumentTest(int valByVal, ref int valByRef, int[] refByVal, ref int[] refByRef) {
      ++valByVal;
      ++valByRef;
      ++refByVal[0];
      ++refByRef[0];
      Console.WriteLine($"inside func: {valByVal} {valByRef} {refByVal[0]} {refByRef[0]}");
    }

    // ref戻り値
    public static ref int ReturnRef(int[] valArray) {
      return ref valArray[0];
    }

    // out引数による出力
    public static void Multiple2(int x, out int result) {
      result = x * 2;
    }

    public static (int min, int max) GetMinMax(IEnumerable<int> vals) {
      var min = vals.Min();
      var max = vals.Max();
      return (min, max);
    }


    // プロパティ
    public int PropTest {
      get {
        return this._PropTestVal;
      } 
      set {
        if (value < 0) {
          this._PropTestVal = 0;
        } else if (value >= 10) {
          this._PropTestVal = 10;
        } else {
          this._PropTestVal = value;
        }
      }
    }
    private int _PropTestVal;

    // Get-Only 自動プロパティ
    public int PropTest2 { get; } = 2000;

    public static IEnumerable<int> IteratorSample {
      get {
        yield return 100;
        yield return 200;
        yield return 300;
      }
    }

    public static string ThrowExSample(string val) {
      if (val == null) {
        throw new ArgumentNullException("argument null");
      }
      return val.ToUpper();
    }
  }

  // internal: アセンブリ内部からのみアクセス可能(省略可)
  internal class InternalClassA {

  }

  class DisposableSample : IDisposable {
    // 既に破棄されたか
    bool disposed = false;

    // リソース破棄処理
    public void Dispose() {
      this.Dispose(true);
      // ガベージコレクションにデストラクタ呼び出しを抑制するように指示
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) {
      Console.WriteLine($"Dispose (disposing: {disposing})");
      // 既に破棄されている
      if (this.disposed) {
        Console.WriteLine("already disposed");
        return;
      }

      if (disposing) {
        // マネージリソース破棄
        Console.WriteLine("dispose managed resources");
      }

      // アンマネージリソース破棄
      this.disposed = true;
      Console.WriteLine("dispose unmanaged resources");
    }

    // デストラクタ
    ~DisposableSample() {
      Console.WriteLine("Destructor");
      this.Dispose(false);
    }

  } 

  // インデクサを使うサンプル

  class IndexerSample {

    public IndexerSample(int len) {
      this._list = Enumerable.Range(0, 5).Select(i => i*2).ToList();
    }

    List<int> _list;

    public int this[int index] {
      get {
        return this._list[index];
      }
      set {
        this._list[index] = value;
      }
    }
  }

  // 基底クラスのサンプル

  class BaseClassSample {

    public BaseClassSample(int val) {
      Console.WriteLine($"BaseClassSample Constructor: {val}");
    }

    public void Method1() {
      Console.WriteLine("Base Method1");
    }

    public virtual void Method2() {
      Console.WriteLine("Base Virtual Method2");
    }

    public virtual void Method3() {
      Console.WriteLine("Base Virtual Method3");
    }
  }

  class DerivedClassSample : BaseClassSample {

    public DerivedClassSample(int val)
      : base(val * 100) {
      Console.WriteLine($"DerivedClassSample Constructor: {val}");
    }

    // 隠蔽。派生クラスから元のメソッドが見えなくなるだけ。
    public new void Method1() {
      base.Method1();
      Console.WriteLine("Derived New Method1");
    }

    // オーバーライド。基底クラスのvirtualメソッドを上書きするように動作。
    public override void Method2() {
      base.Method2();
      Console.WriteLine("Derived Override Method2");
    }

    // sealedを付けるとさらなる派生クラスによるoverrideを禁止
    public sealed override void Method3()
    {
      base.Method3();
      Console.WriteLine("Derived Override Method3");
    }
  }

  // sealed: 継承を禁止
  sealed class SealedClass {

  }

  static class ExtentionSample {

    // 拡張メソッド
    public static bool IsEven(this int val) {
      return val % 2 == 0;
    }
  }

  // 抽象クラス: インスタンス化できず、継承のみ可能なクラス
  abstract class AbstractSample {

    // インターフェースと違い、フィールドを持てる
    protected int Val = 100;

    public abstract void Test();
  }


  class OverrideSample : AbstractSample {

    public override void Test() {
      Console.WriteLine("Test Func Called: {0}", this.Val);
    }
  }

  interface IInterfaceSample1 {

    // メソッドを指定できる 
    void MethodSample(int val);

  }

  interface IInterfaceSample2 {
    void MethodSample(int val);
    // プロパティも指定できる 
    int PropertySample {get; set;}
  }

  // インタフェースは複数実装が可能
  class ImplementSample : IInterfaceSample1, IInterfaceSample2 {

    // シグネチャが被る場合は明示的実装が可能
    void IInterfaceSample1.MethodSample(int val) {
      Console.WriteLine("MethodSample Implement 1");
    }

    void IInterfaceSample2.MethodSample(int val) {
      Console.WriteLine("MethodSample Implement 2");
    } 

    public int PropertySample {get; set;} = 200; 
  }


  // 構造体。構造を持つ値型を定義可能
  struct SampleStruct {

    public int X;

    public int Y;
  }
  

  // partialクラス 一つのクラスを複数に分けて宣言可能
  partial class PartialClass {

    // 実装でなく宣言のみ
    static partial void PartialMethod();

    public static void Test() {
      PartialMethod();
    }
  }

  partial class PartialClass {

    // 実装
    static partial void PartialMethod() {
      Console.WriteLine("PartialMethod Called");
    }
  }
}

