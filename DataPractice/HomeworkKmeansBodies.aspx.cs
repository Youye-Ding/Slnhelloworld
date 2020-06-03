using Common.AITools.Tvbboy;
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

namespace DataPractice
{
    public partial class HomeworkKmeansBodies : System.Web.UI.Page
    {
        public void ShowData(double[][] data, int decimals, bool indices)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                if (indices)
                    Response.Write(i.ToString().PadLeft(3) + "&nbsp;&nbsp&nbsp&nbsp");
                for (int j = 0; j < data[i].Length; ++j)
                {
                    if (data[i][j] >= 0.0)
                        Response.Write("&nbsp;&nbsp&nbsp&nbsp");
                    Response.Write(data[i][j].ToString("F" + decimals) + "&nbsp;&nbsp&nbsp&nbsp ");
                }
                Response.Write("</br>");
            }
        }
        // ShowData 
        public void ShowVector(int[] vector, bool newLine)
        {
            for (int i = 0; i < vector.Length; ++i)
                Response.Write(vector[i] + "&nbsp;&nbsp;&nbsp;&nbsp; ");
            if (newLine == true)
                Response.Write("</br>");
        }

        public void ShowClustered(double[][] data, int[] clustering, int numClusters, int decimals)
        {
            for (int k = 0; k < numClusters; ++k)
            {
                Response.Write("===================</br>");
                for (int i = 0; i < data.Length; ++i)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k)
                        continue;
                    Response.Write("第" + i.ToString() + "项&nbsp;&nbsp; ");
                    for (int j = 0; j < data[i].Length; ++j)
                    {
                        double v = data[i][j];
                        Response.Write(v.ToString("F" + decimals) + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                    Response.Write("</br>");
                }
                Response.Write("===================</br>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select height, weight, footsize from TblBodies";
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
                        double[][] rawData = new double[dt.Rows.Count][];
                        int i = 0;
                        int columns = dt.Columns.Count;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (i < dt.Rows.Count)
                            {
                                List<double> ls = new List<double>();
                                for (int j = 0; j < columns; j++)
                                    ls.Add(double.Parse(dr[j].ToString()));
                                rawData[i] = ls.ToArray();
                                i++;
                            }
                        }
                        int numClusters = 2;
                        int[] clustering = ClassKmeans.Cluster(rawData, numClusters);
                        Response.Write("K=2时，分类如下：</br>");
                        ShowClustered(rawData, clustering, numClusters, 1);
                        numClusters = 3;
                        int[] clustering2 = ClassKmeans.Cluster(rawData, numClusters);
                        Response.Write("K=3时，分类如下：</br>");
                        ShowClustered(rawData, clustering2, numClusters, 1);
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