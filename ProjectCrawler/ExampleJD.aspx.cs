using Common.AITools.Tvbboy;
using System;
using System.Text;

namespace ProjectCrawler
{
    //https://jingyan.baidu.com/article/7e44095334bb162fc0e2efad.html

    //https://www.cnblogs.com/soundcode/p/3785152.html
    public partial class ExampleJD : System.Web.UI.Page
    {
        private string initurl = "https://search.jd.com/Search?keyword=物理选择性必修&enc=utf-8&suggest=1.rem.0.0&wq=物理选择性必修&pvid=770f405155414704b0bd1e2329dd0f5d";
        private string result = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            HrefCrawler();
        }
         /// <summary>
        /// 抓取超链接
        /// </summary>
        public void HrefCrawler()
        {
         
            var hrefCrawler = new SimpleCrawler();//调用爬虫程序
            hrefCrawler.url = new Uri(initurl);//定义爬虫入口URL      
            Response.Write("爬虫开始抓取地址：" + hrefCrawler.url.ToString() + "</br>");
            hrefCrawler.OnError += (s, e) =>
            {
                Response.Write("爬虫抓取出现错误，异常消息：" + e.Exception.Message);
            };
            hrefCrawler.OnCompleted += (s, e) =>
            {
                result = e.PageSource;
                Response.Write("===============================================</br>");
                Response.Write("爬虫抓取任务完成！</br>");
                Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");
                Response.Write("线程：" + e.ThreadId + "</br>");
              //  Response.Write(result);
                Response.Write("===============================================</br>");
                doHtml();
            };
            hrefCrawler.start();
        }
        private void doHtml()
        {
            // 第一步声明HtmlAgilityPack.HtmlDocument实例
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //第二步加载html文档
            doc.LoadHtml(result);
            string xpathDiv = "//div[@class='gl-i-wrap']";//找到class=gl-i-wrap的div节点
            HtmlAgilityPack.HtmlNodeCollection collection = doc.DocumentNode.SelectNodes(xpathDiv);
            StringBuilder sb = new StringBuilder();
            foreach (HtmlAgilityPack.HtmlNode item in collection)
            {
                string price_path="div[2]/strong/i";
                HtmlAgilityPack.HtmlNode divtit1 = item.SelectSingleNode(price_path);
                string name_path="div[3]/a/em";
                HtmlAgilityPack.HtmlNode divtit2 = item.SelectSingleNode(name_path);
                sb.Append(string.Format("{0}---{1}</br>", divtit1.InnerText, divtit2.InnerText));
            }
            Response.Write(sb);
        }
        /// <summary>
        /// 高级爬取
        /// </summary>
        public void AdvCrawler()
        {
            string heads = @"Accept:text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8
//Accept-Encoding:gzip, deflate
//Accept-Language:zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
//Cache-Control:max-age=0
//Connection:keep-alive
//Cookie:cy=1; _lxsdk_cuid=15ffc822338c…3fb990e3e-b37-f9f-cd5%7C%7C20
//Host:www.dianping.com
//Upgrade-Insecure-Requests:1
//Accept:text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8
//Accept-Encoding:gzip, deflate
//Accept-Language:zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
//Cache-Control:max-age=0
//Connection:keep-alive
//Cookie:cy=1; _lxsdk_cuid=15ffc822338c…3fb990e3e-b37-f9f-cd5%7C%7C20
//Host:www.dianping.com
//Upgrade-Insecure-Requests:1
//User-Agent:Mozilla/5.0 (Windows NT 10.0; …) Gecko/20100101 Firefox/60.0";

            ClassHttpRequestClient s = new ClassHttpRequestClient(true);
            string content = "";
            string response = s.httpPost(initurl, heads, content, Encoding.UTF8);
            Response.Write(response);
         
        }
    }
}