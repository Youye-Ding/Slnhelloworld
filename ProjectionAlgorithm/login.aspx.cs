﻿using System;
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
            string pwd = ClassMd5.Md5Hash32(TpassWord.Text);
            string sql = string.Format("select username,pwd from tblstudentsforexercise where username='{0}' and pwd='{1}'",username,pwd );
            SQLHelper sh1 = new SQLHelper();
            SqlDataReader sdr ;
            string result=string.Empty;
            try
            {
                sh1.RunSQL(sql, out sdr);
                if (sdr.Read())
                {
                    SQLHelper sh = new SQLHelper();
                    try
                    {
                        StringBuilder updateSql = new StringBuilder("update tblStudentsForExercise set ");
                        updateSql.Append("lastLoginTime=getdate(),");
                        updateSql.Append("logintimes=logintimes+1");
                        updateSql.Append(string.Format(" where username='{0}'", username));
                        sh.RunSQL(updateSql.ToString());
                    }
                    catch(Exception ex)
                    {
                        Response.Write("更新发生异常，原因：" + ex.Message);
                    }
                    finally
                    {
                        sh.Close();
                    }
                    result = "登录成功！";
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