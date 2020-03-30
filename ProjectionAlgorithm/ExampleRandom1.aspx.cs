using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectionAlgorithm
{
    public partial class ExampleRandom1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i=0;i<10;i++)
            {
                Random rd = new Random();
                Response.Write(rd.Next(1, 100).ToString() + "<br/>");
            }
        }
    }
}