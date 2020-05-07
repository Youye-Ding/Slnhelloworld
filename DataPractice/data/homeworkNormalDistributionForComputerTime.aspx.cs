using Common.AITools.Tvbboy;
using CSV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataPractice.data
{
    public partial class homeworkNormalDistributionForComputerTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

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
        private double Caldevar(double[] temp)
        {
            double mean = calMean(temp);
            double sum = 0.0;
            for (int i = 0; i < temp.Length; i++)
            {
                sum += (temp[i] - mean) * (temp[i] - mean);
            }
            double deVar = Math.Sqrt(sum / temp.Length);
            return deVar;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filepath = @"某公司统计的开机时间17000条左右.csv";
            classCSVHelper csh = new classCSVHelper();
            filepath = Server.MapPath(filepath);
            DataTable dt = csh.readCsvTxt(filepath, Encoding.Default);
            double[] Time = new double[dt.Rows.Count];
            int j = 0;
            //数据清洗
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString()!="" && double.Parse (dt.Rows[i][1].ToString ())>0)
                {
                    Time[j] = double.Parse(dt.Rows[i][1].ToString());
                    j++;
                }
            }
            //建立新数组，防止出现null值
            double[] openTime = new double[j];
            for (int i=0;i<j;i++)
            {
                openTime[i] = Time[i];
            }
            double mean = calMean(openTime);
            double devar = Caldevar(openTime);
            try
            {
                double second = double.Parse(TextBox1.Text);
                double z = (second - mean) / devar;
                double rate = 1-ClassStatistics.selfCaculate(z);
                Response.Write(string.Format("你的开机速度击败了{0:F}%的成员！", rate*100));
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}