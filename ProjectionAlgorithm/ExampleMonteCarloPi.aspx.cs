using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectionAlgorithm
{
    public partial class ExampleMonteCarloPi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int nums = 100000;
        protected void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        protected void chkPrintPoint_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double x, y;
            double p;
            double m;
            double pi;
            nums = int.Parse(txtNum.Text);
            Random rand = new Random();
            m = 0;
            for (int i=0;i<nums;i++)
            {
                x = rand.NextDouble() * 2 - 1;
                y = rand.NextDouble() * 2 - 1;
                if (x*x+y*y<=1)
                {
                    m++;
                }
                if (chkPrintPoint.Checked)
                    Response.Write(string.Format("</br>x={0},y={1}", x, y));
            }
            p = m / nums;
            pi = 4 * p;
            Response.Write("</br>落在圆区域内的次数：" + m);
            Response.Write("</br>随机点落在圆区域的概率：" + p);
            Response.Write("</br>π的值为：" + pi);
        }
    }
}