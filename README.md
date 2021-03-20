# csharp_sample
C#のサンプルコード用

# コンソールプロジェクトの作成

`dotnet new console` でコンソールのテンプレートを使用したプロジェクトを新規作成できる。

# 実行

`dotnet run` で実行

# コンソールプロジェクトのVS Code デバッグ設定

`launch.json` の `console` プロパティを `integratedTerminal` にすることで、ターミナルを利用した入出力が可能となる。

# C#各種機能


## 名前空間

名前空間は、クラスなどを所属させることができる領域。
単純に同じクラス名を付けると名前が衝突してエラーとなるが、
異なる名前空間に所属させることにより、衝突を避けることができる。

`namespace [名前空間名]` で名前空間を定義できる。
名前空間は階層化が可能。

`using [名前空間名];` で名前空間を参照できる。 

.NET標準のライブラリも名前空間に属している(例: `System.Collections.Generic`)

## 型

C#には以下の型がある。

- 値型
  - 整数型
    - 符号あり整数
      - `sbyte` : 8bit
      - `short` : 16bit
      - `int` : 32bit
      - `long` 64bit
    - 符号なし整数
      - `byte` : 8bit
      - `ushort` : 16bit
      - `uint` : 32bit
      - `ulong` : 64bit
  - 浮動小数点型
    - 2進
      - `float` : 32bit
      - `double` : 64bit
    - 10進
      - `decimal` : 128bit
  - 真理値型
    - `boolean` : true/falseの二値
  - 文字/文字列
    - `char` : 1文字を表現
    - `string` : 0～任意長の文字列
  - オブジェクト型
    - `object` : 任意の型を格納できる

整数は`int`、実数は`double` を使うのが基本。
単に扱う値が狭い、負の数を使わない、などの理由で範囲の狭い型や符号無し型は使わなくてよい。
これらの型は、バイト数を厳密に扱いたい場合などに使う。

