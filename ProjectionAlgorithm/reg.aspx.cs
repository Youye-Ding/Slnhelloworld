using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Framework.Tvbboy;
using SQL;

namespace ProjectionAlgorithm
{
    public partial class reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void passWord_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ConpassWord_TextChanged(object sender, EventArgs e)
        {

        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            string username = userName.Text;
            string pwd = passWord.Text;
            string conpwd = ConpassWord.Text;
            DateTime birthday = DateTime.Parse(Calendar1.SelectedDate.ToString("yyyy-MM-dd"));
            SQLHelper sh = new SQLHelper();
            try
            {
                string colList = "birthday,logintimes,username,pwd,gender,lastLoginTime";
                int logintimes = 0;
                int gender=0;
                if (Male.Checked)
                {
                    gender = 1;
                }
                if (Female.Checked)
                {
                    gender = 0;
                }
                DateTime lastLoginTime = DateTime.Now;
                //判断是否已经注册过
                bool flag1 = false;
                string sql = string.Format("select username from tblStudentsForExercise where username='{0}'", username);
                SQLHelper sh1 = new SQLHelper();
                SqlDataReader sdr;
                string result = string.Empty;
                try
                {
                    sh1.RunSQL(sql, out sdr);
                    if (!sdr.Read())
                    {
                        flag1=true;
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
                //开始注册
                if (flag1==true)
                {
                    if (pwd == conpwd)
                    {
                        //判断密码是否含有字母和数字
                        int strengthLevel = 0;
                        int letter = 0;
                        int number = 0;
                        foreach(char i in pwd)
                        {
                            if ((i>='a' && i<='z')||(i>='A'&& i<='Z'))
                            {
                                letter++;
                            }
                            if (i>='0' &&i<='9')
                            {
                                number++;
                            }
                        }
                        if (letter>0 && number>0)
                        {
                            strengthLevel++;
                        }

                        //开始注册
                        if (pwd.Length < 6)
                        {
                            msg += "密码强度不够，不得少于6位！";
                        }
                        else if (strengthLevel==0)
                        {
                            msg += "密码必须同时包含字母和数字！";
                        }
                        else
                        {
                            string npwd = ClassMd5.Md5Hash32(pwd);
                            StringBuilder insertSql = new StringBuilder(string.Format("insert into tblStudentsForExercise ({0})", colList));
                            insertSql.Append("values(");
                            insertSql.Append(string.Format("'{0}',", birthday));
                            insertSql.Append(string.Format("{0},", logintimes));
                            insertSql.Append(string.Format("'{0}',", username));
                            insertSql.Append(string.Format("'{0}',", npwd));
                            insertSql.Append(string.Format("{0},", gender));
                            insertSql.Append(string.Format("'{0}'", lastLoginTime));
                            insertSql.Append(")");

                            sh.RunSQL(insertSql.ToString ());
                            Response.Redirect ("login.aspx");

                        }

                    }
                    else
                    {
                        msg += "密码和确认密码不一致！";
                    }
                }
                else
                {
                    msg += "该用户名已注册！";
                }
            }
            catch (Exception ex)
            {
                msg = "数据库插入发生异常，原因： " + ex.Message;
            }
            finally
            {
                sh.Close();
            }
            Response.Write(msg);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Male_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Female_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}