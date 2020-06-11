using Common.AITools.Tvbboy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScrapySharp.Network;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCrawler
{
    //https://jingyan.baidu.com/article/7e44095334bb162fc0e2efad.html

    //https://www.cnblogs.com/soundcode/p/3785152.html
    public partial class ExampleTmall : System.Web.UI.Page
    {
       
        private string initurl = "https://list.tmall.com/search_product.htm?q=thinkpad&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
        private string result = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
           //HrefCrawler();
           SeleniumCrawler(initurl);
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
                Response.Write(result);
                Response.Write("===============================================</br>");
                if (result != "")
                    doHtml();
                else
                    Response.Write("爬取失败！");
            };
            hrefCrawler.start();
        }
        private void doHtml()
        {
           // 第一步声明HtmlAgilityPack.HtmlDocument实例
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //第二步加载html文档
            doc.LoadHtml(result);
            string xpathDiv = "//div[@class=\"product-iWrap\"]";//找到class=zg_itemImmersion的div节点
           // HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode(xpathDiv);
            HtmlAgilityPack.HtmlNodeCollection collection = doc.DocumentNode.SelectNodes(xpathDiv);
            StringBuilder sb = new StringBuilder();
            foreach (HtmlAgilityPack.HtmlNode item in collection)
            {
                //*[@id="J_ItemList"]/div[2]/div
                string price_path = "./p[@class=\"productPrice\"]";
                HtmlAgilityPack.HtmlNode divtit1 = item.SelectSingleNode(price_path);
                string name_path = "./p[@class=\"productTitle\"]";
                HtmlAgilityPack.HtmlNode divtit2 = item.SelectSingleNode(name_path);
                sb.Append(string.Format("{0}---{1}</br>", divtit1.InnerText, divtit2.InnerText));
            }
            Response.Write(sb);
        }
  
        public void ScrapingCrawler()
        {
            Uri uri = new Uri(initurl);
            //var browser1 = new ScrapingBrowser();
           // var html1 = browser1.DownloadString(uri);
        }
        public void SeleniumCrawler(string url)
        {
            //启动谷歌浏览器
            IWebDriver selenium = new ChromeDriver();
            //浏览器跳转到我们要爬取的url
            selenium.Navigate().GoToUrl(url);
            //确保页面内容已加载完成
            while (string.IsNullOrEmpty(selenium.Title))
            {
                Task.Delay(100).GetAwaiter().GetResult();
            }
            result = selenium.PageSource;
            doHtml();
        }
    }
}