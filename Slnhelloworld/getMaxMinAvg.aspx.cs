using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class getMaxMinAvg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] num = { 15.2, 453, 76, 14, 53, 98, 13 };
            double max = num[0], min = num[0], sum = num[0], avg;
            for (int i = 1; i < num.Length; i++)
            {
                if (num[i] < min)
                    min = num[i];
                if (num[i] > max)
                    max = num[i];
                sum += num[i];
            }
            avg = sum / num.Length;
            Response.Write(String.Format("数组中的最大数为{0}，最小数为{1}，平均值为{2}", max, min, avg));
        }
    }
}