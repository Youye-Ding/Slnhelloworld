using Common.AITools.Tvbboy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCrawler
{
    public class examplemyhref
    {
        public string hreftitle { get; set; }
        public string hrefsrc { get; set; }
    }

    public partial class ExampleCrawLink : System.Web.UI.Page
    {
        public void HrefCrawler()
        {
            var hrefList = new List<examplemyhref>();
            string initurl = "https://tieba.baidu.com/f?kw=%E5%8D%8E%E4%B8%9C%E5%B8%88%E8%8C%83%E5%A4%A7%E5%AD%A6&ie=utf-8";
            string result = string.Empty;
            var hrefCrawler = new SimpleCrawler();
            hrefCrawler.url = new Uri(initurl);
            Response.Write("爬虫开始抓取地址：" + hrefCrawler.url.ToString() + "</br>");
            hrefCrawler.OnError += (s, e) =>
             {
                 Response.Write("爬虫抓取出现错误，异常信息：" + e.Exception.Message);
             };
            hrefCrawler.OnCompleted += (s, e) =>
              {
                  var links = Regex.Matches(e.PageSource, @"<a[^>]+href=""*(?<href>[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>", RegexOptions.IgnoreCase);
                  foreach(Match match in links)
                  {
                      var h = new examplemyhref
                      {
                          hreftitle = match.Groups["text"].Value,
                          hrefsrc = match.Groups["href"].Value
                      };
                      if (!hrefList.Contains(h))
                      {
                          hrefList.Add(h);
                          result += h.hreftitle + "|" + h.hrefsrc + "</br>";
                      }
                  }
                  Response.Write("================================</br>");
                  Response.Write("爬虫抓取任务完成！合计" + links.Count + "个超级链接。</br>");
                  Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");
                  Response.Write("线程：" + e.ThreadId + "</br>");
                  Response.Write(result);
                  Response.Write("================================</br>");
              };
            hrefCrawler.start();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HrefCrawler();
        }
    }
}