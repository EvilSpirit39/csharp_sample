// 名前空間を利用する
using System;

// = で名前空間にエイリアスを付けられる
using AnoNs = AnotherNSSample;

// 名前空間に含める
namespace ConsoleTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            CommentSample.Run();
            VariableSample.Run();
            OperatorSample.Run();
            ControllSample.Run();
            StringSample.Run();
            RegexSample.Run();
            DateSample.Run();
            FileSample.Run();
            MathSample.Run();
            BigNumSample.Run();
            ArrayFuncSample.Run();
            CollectionSample.Run();
            ClassSample.Run();
            AnoNs::SampleClass.Hello();
            EnumSample.Run();

            // コンソール出力
            Console.WriteLine("Your Name? ");
            var name = Console.ReadLine();

            // コンソール入力
            Console.WriteLine("Hello, {0}", name);

        }

        
    }
}
