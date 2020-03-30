using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjectionAlgorithm
{
    public partial class ExampleRandom3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                Response.Write(random.Next(1, 100) + "<br/>");
            }
        }
    }
}