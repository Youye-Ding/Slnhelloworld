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
    public partial class BoxPlot : System.Web.UI.Page
    {

        private double[] formData(string name)
        {
            string sql = string.Format("select total from grade4 where School='{0}' and CHNGrade!=0 and MATGrade!=0 and ENGGrade!=0", name);
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            List<double> num = new List<double>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
                num.Add(double.Parse(dr["total"].ToString()));
            double[] Num = num.ToArray();
            sh.Close();
            return Num;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<double[]> grade = new List<double[]>();
            grade.Add(formData("江苏省通州高级中学"));
            grade.Add(formData("江苏省西亭高级中学"));
            grade.Add(formData("平潮中学"));
            grade.Add(formData("金沙中学"));
            grade.Add(formData("三余中学"));
            string output = JsonConvert.SerializeObject(grade);
            File.WriteAllText(@Server.MapPath("~/data/BoxPlot.json"), output);

        }
    }
}