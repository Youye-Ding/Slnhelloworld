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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double footSize = double.Parse(FootSize.Text);
            double height = double.Parse(Height.Text);
            double weight = double.Parse(Weight.Text);
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
                        ClassNaiveBayes classifier = new ClassNaiveBayes();
                        classifier.TrainClassifier(dt);
                        Response.Write(classifier.Classify(new double[] { footSize, height, weight }));
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

        protected void FootSize_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Weight_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Height_TextChanged(object sender, EventArgs e)
        {

        }
    }
}