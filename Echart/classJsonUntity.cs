using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echarts
{
    /// <summary>
    /// 对于JSON KV 实体的定义
    /// </summary>
    public class classKSingleValueJson
    {
        public classKSingleValueJson(string s, double d,string t)
        {
            this.name = s;
            this.value = d;
            this.text = t;
        }
        public string name { get; set; }
        public double value { get; set; }
        public string text { get; set; }
    }
    public class classKArrayValueJson
    {
        public classKArrayValueJson(string s, double[] d)
        {
            this.name = s;
            this.value = d;
        }
        public string name { get; set; }
        public double[] value { get; set; }
    }
}