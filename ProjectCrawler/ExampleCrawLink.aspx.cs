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
            for (int page = 0; page < 10; page++)
            {
                string initurl = string.Format("https://tieba.baidu.com/f?kw=%E5%8D%8E%E4%B8%9C%E5%B8%88%E8%8C%83%E5%A4%A7%E5%AD%A6&ie=utf-8&&pn={0}", page*50);
                string result = string.Empty;
                var hrefCrawler = new SimpleCrawler();
                hrefCrawler.url = new Uri(initurl);
                hrefCrawler.OnError += (s, e) =>
                 {
                     Response.Write("爬虫抓取出现错误，异常信息：" + e.Exception.Message);
                 };
                hrefCrawler.OnCompleted += (s, e) =>
                  {
                      var links = Regex.Matches(e.PageSource, @"<a[^>]+href=""*(?<href>[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>", RegexOptions.IgnoreCase);
                      foreach (Match match in links)
                      {
                          var h = new examplemyhref
                          {
                              hreftitle = match.Groups["text"].Value,
                              hrefsrc = match.Groups["href"].Value
                          };
                          if (!hrefList.Contains(h)&&(h.hreftitle.Contains("求助")||h.hreftitle.Contains("考研")||h.hreftitle.Contains("学长")||h.hreftitle.Contains("学姐")))
                          {
                              hrefList.Add(h);
                              result += h.hreftitle + "|" + @"https://tieba.baidu.com" + h.hrefsrc + "</br>";
                          }
                      }
                      Response.Write("================================</br>");
                      Response.Write(string.Format("第{0}页</br>", page + 1));
                      Response.Write(result);
                      Response.Write("================================</br>");
                  };
                hrefCrawler.start();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HrefCrawler();
        }
    }
}