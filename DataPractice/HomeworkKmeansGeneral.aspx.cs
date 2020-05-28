using Common.AITools.Tvbboy;
using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataPractice
{
    public partial class HomeworkKmeansGeneral : System.Web.UI.Page
    {

        public void ShowClustered(string[] data, int[] clustering, int numClusters, int decimals)
        {
            for (int k = 0; k < numClusters; ++k)
            {
                Response.Write("===================</br>");
                for (int i = 0; i < data.Length; ++i)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k)
                        continue;
                    string v = data[i];
                    Response.Write(v);
                    Response.Write("</br>");
                }
                Response.Write("===================</br>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select name, (case gender when '男' then 1 else 0 end) as gender,military, power, wisdom, charm, life, country from TblGenerals";
            SQLHelper sh = new SQLHelper();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                if (ds.Tables[0]!=null)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count>0)
                    {
                        double[][] rawData = new double[dt.Rows.Count][];
                        string[] general = new string[dt.Rows.Count];
                        int i = 0;
                        int columns = dt.Columns.Count;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (i < dt.Rows.Count)
                            {
                                List<double> ls = new List<double>();
                                for (int j = 1; j < columns; j++)
                                    ls.Add(double.Parse(dr[j].ToString()));
                                rawData[i] = ls.ToArray();
                                general[i]= dr[0].ToString();
                                i++;
                            }
                        }
                        int numClusters = 2;
                        int[] clustering = ClassKmeans.Cluster(rawData, numClusters);
                        ShowClustered(general, clustering, numClusters, 1);
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
    }
}