using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Echarts
{
    public partial class ncovFromAPI : System.Web.UI.Page
    {
        private string url = "https://view.inews.qq.com/g2/getOnsInfo?name=disease_h5";
        public string datestr = DateTime.Now.ToString("yyyyMMdd");
        List<classKSingleValueJson> data = new List<classKSingleValueJson>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonStr = getHtml(url);//url

            //将字符串转换成json
            var cpresult = JObject.Parse(jsonStr);
            //获取json中的data部分
            JToken cdata = cpresult.GetValue("data");
             cpresult = JObject.Parse(cdata.ToString());
             JToken careaTree = cpresult.GetValue("areaTree");
             JToken children = careaTree.Last.Last.Last;
             var namearr=JArray.Parse(children.ToString());
             //自定义对象的JSON
            Response.Write("省-----nowConfirm----------confirm--------suspect----dead-----deadRate----healRate</br>");
            foreach (var item in namearr)
            {
                Response.Write(string.Format("{0}----{1}-----{2}-----{3}-----{4}-----{5}-----{6}</br>",item["name"].ToString(),item["total"]["confirm"].ToString(),item["total"]["suspect"].ToString(),item["total"]["confirm"].ToString(),item["total"]["suspect"].ToString(),item["total"]["dead"].ToString(),item["total"]["deadRate"].ToString(),item["total"]["healRate"].ToString()));
                data.Add(new classKSingleValueJson(item["name"].ToString(), double.Parse(item["total"]["confirm"].ToString()),""));
            }        
             string output = JsonConvert.SerializeObject(data);
             File.WriteAllText(@Server.MapPath("~/data/ncovData" + datestr + ".json"), output);
        }
        public string getHtml(string html)//传入网址
        {
            string pageHtml = "";
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            //获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(html); //从指定网站下载数据
            MemoryStream ms = new MemoryStream(pageData);
          //  using (StreamReader sr = new StreamReader(ms, Encoding.GetEncoding("GB2312")))
            using (StreamReader sr = new StreamReader(ms, Encoding.GetEncoding("utf-8")))
            {
                pageHtml = sr.ReadLine();
            }
            return pageHtml;
        }  
    }
  
}