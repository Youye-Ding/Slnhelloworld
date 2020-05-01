using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echarts
{
    public partial class barFromDynamicJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //将1维数组处理成
           //"{"data":[5, 20, 36, 10, 12, 20],"category":["衬衫","羊毛衫","雪纺衫","裤子","高跟鞋","袜子"]}";         
           string[] category = new string[] { "衬衫","羊毛衫","雪纺衫","裤子","高跟鞋","袜子" };
           string[] data1 = new string[] { "5", "20", "36", "10", "12", "20" };
           List<string[]> ls = new List<string[]>();
           ls.Add(category);
           ls.Add(data1);
           string output = JsonConvert.SerializeObject(ls);
           File.WriteAllText(@Server.MapPath("~/data/dynamicBarJson.json"), output);
        }
       
    }
}