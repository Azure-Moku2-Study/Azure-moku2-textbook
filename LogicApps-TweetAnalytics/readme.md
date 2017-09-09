# Logic Apps で Twitter からキーワードを取得してみる。
任意のキーワードについて、Twitter 上でどのようなキーワードが関連しているかを Power BI 上で可視化するハンズオンです。  
このハンズオンでは、以下の内容を実施します。

## このハンズオンで準備するもの
- Microsoft Azure サブスクリプション
- Twitter アカウント
    > Logic Apps から Twitter へ接続するために、アカウントが必要です。
- Office 365 アカウント (Step 2 以降を実施する場合のみ)

## [Step 1 : ツイートを取得して、内容を保存する。](./Step1.md)

### 実装する機能
- Logics Apps で Twitter からツイートを取得する。
- 取得したツイートを OneDrive??? に保存する。

### 利用するサービス
- Azure Logic Apps
- Azure Blob Storage
- Twitter

## [Step 2 : ツイートからキーワードを抽出する。](./Step2.md)

### 実装する機能
- Twitter から取得したツイートからキーワードを抽出する。

### 利用するサービス
- Azure Text Analytics API (Key Phrase)
- Azure Table Storage

## Step 3 : 抽出したキーワードを可視化する。(./Step3.md)

### 実装する機能
- 抽出されたキーワードを Power BI で可視化する。

### 利用するサービス
- Power BI
- Power BI Desktop
