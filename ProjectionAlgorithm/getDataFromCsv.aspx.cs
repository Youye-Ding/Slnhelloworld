using System;
using System.Data;
using System.Text;
using CSV;
namespace dataPractice
{
    public partial class getDataFromCsv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filepath = txtFilePath.Text;
            classCSVHelper csh = new classCSVHelper();
            filepath = Server.MapPath(filepath);
           
            DataTable dt1 = csh.readCsvSql(filepath);
            DataTable dt = csh.readCsvTxt(filepath, Encoding.Default);
            int i=0;
            double[] closingPrice=new double[dt1.Rows.Count];
            foreach (DataRow dr in dt1.Rows)
            {
                closingPrice[i++] = double.Parse(dr[3].ToString());
            }

        }
    }
}
