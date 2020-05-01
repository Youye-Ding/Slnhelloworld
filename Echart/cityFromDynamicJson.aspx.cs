using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echarts
{
    public partial class cityFromDynamicJson : System.Web.UI.Page
    {

        //     var dt = [
        //    { name: '芙蓉区', value: 40000.34, text: '贷款笔数：54412'},
        //    { name: '岳麓区', value: 38000, text: '缴存人数：32412' },
        //    { name: '开福区', value: 18000, text: '缴存人数：22412' },
        //    { name: '天心区', value: 15092, text: '缴存人数：42412' },
        //    { name: '雨花区', value: 28000, text: '缴存人数：52412' },
        //    { name: '望城区', value: 12000, text: '缴存人数：72412' },
        //    { name: '长沙县', value: 32000, text: '缴存人数：82412' },
        //    { name: '宁乡县', value: 5100, text: '缴存人数：6412' },
        //    { name: '浏阳市', value: 2200, text: '缴存人数：3412' },
        //    { name: '分中心', value: 4918, text: '缴存人数：66412' }
        //];
        protected void Page_Load(object sender, EventArgs e)
        {
            //自定义对象的JSON
            List<classKSingleValueJson> data = new List<classKSingleValueJson>();
            data.Add(new classKSingleValueJson("芙蓉区", 40000.34, "贷款笔数：54412"));
            data.Add(new classKSingleValueJson("岳麓区", 38000, "贷款笔数：32412"));
            data.Add(new classKSingleValueJson("开福区", 18000, "贷款笔数：22412"));
            data.Add(new classKSingleValueJson("天心区", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("雨花区", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("望城区", 12000, "贷款笔数：72412"));
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/changshaBank.json"), output);
        }
    }

}