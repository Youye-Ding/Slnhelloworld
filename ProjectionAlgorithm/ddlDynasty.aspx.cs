using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectionAlgorithm
{
    public partial class ddlDynasty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            string sql = "select c_dy, c_dynasty_chn from DYNASTIES order by c_sort";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql,ref ds);
                if (ds.Tables[0]!=null)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count>0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["c_dynasty_chn"] = "请选择";
                        dr["c_dy"] = "-1";
                        dt.Rows.Add(dr);
                        DropDownList1.DataTextField = "c_dynasty_chn";
                        DropDownList1.DataValueField = "c_dy";
                        DropDownList1.DataSource = dt;
                        DropDownList1.DataBind();
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