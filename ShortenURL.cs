using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace EPMS.Web.Helper
{
   public class ShortenURL
    {
       public static  string Shorten(string url)
       {
           WebClient client = new WebClient();
           WebHeaderCollection headers = new WebHeaderCollection();
           headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=utf-8";
           headers[HttpRequestHeader.Referer] = "http://api.t.sina.com.cn/";
           client.Headers = headers;
          string address = string.Format("http://api.t.sina.com.cn/short_url/shorten.json?source=1681459862&url_long={0}", url);
           string[] strArray = HttpUtility.UrlDecode(client.DownloadData(address), Encoding.UTF8).Split(new string[] { "\"" }, StringSplitOptions.None);
           return  strArray[3];
       }
       
       public static  string ShortenV2(string url)
       {
           WebClient client = new WebClient();
           WebHeaderCollection headers = new WebHeaderCollection();
           headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=utf-8";
           headers[HttpRequestHeader.Referer] = "http://api.t.sina.com.cn/";
           client.Headers = headers;
            string address = string.Format("https://api.weibo.com/2/short_url/shorten.json?access_token={0}&url_long={1}","2.00ttSGDCpeE7vB79abfd2b110ia1Ux", url);
           string[] strArray = HttpUtility.UrlDecode(client.DownloadData(address), Encoding.UTF8).Split(new string[] { "\"" }, StringSplitOptions.None);
           return  strArray[7];
       }
    }
}
