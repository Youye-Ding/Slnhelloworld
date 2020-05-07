using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSV;

namespace DataPractice
{
    public partial class TestOfPpcc : System.Web.UI.Page
    {
        public double calMean(double[] temp)
        {
            double sum = 0.0;
            double mean = 0.0;
            for (int i=0;i<temp.Length;i++)
            {
                sum += temp[i];
            }
            mean = sum / temp.Length;
            return mean;
        }
        public double Caldevar(double[] temp)
        {
            double mean = calMean(temp);
            double sum = 0.0;
            for (int i=0;i<temp.Length;i++)
            {
                sum += (temp[i] - mean) * (temp[i] - mean);
            }
            double deVar = Math.Sqrt(sum / temp.Length);
            return deVar;
        }
        public double calCov(double[] a,double[] b)
        {
            double cov = 0.0;
            if (a.Length !=b.Length )
            {
                return -1;
            }
            else
            {
                double sum = 0.0;
                double meanA = calMean(a);
                double meanB = calMean(b);
                for (int i=0;i<a.Length;i++)
                {
                    sum += (a[i] - meanA) * (b[i] - meanB);
                }
                cov = sum / a.Length;
            }
            return cov;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string filepath1 = @"data/000001.csv";
            string filepath2 = @"data/600519.csv";
            classCSVHelper csh = new classCSVHelper();
            filepath1 = Server.MapPath(filepath1);
            filepath2 = Server.MapPath(filepath2);
            DataTable dt1 = csh.readCsvSql(filepath1);
            DataTable dt2 = csh.readCsvSql(filepath2);
            double[] closingPrice1 = new double[25];
            for (int i=0;i<25;i++)
            {
                closingPrice1[i] = double.Parse(dt1.Rows[i][3].ToString());
                Response.Write(string.Format("{0},{1}</br>", i, closingPrice1[i]));
            }
            double[] closingPrice2 = new double[25];
            for (int i = 0; i < 25; i++)
            {
                closingPrice2[i] = double.Parse(dt2.Rows[i][3].ToString());
                Response.Write(string.Format("{0},{1}</br>", i, closingPrice2[i]));
            }
            double ppcc = calCov(closingPrice1, closingPrice2) / (Caldevar(closingPrice1) * Caldevar(closingPrice2));
            Response.Write("相关系数为" + ppcc);
        }
    }
}