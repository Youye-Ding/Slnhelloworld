using Common.AITools.Tvbboy;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCrawler
{
    public partial class ExampleDazhongEnglishTraing : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string heads = @"Accept: application/json, text/javascript, */* q=0.01 " +
                @"Accept-Encoding: gzip, deflate " +
                @"Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2 " +
                @"Connection: keep-alive " +
                @"Cookie: s_ViewType=10; _lxsdk_cuid=1729cd29d3dc8-04d80d1c3b31398-4c302c7d-144000-1729cd29d3ec8; _lxsdk=1729cd29d3dc8-04d80d1c3b31398-4c302c7d-144000-1729cd29d3ec8; _hc.v=6c48a318-c117-5df7-478a-f0f694f1570e.1591768948; Hm_lvt_602b80cf8079ae6591966cc70a3940e7=1591768950,1591788446; _lxsdk_s=1729dfc18eb-4f6-3ef-94c%7C%7C19; Hm_lpvt_602b80cf8079ae6591966cc70a3940e7=1591788446 " +
                @"Host: catdot.dianping.com " +
                @"Referer: http:/www.dianping.com/search…/0_%E8%8B%B1%AF%AD%E5%9F%B9%AE " +
                @"User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0";
            string url = @"http://www.dianping.com/search/keyword/1/0_%E8%8B%B1%AF%AD%E5%9F%B9%AE";
            ClassHttpRequestClient s = new ClassHttpRequestClient(true);
            HtmlDocument doc = new HtmlDocument();
            string content = "";
            string response = s.httpPost(url, heads, content, Encoding.UTF8);
            HtmlAgilityPack.HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class=\"txt\"]");
            StringBuilder sb = new StringBuilder();
            foreach(HtmlAgilityPack.HtmlNode item in collection)
            {
                HtmlAgilityPack.HtmlNode divtit = item.SelectNodes("div[@class=\"txt\"]")[0];
                HtmlAgilityPack.HtmlNode aname = divtit.SelectNodes("a[1]")[0];
                HtmlAgilityPack.HtmlNode divcomment = item.SelectNodes("div[@class=\"comment\"]")[0];
                HtmlAgilityPack.HtmlNode anum = divcomment.SelectNodes("a[1]")[0];
                HtmlAgilityPack.HtmlNode aprice = divcomment.SelectNodes("a[2]")[0];
                sb.Append(string.Format("{0}—{1}—{2}", aname.InnerText, anum.InnerText, aprice.InnerText));
            }
            Response.Write(sb);
        }
    }
}