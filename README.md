# 使用 HttpClient 進行檔案下載並顯示下載進度

透過 ProgressMessageHandler 類別的 HttpReceiveProgress 事件在取得 Http 服務資料時顯示目前的進度。

HttpReceiveProgress 事件提供的的 HttpProgressEventArgs 屬性如下：

名稱|備註
--|--
BytesTransferred|已取得位元數
TotalBytes|總資料位元數
ProgressPercentage|接收百分比

ProgressMessageHandler 類別位於 System.Net.Http.Formatting.Extension 套件中，命名空間為 System.Net.Http.Handlers，可透過 Nuget 進行取得。

### 範例程式碼說明

透過 HttpClient 取得 Ubuntu Server ISO 映像檔，並使用 ProgressMessageHandler 提供事件顯示下載檔案目前的進度。

[範例程式碼](https://github.com/txstudio/HttpClientDownloadWithProgressBar/blob/master/ConsoleApp/Program.cs)

### 注意事項
- 回應的 HttpResponse Header 需有 Content-Length 標頭，事件中的 TotalBytes 與 ProgressPercentage 才會有數值。
- 預設 HttpClient 逾時時間為 100 秒，可透過 HttpClient.Timeout 屬性進行逾時時間變更。

### 參考資料
[c# HttpClient上傳和下載的進度顯示問題](http://fanli7.net/a/bianchengyuyan/JS-HTML-WEB/20120831/215460.html)

[ProgressMessageHandler Class (System.Net.Http.Handlers)](https://msdn.microsoft.com/en-us/library/system.net.http.handlers.progressmessagehandler(v=vs.118).aspx)
