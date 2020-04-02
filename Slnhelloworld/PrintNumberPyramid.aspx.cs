using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class PrintNumberPyramid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(TextBox1.Text);
            if (num >= 10)
                return;
            else
            {
                for (int curLine = 1; curLine <= num; curLine++)
                {
                    for (int i = 0; i < num - curLine; i++)
                    {
                        Response.Write("&nbsp;&nbsp;");
                    }
                    for (int j = 1; j <= curLine; j++)
                    {
                        Response.Write(j.ToString());
                    }
                    for (int k = curLine - 1; k >= 1; k = k - 1)
                    {
                        Response.Write(k.ToString());
                    }
                    Response.Write("<br/>");
                }
            }

        }
    }
}