using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Echarts
{
    public partial class countryClick : System.Web.UI.Page
    {
    //      var mydata = [
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
	
    //var guangdongData = [
    //    {name: '广州市',value: randomData() },{name: '佛山市',value: randomData() },
    //    {name: '肇庆市',value: randomData() },{name: '韶关市',value: randomData() },
    //    {name: '清远市',value: randomData() },{name: '云浮市',value: randomData() },
    //    {name: '茂名市',value: randomData() },{name: '湛江市',value: randomData() },
    //    {name: '江门市',value: randomData() },{name: '东莞市',value: randomData() },
    //    {name: '阳江市',value: randomData() },{name: '深圳市',value: randomData() },
    //    {name: '惠州市',value: randomData() },{name: '河源市',value: randomData() },
    //    {name: '汕尾市',value: randomData() },{name: '揭阳市',value: randomData() },
    //    {name: '河源市',value: randomData() },{name: '梅州市',value: randomData() },
    //    {name: '潮州市',value: randomData() },{name: '汕头市',value: randomData() },
    //    {name: '中山市',value: randomData() },{name: '珠海市',value: randomData() }
    //];
        protected void Page_Load(object sender, EventArgs e)
        {
            List<classKSingleValueJson> data = new List<classKSingleValueJson>();
            data.Add(new classKSingleValueJson("北京", 40000.34, "贷款笔数：54412"));
            data.Add(new classKSingleValueJson("天津", 38000, "贷款笔数：32412"));
            data.Add(new classKSingleValueJson("上海", 18000, "贷款笔数：22412"));
            data.Add(new classKSingleValueJson("河北", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("河南", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("广东", 12000, "贷款笔数：72412"));
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/ChineseBank.json"), output);
            List<classKSingleValueJson> provinceData = new List<classKSingleValueJson>();
            provinceData.Add(new classKSingleValueJson("广州市", 40000.34, "贷款笔数：54412"));
            provinceData.Add(new classKSingleValueJson("佛山市", 38000, "贷款笔数：32412"));
            provinceData.Add(new classKSingleValueJson("肇庆市", 18000, "贷款笔数：22412"));
            provinceData.Add(new classKSingleValueJson("云浮市", 15092, "贷款笔数：42412"));
            provinceData.Add(new classKSingleValueJson("江门市", 28000, "贷款笔数：52412"));
            provinceData.Add(new classKSingleValueJson("汕头市", 12000, "贷款笔数：72412"));
            output = JsonConvert.SerializeObject(provinceData);
            File.WriteAllText(@Server.MapPath("~/data/GuangdongBank.json"), output);
        }
    }
}