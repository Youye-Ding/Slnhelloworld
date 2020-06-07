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
    public partial class BarScore : System.Web.UI.Page
    {
        private double calDif(string subject, double full)
        {
            string sql = string.Format("select {0}Grade from grade4 where {0}Grade !=0", subject);
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            List<double> grade = new List<double>();
            foreach (DataRow dr in ds.Tables[0].Rows)
                grade.Add(double.Parse(dr[0].ToString()));
            grade.ToArray();
            double mean = grade.Average();
            double p = Math.Round(mean / full, 2);
            return p;
        }

        private double calDis(string subject, double full)
        {
            string sql = string.Format("select {0}Grade from grade4 where {0}Grade !=0 order by 1 desc", subject);
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            List<double> grade = new List<double>();
            foreach (DataRow dr in ds.Tables[0].Rows)
                grade.Add(double.Parse(dr[0].ToString()));
            grade.ToArray();
            int n = grade.Count();
            int N = Convert.ToInt32(Math.Round(n * 0.27));
            double PL = 0;
            double PH = 0;
            for (int i=0;i<N;i++)
            {
                PH += grade[i] / (full * N);
            }
            for (int i=n-N;i<n;i++)
            {
                PL += grade[i] / (full * N);
            }
            double d = Math.Round(PH - PL, 2);
            return d;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] subject = { "CHN", "MAT", "ENG", "PHY", "CHM", "BIO", "GEO", "HIS", "POL" };
            string[] subjectC = { "语文", "数学", "英语", "物理", "化学", "生物", "地理", "历史", "政治" };
            double[] full = { 160, 160, 120, 100, 100, 100, 100, 100, 100 };
            string[][] data = new string[10][];
            data[0] =new string[] { "项目", "难度", "区分度" };
            for (int i=0;i<9;i++)
            {
                data[i + 1] = new string[] { subjectC[i], calDif(subject[i], full[i]).ToString(), calDis(subject[i], full[i]).ToString() };
            }
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/BarScore.json"), output);
        }
    }
}