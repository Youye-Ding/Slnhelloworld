using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectionAlgorithm
{
    
    public partial class HomeworkRecursionOffspring : System.Web.UI.Page
    {
        DataTable dt;
        int count;
        public void PrintOffpring(string EPARENTID)
        {
            if (EPARENTID == "0" || int.Parse(EPARENTID) >= 35)
                return;
            string condition = string.Format("EPARENTID='{0}'", EPARENTID);
            DataRow[] rows = dt.Select(condition);
            if(rows.Length>0)
            {
                for (int i=0;i<rows.Length ;i++)
                {
                    PrintOffpring(rows[i]["EID"].ToString());
                    Response.Write(rows[i]["ENAME"].ToString() + "</br>");
                    count++;
                }
                

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string sql1 = "select * from DynastyHanEmperor";
            string sql2 = string.Format("select * from DynastyHanEmperor where ename='{0}'",name);
            SQLHelper sh = new SQLHelper();
            DataSet ds1 = new DataSet();
            SqlDataReader sdr;
            sh.RunSQL(sql1, ref ds1);
            
            sh.RunSQL(sql2, out sdr);
            if (!sdr.Read ())
            {
                Response.Write(string.Format("{0}不是汉朝皇帝", name));
                sdr.Close();
            }
            else if (ds1.Tables.Count>0)
            {
                string EPARENTID = sdr["EID"].ToString();
                dt = ds1.Tables[0];
                count = 0;
                PrintOffpring(EPARENTID);
                Response.Write(string.Format("共有{0}个后代", count));
            }
            sh.Close();
        }
    }
}