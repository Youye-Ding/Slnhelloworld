using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQL;
using Common.AITools.Tvbboy;

namespace DataPractice
{
    public partial class HomeworkBayesGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select (case gender when 1 then '男性' else '女性' end) as Gender, Footsize, Weight, Height from tblBodies";
            SQLHelper sh = new SQLHelper();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                if (ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DataTable table = new DataTable();
                        table.Columns.Add("gender");
                        table.Columns.Add("footsize", typeof(double));
                        table.Columns.Add("height", typeof(double));
                        table.Columns.Add("weight", typeof(double));
                        for (int i=0;i<Math.Ceiling(dt.Rows.Count*0.7);i++)
                        {
                            table.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                        }
                        ClassNaiveBayes classifier = new ClassNaiveBayes();
                        classifier.TrainClassifier(table);
                        int times = 0;
                        for (int j = int.Parse(Math.Ceiling(dt.Rows.Count * 0.7).ToString()); j < dt.Rows.Count; j++)
                        {
                            double footsize = double.Parse(dt.Rows[j]["footsize"].ToString());
                            double height = double.Parse(dt.Rows[j]["height"].ToString());
                            double weight = double.Parse(dt.Rows[j]["weight"].ToString());
                            string possiblegender = classifier.Classify(new double[] { footsize, height, weight });
                            string realgender = dt.Rows[j]["gender"].ToString();
                            Response.Write("预测性别为：" + possiblegender + "；");
                            Response.Write("实际性别为：" + realgender + "。");

                            if (possiblegender == realgender)
                            {
                                Response.Write("预测成功！" + "</br>");
                                times++;
                            }
                            else
                            {
                                Response.Write("预测失败！" + "</br>");
                            }
                        }
                        Response.Write(string.Format("共预测成功{0}次，成功率为{1}%。", times, 100*times / Math.Ceiling(dt.Rows.Count * 0.3)));
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
           }
           finally
            {
                sh.Close();
            }
        }

       
            
        

       
    }
}