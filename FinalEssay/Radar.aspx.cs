using Newtonsoft.Json;
using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalEssay
{
    public partial class Radar : System.Web.UI.Page
    {
        private double calS(double[] tmp)
        {
            double avg = tmp.Average();
            double sum = 0;
            double count = tmp.Count();
            double s = 0;
            foreach(double ch in tmp)
            {
                sum += (ch - avg) * (ch - avg);
            }
            s = Math.Sqrt(sum / count);
            return s;
        }
        private double calCov(double[] total,double[] grade)
        {
            double avgt = total.Average();
            double avgg = grade.Average();
            double count = total.Count();
            double sum = 0;
            double cov = 0;
            for(int i=0;i<total.Count();i++)
            {
                sum += (grade[i] - avgg) * (total[i] - avgt);
            }
            cov = sum / count;
            return cov;
        }
        private double calP(double[] total,double[] grade)
        {
            double p = calCov(total, grade) / (calS(total) * calS(grade));
            return Math.Round(p, 2);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select total, BIOGrade, GEOGrade, HISGrade, POLGrade from grade4 " +
                "where BIOGrade!=0 and GEOGrade!=0 and HISGrade!=0 and POLGrade!=0 order by 1 desc";
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            int N = ds.Tables[0].Rows.Count;
            int n = Convert.ToInt32(N / 3);
            double[][] data = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                List<double> total = new List<double>();
                List<double> bio = new List<double>();
                List<double> geo = new List<double>();
                List<double> his = new List<double>();
                List<double> pol = new List<double>();
                for (int k = i * n; k < N - (2 - i) * n; k++)
                {
                    total.Add(double.Parse(ds.Tables[0].Rows[k][0].ToString()));
                    bio.Add(double.Parse(ds.Tables[0].Rows[k][1].ToString()));
                    geo.Add(double.Parse(ds.Tables[0].Rows[k][2].ToString()));
                    his.Add(double.Parse(ds.Tables[0].Rows[k][3].ToString()));
                    pol.Add(double.Parse(ds.Tables[0].Rows[k][4].ToString()));
                }
                double[] Total = total.ToArray();
                double[] Bio = bio.ToArray();
                double[] Geo = geo.ToArray();
                double[] His = his.ToArray();
                double[] Pol = pol.ToArray();
                data[i] = new double[] { Math.Round(Total.Average() / 440, 2), calP(Total, Bio), calP(Total, Geo), calP(Total, His), calP(Total, Pol) };
            }
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/Radar.json"), output);
        }
    }
}