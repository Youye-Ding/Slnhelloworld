using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echarts
{
    public partial class pieFromDynamicJson : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
              //{ name: 'A', value: 1212 },
              //{ name: 'B', value: 2323 },
              //{ name: 'C', value: 1919 }
            //自定义对象的JSON
            List<classKSingleValueJson> data = new List<classKSingleValueJson>();
            data.Add(new classKSingleValueJson("同意", 100.0,""));
            data.Add(new classKSingleValueJson("不同意", 20,""));
            data.Add(new classKSingleValueJson("都可以", 50,""));
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/dynamicPieJson.json"), output);
        }
    }
 
}