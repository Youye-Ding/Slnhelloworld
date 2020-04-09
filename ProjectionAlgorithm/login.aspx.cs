using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data.SqlClient;
using Common.Framework.Tvbboy;
using System.Text;

namespace ProjectionAlgorithm
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        

        protected void Log_Click(object sender, EventArgs e)
        {
            string username = TuserName.Text;
            string pwd = TpassWord.Text;
            string sql = string.Format("select username,pwd from tblstudents where username='{0}' and pwd='{1}'",username,pwd );
            SQLHelper sh1 = new SQLHelper();
            SqlDataReader sdr ;
            string result=string.Empty;
            try
            {
                sh1.RunSQL(sql, out sdr);
                if (sdr.Read())
                {
                    try
                    {
                        StringBuilder updateSql = new StringBuilder("update tblStudentsForExcercise set ");
                        updateSql.Append("lastLoginTime=getdate(),");
                        updateSql.Append("logintimes=logintimes+1");
                        updateSql.Append(string.Format(" where username='{0}'", username));
                        Response.Write(updateSql);
                        
                    }
                    catch(Exception ex)
                    {
                        Response.Write("更新发生异常，原因：" + ex.Message);
                    }
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
                sh1.Close();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void passWord_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Reg2_Click(object sender, EventArgs e)
        {
            Response.Redirect("reg.aspx",false);
        }
    }
}