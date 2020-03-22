using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class IDcard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text;
            string output;
            string a = "0123456789Xx";
            string b = "0123456789";
            bool flag1 = true, flag2 = true, flag3 = true, flag4 = true;
            string year, month, day, gender;
            for (int i = 0; i < id.Length - 1; i++)
            {
                if (b.IndexOf(id.Substring(i,1)) == -1)
                    flag3 = false;
            }

            if (id.Length != 18)
            {
                Response.Write("位数不合法！");
                flag1 = false;
            }
            else
            {
                if (a.IndexOf(id.Substring(17)) == -1)
                {
                    Response.Write("第18位不合法！");
                    flag2 = false;
                }
                if (flag3 == false)
                    Response.Write("前17位含非数字！");

                if (int.Parse(id.Substring(6, 4)) < 1949 && int.Parse(id.Substring(6, 4)) > 2020 && int.Parse(id.Substring(10, 2)) >= 32)
                {
                    Response.Write("出生日期不合法！");
                    flag4 = false;
                }
            }
            if (flag1 == true && flag2 == true && flag3 == true && flag4 == true)
            {
                year = id.Substring(6, 4);
                month = id.Substring(10, 2);
                day = id.Substring(12, 2);
                if (int.Parse(id.Substring(16, 1)) % 2 == 0)
                    gender = "女";
                else
                    gender = "男";
                output = String.Format("此人在{0}年{1}月{2}日出生，性别为{3}", year, month, day, gender);
                Response.Write(output);
            }
            ;

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}