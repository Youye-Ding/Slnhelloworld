using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slnhelloworld
{
    public partial class Caeser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = TextBox1.Text;
            int move = int.Parse(TextBox2.Text);
            string password = "";
            foreach (char c in str)
            {
                if (Convert.ToInt32(c) >= Convert.ToInt32('A') && Convert.ToInt32(c) <= Convert.ToInt32('Z'))
                {
                    password += (char)((Convert.ToInt32(c) - Convert.ToInt32('A') + move) % 26+ Convert.ToInt32('A'));
                }
                else if (Convert.ToInt32(c) >= Convert.ToInt32('a') && Convert.ToInt32(c) <= Convert.ToInt32('z'))
                {
                    password += (char)((Convert.ToInt32(c) - Convert.ToInt32('a') + move) % 26+ Convert.ToInt32('a'));
                }
                else
                    password += c;
            }
            Label1.Text = "密码是" + password;
        }
    }
}