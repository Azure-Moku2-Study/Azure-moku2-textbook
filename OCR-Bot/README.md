# AzureBotServiceを利用したOCR-Botの作成について
### ハンズオンの目的
Bot Serviceに送信した画像から文字を取得して返信するBot作成します。

今回利用するサービスはBot ServiceとComputer Vision APIです。

### ハンズオンのゴール
Azureの環境構築、Bot Framework Emulatorのインストール、Vision APIを利用してOCR-Botの実行ができることをゴールとします。

## 前提
Azureのアカウント登録とサブスクリプションの作成が完了していること。

[Azureのアカウントをまだお持ちではない方はこちらから登録を実施してください。](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook)

## 注意
本情報は2017年9月時点の情報となります。

将来的にサービスの更新や機能の仕様変更に伴いハンズオンの内容に誤差が発生する可能性がありますので予めご承知おきください。

## 事前準備（インストール編）

下記の環境が必要になりますのでインストールをお願いします。

・Bot Framework Emulatorの使い方についての公式ドキュメント（英語）

[Bot Framework Emulator](https://docs.microsoft.com/en-us/bot-framework/debug-bots-emulator)

・お使いの環境に合わせたBot Emulatorをダウンロードしインストールしてください。

[Bot Emulator](https://github.com/Microsoft/BotFramework-Emulator/releases/tag/v3.5.31)

・下記のソフトウェアトンネルソフトをダウンロードし任意の場所に配置してください。

[ngrok](https://ngrok.com/)

・Bot Framework Emulatorのセットアップについては下記を参考にしてください。

[Bot Framework Emulatorのセットアップ方法について](http://qiita.com/kingkinoko/items/eb83f8ca00c516eac29e)

## Bot Service及びVisionAPIの作成



![参考画像01](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/001.png)

![参考画像02](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/002.png)

![参考画像03](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/003.png)

![参考画像04](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/004.png)

![参考画像05](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/005.png)

![参考画像06](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/006.png)

![参考画像07](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/007.png)

![参考画像08](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/008.png)

![参考画像09](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/009.png)

![参考画像10](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/010.png)

![参考画像11](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/011.png)

![参考画像12](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/012.png)

![参考画像13](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/013.png)

![参考画像14](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/014.png)

