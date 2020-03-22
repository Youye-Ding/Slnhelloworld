using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class HomeworkchkEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string output1 = "Email合法，而且顶级域名是";
            string output2 = "Email不合法";
            if (email.Split('@').Length == 2)
            {
                if (email.Split('@')[1].Split('.').Length == 2)
                {
                    string domainName = email.Split('@')[1].Split('.')[1];
                    Response.Write(output1 + domainName);
                }
                else
                    Response.Write(output2);
            }
            else
                Response.Write(output2);

        }
    }
}