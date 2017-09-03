#r "Newtonsoft.Json"
#load "EchoDialog.csx"

using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Configuration;
using System.Text;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Threading;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Webhook was triggered!");

    // Initialize the azure bot
    using (BotService.Initialize())
    {
        // Deserialize the incoming activity
        string jsonContent = await req.Content.ReadAsStringAsync();
        var activity = JsonConvert.DeserializeObject<Activity>(jsonContent);
        
        // authenticate incoming request and add activity.ServiceUrl to MicrosoftAppCredentials.TrustedHostNames
        // if request is authenticated
        if (!await BotService.Authenticator.TryAuthenticateAsync(req, new [] {activity}, CancellationToken.None))
        {
            return BotAuthenticator.GenerateUnauthorizedResponse(req);
        }
        
        if (activity.Type == ActivityTypes.Message)
        {
            // ConnectorClient を作成、デフォルトの返答メッセージをセット
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            var responseMsg = "画像から文字を取得するBOTです。画像を送信してください送信してください。";
        
            // 受信したメッセージに画像ファイルがある場合
            if (activity.Attachments?.Any() == true)
            {
                // 画像ファイルを Stream として取得
                var photoUrl = activity.Attachments[0].ContentUrl;
                var client = new HttpClient();
                var Stream = await client.GetStreamAsync(photoUrl);
        
                try
                {
                    var OCR_result = await GetOCRData(Stream);
                    responseMsg = await GetParseString(OCR_result,log);
                }
                catch (Exception e)
                {
                    responseMsg = "添付ファイルを分析できませんでした分析できませんでした。";
                }
        
                // メッセージを返答
                Activity reply = activity.CreateReply(responseMsg);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
        }
        
        return req.CreateResponse(HttpStatusCode.Accepted);
    }    
}

/// <summary>
/// 画像から文字を取得する
/// </summary>
/// <returns>Stream</returns>
static async Task<HttpResponseMessage> GetOCRData(Stream stream)
{
    var OCRResponse = new HttpResponseMessage();
    
    // Computer vision APIのOCRにリクエスト
    using (var getOCRDataClient = new HttpClient())
    {
        // リクエストパラメータ作成、検知タイプは英文
        string language = "unk";
        string detectOrientation = "true";
        var uri = $"https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr?language={language}&detectOrientation={detectOrientation}";

        // ComputerVisionAPIへのリクエスト情報を作成
        HttpRequestMessage OCRRequest = new HttpRequestMessage(HttpMethod.Post, uri);
        OCRRequest.Content = new StreamContent(stream);
        OCRRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

        // リクエストヘッダーの作成
        // getOCRDataClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "ここにComupter Vision APIのKeyを記載");
        getOCRDataClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "38f09d193aa74e0f85aabf41e427adb1");


        // ComputerVisionAPIにリクエスト
        OCRResponse = await getOCRDataClient.SendAsync(OCRRequest);
    }

    return OCRResponse;
}

/// <summary>
/// ComputerVisionAPIのレスポンスメッセージをパース
/// </summary>
/// <returns>Stream</returns>
static async Task<string> GetParseString(HttpResponseMessage OCRResponse, TraceWriter log)
{
    // ComputerVisionAPIのレスポンスをパースして文章に
    var jsonContent = await OCRResponse.Content.ReadAsStringAsync();
    log.Info(jsonContent);
    OCR_Response ocr_data = JsonConvert.DeserializeObject<OCR_Response>(jsonContent);

    string words= String.Empty;

    if(ocr_data.regions.Any())
    {
        // OCRで取得した文字列をパースして文章にする。
        foreach(var regions in ocr_data.regions)
        {
            foreach(var line in regions.lines)
            {
                foreach(var word in line.words)
                {
                    words = words + word.text;
                }
                words = words + Environment.NewLine + Environment.NewLine;
            }
        }
    }
    else
    {
        words = "There is no words!!";
    }
    
    return words;
}


// OCRから返却されたデータ
public class OCR_Response
{
    public string language { get; set; }
    public double textAngle { get; set; }
    public string orientation { get; set; }
    public List<Region> regions { get; set; }
}
public class Region
{
    public string boundingBox { get; set; }
    public List<Line> lines { get; set; }
}
public class Line
{
    public string boundingBox { get; set; }
    public List<Word> words { get; set; }
}
public class Word
{
    public string boundingBox { get; set; }
    public string text { get; set; }
}
