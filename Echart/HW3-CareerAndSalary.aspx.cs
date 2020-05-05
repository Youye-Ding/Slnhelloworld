using Echarts;
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

namespace Echart
{
    public partial class HW3_CareerAndSalary : System.Web.UI.Page
    {
        List<classKSingleValueJson> data = new List<classKSingleValueJson>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from career";
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                data.Add(
                    new classKSingleValueJson(
                        dr[0].ToString(),
                        double.Parse (dr[1].ToString ()),
                        "" 
                        )
                    );
            }
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/Career.json"), output);
        }
    }
}