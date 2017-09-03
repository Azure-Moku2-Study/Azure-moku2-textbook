# Logic Apps で Twitter からキーワードを取得してみる。
任意のキーワードについて Twitter 上で呟かれている内容が、肯定あるいは否定的なものなのかを分析する機能を作成するハンズオンです。  
このハンズオンでは、以下の内容を実施します。

## [Step 1 : ツイートを取得して、内容を保存する。](./Step1.md)

### 実装する機能
- Logics Apps で Twitter からツイートを取得する。
- 取得したツイートを OneDrive??? に保存する。

### 利用するサービス
- Azure Logic Apps
- Twitter
- OneDrive???

## Step 2 : ツイートからキーワードを抽出する。

### 実装する機能
- Twitter から取得したツイートからキーワードを抽出する。

### 利用するサービス
- Azure Text Analytics API (Key Phrase)

## Step 3 : ツイートの評判分析を行う。

### 実装する機能
- Twitter から取得したツイートを翻訳する。
- ツイートの評判分析を行う。

### 利用するサービス
- Azure Translator Text API
- Azure Text Analytics API (Sentiment)
