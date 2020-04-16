using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;

namespace ProjectionAlgorithm
{
    public partial class homeworkAltname : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string sql = string.Format("select c_alt_name_chn  from BIOG_MAIN ,ALTNAME_DATA where BIOG_MAIN.c_personid=ALTNAME_DATA.c_personid and c_name_chn='{0}'", name);
            SQLHelper sh = new SQLHelper();
            SqlDataReader sdr;
            SqlDataReader sdr2;
            string SQL = string.Format("select * from BIOG_MAIN where c_name_chn={0}", name);
            try
            {
                sh.RunSQL(sql, out sdr);
                sh.RunSQL(SQL, out sdr2);
                if (sdr.Read())
                {
                    Response.Write(string.Format("{0}的曾用名：<br/>", name) + sdr[0].ToString() + "<br/>");
                    while (sdr.Read())
                    {
                        Response.Write(sdr[0].ToString() + "<br/>");
                    }
                    sdr.Close();
                }
                else if (!sdr.Read()&&sdr2.Read())
                {
                    Response.Write("该人没有曾用名！");
                }
                else
                {
                    Response.Write("查无此人！");
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