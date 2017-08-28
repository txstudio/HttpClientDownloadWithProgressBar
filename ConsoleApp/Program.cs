using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClientHandler _handler;
            ProgressMessageHandler _progressHandler;

            HttpClient _client;

            string _baseAddress;
            string _relativeUrl;

            //下載 Ubuntu Server ISO 檔案的路徑
            _baseAddress = @"http://ftp.ncnu.edu.tw";
            _relativeUrl = @"/Linux/ubuntu/ubuntu-cd/16.04.3/ubuntu-16.04.3-server-amd64.iso";

            _handler = new HttpClientHandler();

            //註冊檔案下載進度事件
            _progressHandler = new ProgressMessageHandler(_handler);
            _progressHandler.HttpSendProgress += _progressHandler_HttpSendProgress;
            _progressHandler.HttpReceiveProgress += _progressHandler_HttpReceiveProgress;

            _client = new HttpClient(_progressHandler);

            //預設 Timeout 時間為 100 秒
            _client.Timeout = new TimeSpan(1, 0, 0);
            _client.BaseAddress = new Uri(_baseAddress);

            //進行檔案下載作業
            var _response = _client.GetAsync(_relativeUrl).Result;

            byte[] _buffer;

            if (_response.IsSuccessStatusCode == true)
            {
                _buffer = _response.Content.ReadAsByteArrayAsync().Result;

                Console.WriteLine("{0} download finished", _buffer.Length);
            }
            else
            {
                Console.WriteLine("download error");
            }

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }

        //進行檔案上傳的事件
        private static void _progressHandler_HttpSendProgress(object sender, HttpProgressEventArgs e)
        {
            throw new NotImplementedException();
        }

        //進行檔案下載事件
        private static void _progressHandler_HttpReceiveProgress(object sender, HttpProgressEventArgs e)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("download progress (byte)");
            Console.WriteLine("---------------------------");
            Console.WriteLine("{0}/{1}", e.BytesTransferred, e.TotalBytes);
            Console.WriteLine("{0} %", e.ProgressPercentage);
            Console.WriteLine("---------------------------");
        }
    }
}
