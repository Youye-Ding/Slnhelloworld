using Newtonsoft.Json;
using System;
using System.IO;

namespace Echarts
{
    public partial class scatterFromDynamicJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
             //data: [["14.616", "7.241", "0.896"], ["3.958", "5.701", "0.955"]]
            //不规则二维数组
            double[][] data = new double[4][];
            data[0] = new double[3] { 14.616, 7.241, 0.896 };
            data[1] = new double[3] { 3.958, 5.701, 0.955 };
            data[2] = new double[3] { 2.768, 8.971, 0.669 };
            data[3] = new double[3] { 9.051, 9.710, 0.171 };
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/dynamicScatterJson.json"), output);
        }
    }
   
}