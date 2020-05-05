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
    public partial class HW1_SciAdmissionByProvince : System.Web.UI.Page
    {
        List<classKArrayValueJson> province = new List<classKArrayValueJson>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from SciAdmissionByProvince";
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                province.Add(
                    new classKArrayValueJson(
                        dr[0].ToString(),
                        new double[] { double.Parse(dr[1].ToString()), double.Parse(dr[2].ToString()), double.Parse(dr[3].ToString()) }
                        )
                    );
            }
            string output = JsonConvert.SerializeObject(province);
            File.WriteAllText(@Server.MapPath("~/data/SciAdmissionByProvince.json"), output);
        }
    }
}