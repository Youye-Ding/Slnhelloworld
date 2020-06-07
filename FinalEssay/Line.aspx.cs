using Newtonsoft.Json;
using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalEssay
{
    public partial class Line : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select ntbl3.school as 学校, avg(ntbl1.total) as 高一上期中, avg(ntbl2.total) as 高一上期末, " +
                "avg(ntbl3.total) as 高一下期中, avg(ntbl4.total) as 高一下期末 from " +
                "(select ID, school, total from grade1 where CHNGrade != 0 and MATGrade != 0 and ENGGrade != 0) as ntbl1," +
                "(select IID, total from grade2 where CHNGrade != 0 and MATGrade!= 0 and ENGGrade!= 0) as ntbl2," +
                "(select ID, IID, school, total from grade3 where CHNGrade != 0 and MATGrade!= 0 and ENGGrade!= 0) as ntbl3," +
                "(select ID, school, total from grade4 where CHNGrade != 0 and MATGrade!= 0 and ENGGrade!= 0) as ntbl4 " +
                "where ntbl1.ID = ntbl3.ID and ntbl1.ID = ntbl4.ID and ntbl2.IID = ntbl3.IID " +
                "group by ntbl3.school";
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            string[][] data = new string[3][];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                data[i]= new string[] { dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString() };
                i++;
            }
            string output = JsonConvert.SerializeObject(data);
            File.WriteAllText(@Server.MapPath("~/data/Line.json"), output);
        }
    }
}