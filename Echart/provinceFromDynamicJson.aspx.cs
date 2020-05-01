using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echarts
{
    public partial class provinceFromDynamicJson : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //         var provinceData = [
            //{ name: '济南市', value: randomData() }, { name: '烟台市', value: randomData() },
            //{ name: '淄博市', value: randomData() }, { name: '威海市', value: randomData() },
            //{ name: '青岛市', value: randomData() }, { name: '潍坊市', value: randomData() },
            //{ name: '滨州市', value: randomData() }, { name: '临沂市', value: randomData() },
            //{ name: '日照市', value: randomData() }, { name: '东营市', value: randomData() },
            //{ name: '德州市', value: randomData() }, { name: '枣庄市', value: randomData() },
            //{ name: '菏泽市', value: randomData() }, { name: '泰安市', value: randomData() },
            //{ name: '曲阜市', value: randomData() }, { name: '兖州市', value: randomData() },
            //{ name: '聊城市', value: randomData() }, { name: '济宁市', value: randomData() },
            //{ name: '莱芜市', value: randomData() }
            //];
            //自定义对象的JSON
            List<classKSingleValueJson> data = new List<classKSingleValueJson>();
            data.Add(new classKSingleValueJson("济南市", 40000.34, "贷款笔数：54412"));
            data.Add(new classKSingleValueJson("烟台市", 38000, "贷款笔数：32412"));
            data.Add(new classKSingleValueJson("青岛市", 18000, "贷款笔数：22412"));
            data.Add(new classKSingleValueJson("淄博市", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("威海市", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("潍坊市", 12000, "贷款笔数：72412"));
            data.Add(new classKSingleValueJson("临沂市", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("滨州市", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("日照市", 12000, "贷款笔数：72412"));
            data.Add(new classKSingleValueJson("东营市", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("德州市", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("枣庄市", 12000, "贷款笔数：72412"));
            data.Add(new classKSingleValueJson("菏泽市", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("泰安市", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("曲阜市", 12000, "贷款笔数：72412"));
            data.Add(new classKSingleValueJson("济宁市", 15092, "贷款笔数：42412"));
            data.Add(new classKSingleValueJson("聊城市", 28000, "贷款笔数：52412"));
            data.Add(new classKSingleValueJson("莱芜市", 12000, "贷款笔数：72412"));
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/shandongData.json"), output);
        }

    }
}