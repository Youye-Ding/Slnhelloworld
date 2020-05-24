using Common.AITools.Tvbboy;
using Newtonsoft.Json;
using SQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataPractice
{
    public partial class Test : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from tblstudents";
            SQLHelper sh = new SQLHelper();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            if (ds.Tables[0]!=null)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Response.Write(dr["face"]+"</br>");
                    }
                }
            }
        }

        
        
    }
}
