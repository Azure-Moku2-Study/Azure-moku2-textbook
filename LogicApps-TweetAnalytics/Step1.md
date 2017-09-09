# Step 1 : ツイートを取得して、内容を保存する。
最初のステップでは、Azure Logic Apps に触れてみます。  
Twitter から任意の文字列を検索し、その内容を Azure Blob Storage に保存します。

## Logic Apps の作成
1. Azure ポータルに接続し、「+」ボタンをクリックして新規作成メニューを表示します。  
2. 「Web + モバイル」を選択して、「Logic App」をクリックします。

![Create new Logic App 1](./assets/Step1/01.png)
 
3. 「ロジックアプリの作成」画面で以下の内容を入力します。  

    **名前**  
    「AzureMoku2LogicApp」と入力します。

    **サブスクリプション**  
    利用するサブスクリプション名を選択します。    
    
    **リソースグループ**  
    「新規」を選択し、リソースグループを作成します。  
    「AzureMoku2Hnadson」と入力します。
    
    **場所**  
    「東日本」を選択します。
    
    **Log Analytics**  
    「Off」を選択します。

![Create new Logic App 2](./assets/Step1/02.png)

4. 「作成」ボタンをクリックします。  
    作成が完了して Logic Apps に接続すると、以下のような画面が表示されます。

![Create new Logic App 3](./assets/Step1/03.png)

## Storage の作成
1. Azure ポータルで「+」ボタンをクリックして新規作成メニューを表示します。  
2. 「Storage」を選択して、「Storage account」をクリックします。

![Create new Storage account 1](./assets/Step1/04.png)

3. 「Create storage account」画面で以下の内容を入力します。

    **Name**  
    任意の入力します。

    **Deployment model**  
    「Resource manager」を選択します。

    **Account kind**  
    「General purpose」を選択します。

    **Performance**  
    「Standard」を選択します。

    **Replication**  
    「LRS」を選択します。

    **Secure transfer required**  
    「Disabled」を選択します。

    **サブスクリプション**  
    利用するサブスクリプション名を選択します。

    **Resource group**  
    「既存のものを使用」をクリックし、先ほど作成した「AzureMoku2Handson」を選択します。

    **場所**  
    「東日本」を選択します。

![Create new Storage account 2](./assets/Step1/05.png)

4. 「作成」ボタンをクリックします。

5. 作成した Storage account を開き、「Blobs」をクリックします。

![Create new Storage account 3](./assets/Step1/06.png)

6. 「+ Container」をクリックします。
7. 「New container」ウィンドウで、以下の内容を入力します。  
    **Name**  
    「tweetcontainer」と入力します。

    **Public access level**  
    「Private (no anonymous access)」を選択します。
8. 「OK」ボタンをクリックします。

![Create new Storage account 4](./assets/Step1/07.png)

## Twitter を検索して、内容を保存する。
1. 前述で作成した Logic Apps を開きます。
2. 「Logic Apps デザイナー」画面で、「新しいツイートが投稿されたら」をクリックします。

![Get Tweet 1](./assets/Step1/07.png)

3. Twitter の認証が必要となるため、「サインイン」をクリックします。

![Get Tweet 2](./assets/Step1/08.png)

4. 利用する Twitter アカウント情報を入力し、「連携アプリを認証」ボタンをクリックします。

![Get Tweet 3](./assets/Step1/09.png)

5. 「検索テキスト」に、Twitter 上で検索するキーワードを入力します。
6. 「新しいステップ」をクリックし、「アクションの追加」をクリックします。

![Get Tweet 4](./assets/Step1/10.png)

7. アクションの一覧から「Azure Blob Storage」を選択します。

![Get Tweet 5](./assets/Step1/11.png)

8. Azure Blob Storage のアクション一覧の中から「Azure Blob Storage : BLOB の作成」を選択します。

![Get Tweet 6](./assets/Step1/12.png)

9. 「BLOB」の作成画面で以下の情報を入力します。  
    **接続名**  
    「AzureMoku2BlobStorage」と入力します。  
    Logic Apps のアクションは、利用するアクション毎にリソースグループに追加されます。  
    そこで識別するための名前を入力します。

    **ストレージアカウント**  
    「AzureMoku2」

10. 「作成」ボタンをクリックします。

![Get Tweet 7](./assets/Step1/13.png)

11. 「BLOB の作成」画面で、以下の内容を入力します。

    **フォルダーのパス**  
    先ほど作成した「/tweetcontainer」を選択します。

    **BLOB 名**  
    「ツイート ID」を選択します。

    **BLOB コンテンツ**  
    「ツイートテキスト」を選択します。

![Get Tweet 8](./assets/Step1/14.png)

12. 「保存」をクリックします。
13. 「×」をクリックして、ウィンドウを閉じます。

![Get Tweet 9](./assets/Step1/15.png)

14. Logic Apps の概要ページで「トリガーの実行」をクリックします。
15. 「When_a_new_tweet_is_posted」をクリックします。

![Get Tweet 10](./assets/Step1/16.png)

16. 「最新の情報に更新」をクリックし、「実行の履歴」に「成功」状態が追加されることを確認します。
17. 「無効」ボタンをクリックします。  
    ここで無効化しなかった場合は、手順「6」のキャプチャにあるように、3 分間隔でトリガーが実行されます。

![Get Tweet 11](./assets/Step1/17.png)

18. Blob Storage を開き、手順「11」で指定したコンテナーにデータが保存されていることを確認します。

![Get Tweet 12](./assets/Step1/18.png)

以上で Step 1 は完了です。  
