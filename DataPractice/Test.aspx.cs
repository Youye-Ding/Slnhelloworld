using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataPractice
{
    public partial class Test : System.Web.UI.Page
    {
        private double calMean(double[] temp)
        {
            double sum = 0.0;
            double mean = 0.0;
            for (int i = 0; i < temp.Length; i++)
            {
                sum += temp[i];
            }
            mean = sum / temp.Length;
            return mean;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] temp = new double[5];
            temp[0] = 1;
            temp[1] = 1;
            double mean = calMean(temp);
            Response.Write(mean);
            Response.Write(temp.Length);
            int j = 0;
            for (int i = 0; i < 5; i++)
                j++;
            Response.Write(j);

        }
    }
}