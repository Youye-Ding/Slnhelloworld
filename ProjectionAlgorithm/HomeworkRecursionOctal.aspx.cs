using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectionAlgorithm
{
    public partial class HomeworkRecursionOctal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public StringBuilder onum = new StringBuilder();

        public StringBuilder ToOnum(int n)
        {
            if (n < 8)
            {
                return onum.Append(string.Format("{0}", n));
            }
            else if (n == 8)
            {
                return onum.Append(string.Format("01"));
            }
            else
            {
                onum.Append(string.Format("{0}", n % 8));
                n = (n - n % 8) / 8;
                return ToOnum(n);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(TextBox1.Text);
                string Onum = ToOnum(num).ToString();
                StringBuilder oonum = new StringBuilder();
                for (int i = Onum.Length - 1; i >= 0; i--)
                    oonum.Append(Onum.Substring(i, 1));
                string output = oonum.ToString();
                Response.Write(string.Format("{0}转化为八进制数为{1}", num, output));
            }
            catch
            {
                Response.Write("没有输入一个十进制整数！");
            }
        }
    }
}