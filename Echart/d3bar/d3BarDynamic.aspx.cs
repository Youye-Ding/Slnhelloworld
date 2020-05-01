using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echarts.HistoricalRanking
{
    public partial class d3BarDynamic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<d3barEntity> data = new List<d3barEntity>();
            Random random = new Random();
            for (int i = 1949; i < 2020; i++)
            {
                data.Add(
                    new d3barEntity(
                                "小米", 
                                1000+1000*random.NextDouble(), 
                                "MI", 
                                (i.ToString()+"-1-1")
                            )
                 );
                data.Add(
                    new d3barEntity(
                            "华为", 
                            1000 + 1000 * random.NextDouble(), 
                            "Huawei", 
                            (i.ToString() + "-1-1")
                        )
                 );
                data.Add(
                    new d3barEntity(
                                "三星", 
                                1000 + 1000 * random.NextDouble(), 
                                "samsung", 
                                (i.ToString() + "-1-1")
                        )
                 );
                data.Add(
                    new d3barEntity(
                            "联想", 
                            1000 + 1000 * random.NextDouble(), 
                            "Lenovo", 
                            (i.ToString() + "-1-1")
                        )
                );
            }
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/named3.json"), output);
        }

    }
    public class d3barEntity
    {
        public d3barEntity(string n,double v,string t,string d)
        {
            name = n;
            value = v;
            type = t;
            date = d;
        }
        public string name { get; set; }
        public double value { get; set; }
        public string type { get; set; }
        public string date { get; set; }
    }
}