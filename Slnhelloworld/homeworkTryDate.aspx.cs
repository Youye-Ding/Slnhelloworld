using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class homeworkTryDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            try
            {
                string ID = TextBox1.Text;
                if (ID.Length ==18)
                {
                    int year = int.Parse(ID.Substring(6, 4));
                    int month = int.Parse(ID.Substring(10, 2));
                    int day = int.Parse(ID.Substring(12, 2));
                    int[] bigMon = { 1, 3, 5, 7, 8, 10, 12 };
                    int[] smallMon = { 4, 6, 9, 11 };
                    if (month>12)
                    {
                        flag = false;
                        Response.Write("月份错误<br/>");
                    }
                    else if (day==0)
                    {
                        flag = false;
                        Response.Write("日期错误<br/>");
                    }
                    else
                    {
                        if (bigMon.Contains(month) && day > 31)
                        {
                            flag = false;
                            Response.Write("大月不能超过31天<br/>");
                        }
                        else if (smallMon.Contains(month) && day > 30)
                        {
                            flag = false;
                            Response.Write("小月不能超过30天<br/>");
                        }
                        else if(month==2)
                        {
                            if (((year % 100 != 0 && year % 4 == 0) || year % 400 == 0) && day > 29)
                            {
                                flag = false;
                                Response.Write("闰年2月不能超过29天<br/>");
                            }
                            else if ((year%4!=0||(year%100==0 && year%400!=0)) && day>28)
                            {
                                flag = false;
                                Response.Write("平年2月不能超过28天<br/>");
                            }
                             
                        }
                    }
                }
                else
                {
                    flag = false;
                    Response.Write("身份证位数有误<br/>");
                }
                if (flag==true)
                {
                    Response.Write("校验通过<br/>");
                }
            }
            catch
            {
                Response.Write("其他错误<br/>");
            }
            finally
            {
                Response.Write("校验完毕<br/>");
            }
        }
    }
}