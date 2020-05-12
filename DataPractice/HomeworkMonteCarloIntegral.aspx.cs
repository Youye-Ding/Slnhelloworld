using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataPractice
{
    public partial class HomwworkMonteCarloIntegral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int nums = int.Parse(TextBox1.Text);
            double x, y;
            double p = 0;//概率
            double m = 0;//随机点落入规定面积中的数量
            double s = 0.0;//积分值
            double exp = 0.0;
            Random rand = new Random();
            for (int i = 0; i <= nums; i++)
            {
                x = rand.NextDouble() * (-1) + 2;
                y = rand.NextDouble() * (-1) + 1;
                if (y <= 1 / x)
                {
                    m++;
                }
            }
            p = m / nums;
            s = p;
            exp = Math.Pow(2, 1 / s);
            Response.Write("e的估计值为" + exp);
        }
    }
}