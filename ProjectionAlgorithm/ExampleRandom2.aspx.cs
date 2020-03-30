using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectionAlgorithm
{
    public partial class ExampleRandom2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Response.Write(random.Next(1, 100) + "<br/>");
            }
        }
    }
}