using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;

namespace DataPractice
{
    public partial class HomeworkBayesIris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double calyxLength = double.Parse(CalyxLength.Text);
            double calyxWidth = double.Parse(CalyxWidth.Text);
            double petalLength = double.Parse(PetalLength.Text);
            double petalWidth = double.Parse(PetalWidth.Text);
            string sql = "select Label, CalyxLength, CalyxWidth, PetalLength, PetalWidth from tblIris";
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
                        Response.Write(classifier.Classify(new double[] { calyxLength, calyxWidth, petalLength, petalWidth }));
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sh.Close();
            }
            
        }

        protected void CalyxLength_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CalyxWidth_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PetalLength_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PetalWidth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}