# MicroSign アニメーション作成アプリ

デジタルネイサージ「MicroSign」向けのアニメーション作成アプリケーションです

## プロジェクト

MicroSignで再生するアニメーションを作成するアプリケーション

[MicroSign/MicroSign.sln](MicroSign/MicroSign.sln)


実行するのに.NET8 が必要になります
 .NET8は以下のURLからダウンロードできます

[.NET 8.0 のダウンロード](https://dotnet.microsoft.com/ja-jp/download/dotnet/8.0)

最新バージョンの「.NET デスクトップ ランタイム」をインストールしてください

![.NET8](./DocumentImages/dotNet8Install.png)



## サンプルアニメーション一覧

### MicroSign パネルテスト アニメーション

[MicroSign パネルテスト アニメーション](./SampleAnimations/MicroSignパネルテストアニメーション/)

MicroSignの全LEDが正しく点灯しているか確認するためのアニメーション

画像はペイントで作成
２秒ごとに画像が切り替わります


### MicroSign プロモーション アニメーション

[MicroSign プロモーション アニメーション](./SampleAnimations/MicroSignプロモーションアニメーション/)

MicroSignのプロモーション用に作成したアニメーション

Clip Studio PAINTのアニメーション機能を使ってアニメーションを用意しました

![MicroSignプロモーション](./DocumentImages/MicroSignPromotion.png)


## 更新履歴

### v 1.3.0.1

2025.08.13:CS)杉原

- 256パレット対応
   
  以前は(R,G,B)=(3bit,3bit,2bit)の256色固定でしたが、
  GIFの256パレット相当の実装を追加しました

  MicroSign本体のバージョンはv3.02以上が必要です


### v 1.2.0.1

2025.07.20:CS)杉原

- .NET8対応

  .NET6から.NET8に変更しました


- 全画像削除ボタンを追加

  登録しているアニメーション画像をすべて削除するボタンを追加しました


- GIFファイル読込を追加

  GIFファイルの読込に対応しました