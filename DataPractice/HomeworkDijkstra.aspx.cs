using SQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;
using Newtonsoft.Json;
using System.IO;

namespace DataPractice
{
    public partial class HomeworkDijkstra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sql = "select pointB from tblDistance2020 group by pointB";
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
                            //数据绑定
                            ddlPointA.DataTextField = "PointB";
                            ddlPointA.DataSource = dt;
                            ddlPointA.DataBind();
                            ddlPointB.DataTextField = "PointB";
                            ddlPointB.DataSource = dt;
                            ddlPointB.DataBind();
                            
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

        private void printRouteResult(RoutePlanResult _result)
        {
            Response.Write("</br>路径：");
            string[] tmp = _result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
                Response.Write(tmp[i] + "-->");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pointA = ddlPointA.SelectedItem.Text;
            string pointB = ddlPointB.SelectedItem.Text;
            if(pointA==pointB)
            {
                Response.Write("不能起始地为同一处！");
            }
            else
            {
                //生成图
                ArrayList nodeList = new ArrayList();
                string sql = "select PointA from tblDistance2020 group by PointA";
                SQLHelper sh1 = new SQLHelper();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                try
                {
                    sh1.RunSQL(sql, ref ds);
                    if (ds.Tables[0] != null)
                    {
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Node node = new Node(dr[0].ToString());
                                nodeList.Add(node);
                                string sql2 = string.Format("select * from tblDistance2020 where PointA='{0}'", dr[0].ToString());
                                SQLHelper sh2 = new SQLHelper();
                                DataTable dt2 = new DataTable();
                                DataSet ds2 = new DataSet();
                                sh2.RunSQL(sql2, ref ds2);
                                if (ds2.Tables[0]!=null)
                                {
                                    dt2 = ds2.Tables[0];
                                    if (dt2.Rows.Count>0)
                                    {
                                        foreach(DataRow dr2 in dt2.Rows)
                                        {
                                            node.EdgeList.Add(new Edge(dr2[1].ToString(), dr2[2].ToString(), double.Parse(dr2[3].ToString())));
                                        }
                                    }
                                }
                                sh2.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    sh1.Close();
                }

                string output = JsonConvert.SerializeObject(nodeList);
                File.WriteAllText(@Server.MapPath("~/data/SQL.json"), output);


                RoutePlanner planner = new RoutePlanner();
                RoutePlanResult result = null;
                try
                {
                    result = planner.Paln(nodeList, pointA, pointB);
                    Response.Write("距离为" + result.getWeight());
                    printRouteResult(result);
                    Response.Write(pointB);
                    Response.Write("</br>");
                    planner = null;
                }
                catch
                {
                    Response.Write("两地不能到达！");
                }
                
               
                
            }
        }
            
       
    }
}