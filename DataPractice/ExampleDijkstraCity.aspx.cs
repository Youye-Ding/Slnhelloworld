using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;
using System.Collections;
using Newtonsoft.Json;
using System.IO;

namespace DataPractice
{
    public partial class ExampleDijkstraCity : System.Web.UI.Page
    {
        private void printRouteResult(RoutePlanResult  _result)
        {
            Response.Write("</br>路径：");
            string[] tmp = _result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
                Response.Write(tmp[i] + "-->");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string pointA = "北京";
            string pointB = "上海";
            ArrayList nodeList = new ArrayList();
            Node aNode = new Node("北京");
            nodeList.Add(aNode);
            aNode.EdgeList.Add(new Edge("北京", "上海", 20));
            aNode.EdgeList.Add(new Edge("北京", "武汉", 60));
            
            Node dNode = new Node("武汉");
            nodeList.Add(dNode);

            dNode.EdgeList.Add(new Edge("武汉", "北京", 40));
            //string output = JsonConvert.SerializeObject(nodeList);
            //File.WriteAllText(@Server.MapPath("~/data/ExampleSQL.json"), output);
            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = null;
            result = planner.Paln(nodeList, pointA, pointB);
            Response.Write("距离为" + result.getWeight());
            printRouteResult(result);
            Response.Write(pointB);
            Response.Write("</br>");
            planner = null;
        }
    }
}