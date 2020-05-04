using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echarts
{
    public partial class countryFromDynamicJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    //            var mydata = [
    //    {name: '北京',value: randomData() },{name: '天津',value: randomData() },
    //    {name: '上海',value: randomData() },{name: '重庆',value: randomData() },
    //    {name: '河北',value: randomData() },{name: '河南',value: randomData() },
    //    {name: '云南',value: randomData() },{name: '辽宁',value: randomData() },
    //    {name: '黑龙江',value: randomData() },{name: '湖南',value: randomData() },
    //    {name: '安徽',value: randomData() },{name: '山东',value: randomData() },
    //    {name: '新疆',value: randomData() },{name: '江苏',value: randomData() },
    //    {name: '浙江',value: randomData() },{name: '江西',value: randomData() },
    //    {name: '湖北',value: randomData() },{name: '广西',value: randomData() },
    //    {name: '甘肃',value: randomData() },{name: '山西',value: randomData() },
    //    {name: '内蒙古',value: randomData() },{name: '陕西',value: randomData() },
    //    {name: '吉林',value: randomData() },{name: '福建',value: randomData() },
    //    {name: '贵州',value: randomData() },{name: '广东',value: randomData() },
    //    {name: '青海',value: randomData() },{name: '西藏',value: randomData() },
    //    {name: '四川',value: randomData() },{name: '宁夏',value: randomData() },
    //    {name: '海南',value: randomData() },{name: '台湾',value: randomData() },
    //    {name: '香港',value: randomData() },{name: '澳门',value: randomData() }
    //];
            //自定义对象的JSON
            List<classKSingleValueJson> data = new List<classKSingleValueJson>();
            data.Add(new classKSingleValueJson("北京", 40000.34, "贷款笔数：54412"));
            data.Add(new classKSingleValueJson("天津", 38000, "贷款笔数：32412"));
            data.Add(new classKSingleValueJson("上海", 18000, "贷款笔数：22412"));
            data.Add(new classKSingleValueJson("河北", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("河南", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("广东", 12000, "贷款笔数：72412"));
            data.Add(new classKSingleValueJson("江苏", 12200, "贷款笔数：54268"));
            data.Add(new classKSingleValueJson("海南", 10263, "贷款笔数：81257"));
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/ChineseBank.json"), output);
        }
    }
}