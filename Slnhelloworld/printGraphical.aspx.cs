using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class printGraphical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int i1 = 0; i1 < 4 - i; i1++)
                {
                    Response.Write('*');
                }
                Response.Write("<br/>");
            }
            for (int j = 0; j < 4; j++)
            {
                for (int j1 = 0; j1 < 3 - j; j1++)
                {
                    Response.Write("&nbsp;");
                }
                for (int j2 = 3 - j; j2 < 4; j2++)
                {
                    Response.Write("*");
                }
                Response.Write("<br/>");
            }
            int lineno;
            for (lineno = 0; lineno < 4; lineno++)
            {
                for (int k1=0;k1<4- lineno; k1++)
                {
                    Response.Write("&nbsp");
                }
                for (int k2=0;k2<2*lineno-1;k2++)
                {
                    Response.Write('*');
                }
                Response.Write("<br/>");
            }

        }
    }
}