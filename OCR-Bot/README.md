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

## Computer Vision APIの作成
Computer Vision APIのインスタンスを作成します。

![参考画像01](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/001.png)

Azureのポータル画面を開いたら[+]ボタンを選択し「AI+Cognitive Service」から「Computer Vision API」を選択します。

基本的な情報を入力していきます。

**「Name」**

任意の名称を入力してください。サンプル画像の名称は利用しないでください。名称重複エラーが発生する可能性があります。

**「価格レベル」**

F0を選択してください。F0以外を選択すると課金が発生するので注意してください。

**「REsource Group」**

リソースグループの新規作成をする場合は任意の名称を入力してください。既存のリソースグループを利用する場合は任意のリソースグループを選択してください。

ライセンスに同意するチェックボックスにチェックをいれて作成すると少し待った後に作成されます。

続いてインスタンスが作成されたらAPI Keyを取得します。

![参考画像03](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/003.png)

リソースグループ一覧を選択して、作成したリソースグループ内にある「Computer Vision API」のインすんタンスを選択します。

![参考画像04](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/004.png)

Keysを選択してKEY 1の値を控えておいてください。

※画像に記載のあるKEYは削除済みなので利用できません。

これでComputer Vision APIの作成は完了です。


## Bot Serviceの作成

続いてBot Serviceを作成します。

![参考画像02](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/002.png)

Azureのポータル画面を開いたら[+]ボタンを選択し「Data + Analytics」から「Bot Service」を選択します。

基本的な情報を入力していきます。

**「アプリ名」**

任意の名称を入力してください。サンプル画像の名称は利用しないでください。名称重複エラーが発生する可能性があります。

**「Resource Group」**

リソースグループの新規作成をする場合は任意の名称を入力してください。既存のリソースグループを利用する場合は任意のリソースグループを選択してください。

作成ボタンを選択すると少し待った後に作成されます。


![参考画像05](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/005.png)

Bot Serviceインスタンスが作成されたら選択し設定を行っていきます。

リソースマネージャーからBot Serviceを選択して下さい。

![参考画像06](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/006.png)

Bot Serviceの初期設定画面が開くので「Create Microsoft App ID Password」を選択します。

![参考画像07](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/007.png)

アプリIDとパスワードを生成画面が開くので「アプリパスワードを生成して続行」を選択します。

![参考画像08](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/008.png)

新しいパスワードが生成されますのでこちらのパスワードを控えておきます。

![参考画像09](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/009.png)

ここでアプリIDも控えておいてください。パスワードとアプリIDはBot Emulatorで利用します。
「終了してボットのフレームワークに戻る」を選択します。

![参考画像10](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/010.png)

続いてプログラム言語の選択やテンプレートの選択を実施していきます。

**「Choose a language」**

ここではC#を選択します。

**「Choose a template」**

ここではBasicを選択します。Basicは単純なエコーボットです。

**「Select your country/region」**

ここではJapanを選択します。

チェックボックス2か所をチェックして「Create bot」を選択します。こちらの作成には時間がかかるので座して待ちましょう。


![参考画像11](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/011.png)

Bot Serviceが作成されると上記のような画面が表示されます。

Bot Serviceのエンドポイントを取得するために「SETTINGS」を選択します。

![参考画像12](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/012.png)

SETTINGS画面がひらいたらConfigurationのMessaging endpointのURLを控えておきましょう。

![参考画像13](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/013.png)

Bot Serviceが作成されたら接続確認を行うためインストールしておいたBot Emulatorで確認を行います。

一番上の青い部分に控えておいたURLを入力します。

その後、控えておいたAppIDとPasswordを入力し「CONNECT」を選択し接続します。

接続に失敗するときはエンドポイントURL、AppID、Passwordを確認してください。


![参考画像14](https://github.com/Azure-Moku2-Study/Azure-moku2-textbook/blob/master/OCR-Bot/image/014.png)

任意の文字を入力して送信してみましょう。

入力した文字がオウム返しされれば成功です。

これで環境構築は完了です。

## OCR-botの作成
OCR-botの作成は今回Azure上で完結させます。従来であればVisualStudio等のIDEを利用して作成しますが、ここでは動かすことを目的にしていきたいと思います。



