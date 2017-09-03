# AzureBotServiceを利用したOCR-Botの作成について
### ハンズオンの目的
Bot Framework Emulatorを利用して画像から文字を取得して返信するBotを作成します。

### ハンズオンのゴール
Azureの環境構築、Bot Framework Emulatorのインストール、Vision APIを利用してOCR-Botの実行ができることをゴールとします。

## 前提
Azureのアカウント登録とサブスクリプションの作成が完了していること。

[Azureのアカウントをまだお持ちではない方はこちらから登録を実施してください。](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook)

## 注意
本情報は2017年9月時点の情報となります。

将来的にサービスの更新や機能の仕様変更に伴いハンズオンの内容に誤差が発生する可能性がありますので予めご承知おきください。

## 事前準備（インストール編）
Bot Framework Emulator

・Bot Framework Emulatorの使い方についての公式ドキュメント（英語）

[Bot Framework Emulator](https://docs.microsoft.com/en-us/bot-framework/debug-bots-emulator)

・お使いの環境に合わせたBot Emulatorをダウンロードしインストールしてください。

[Bot Emulator](https://github.com/Microsoft/BotFramework-Emulator/releases/tag/v3.5.31)

・下記のソフトウェアトンネルソフトをダウンロードし任意の場所に配置してください。

[ngrok](https://ngrok.com/)

・Bot Framework Emulatorのセットアップについては下記を参考にしてください。

[Bot Framework Emulatorのセットアップ方法について](http://qiita.com/kingkinoko/items/eb83f8ca00c516eac29e)

## Bot Service及びVisionAPIの作成
