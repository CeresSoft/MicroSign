[操作マニュアル - TOP](./microsign_manual.md) 

## 1枚画像からアニメーションを作成する

スマホで撮影した写真などから単純なスクロールアニメーションを作成する方法です。

MicroSignの操作方法は「基本操作」を参照してください

ここではMicroSignを起動し、表示パネルのドット数を設定した状態から進めます。

### 画像の選択

「画像追加」ボタンをクリックします。

![画像追加ボタンをクリック](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture01.png)

アニメーション画像追加ダイアログが開くので、
表示したい画像ファイルを選択し「開く」をクリックします

選択する画像のサイズは、表示パネルのドット数と異なっていても問題ありません。

![画像ファイル選択](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture02.png)

画像切り抜き画面が開きます。
選択した画像は、表示パネルのドット数に合わせて自動的にサイズ調整され
画像の縦横比により上下または左右に画像をスクロールする機能が有効になります。


![画像ファイル読込](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture03.png)

### 移動方向の設定

画像の縦横比により上下または左右のどちらかの選択が表示されます

|移動方向 |選択|
|--------|----|
|上下     |![上下](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture04.png)|
|左右     |![左右](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture05.png)|

アニメーションする方向を指定してください。

|移動方向     |プレビュー|
|:------------|:---------|
| 下から上へ  |![設定例: 下から上へ](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture15.png)|
| 上から下へ  |![設定例: 上から下へ](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture16.png)|

### 移動速度

![移動速度](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture06.png)

スクロールして表示する速度を指定します。
数値を大きくするほど、動きが速くなります。

|移動速度     |プレビュー|
|:------------|:---------|
| 1px（標準） |![設定例: 1px](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture08.png)|
| 5px（最大） |![設定例: 5px](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture09.png)|

### アニメーション密度

![アニメーション密度](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture07.png)

生成するフレームの表示期間（=動きのなめらかさ）を指定します。

|移動速度     |プレビュー|
|:------------|:---------|
| ゆっくり (10 FPS)  |![設定例: ゆっくり](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture11.png)|
| 標準 (20 FPS)      |![設定例: 標準](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture10.png)|
| なめらか  (30 FPS)  |![設定例: なめらか](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture12.png)|

### アニメーション生成

設定が決定したら、「OK」ボタンをクリックします。
![OKボタンをクリック](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture13.png)

これで指定した画像がフレームごとの画像に分解され、アニメーションが作成されます。
![画像切り抜き後](https://raw.githubusercontent.com/CeresSoft/MicroSign/refs/heads/master/Manuals/images/microsign_manual_picture14.png)
