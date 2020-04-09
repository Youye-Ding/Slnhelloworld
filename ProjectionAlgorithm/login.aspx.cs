using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data.SqlClient;

namespace ProjectionAlgorithm
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = TuserName.Text;
            string passWord = TpassWord.Text;
            string sql = string.Format("select studentNo,studentName from tblstudents where studentNo='{1}' and studentName='{0}'",userName,passWord );
            SQLHelper sh = new SQLHelper();
            SqlDataReader sdr ;
            string result=string.Empty;
            try
            {
                sh.RunSQL(sql, out sdr);
                if (sdr.Read())
                {
                    result = "登陆成功！";
                }
                else
                {
                    result = "登录失败！";
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                Response.Write(result);
                sh.Close();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void passWord_TextChanged(object sender, EventArgs e)
        {

        }
    }
}