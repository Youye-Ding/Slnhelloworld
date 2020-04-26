using Newtonsoft.Json;
using SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Echart
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select DYNASTIES.c_dynasty_chn as 朝代, DYNASTIES.c_sort, count(*) as 人数 " +
                "from DYNASTIES, BIOG_MAIN " +
                "where BIOG_MAIN.c_index_year between DYNASTIES.c_start and DYNASTIES.c_end " +
                "and BIOG_MAIN.c_index_year != 0 and BIOG_MAIN.c_index_year is not null " +
                "and dynasties.c_start != 0 and DYNASTIES.c_end != 0 " +
                "group by DYNASTIES.c_dynasty_chn, DYNASTIES.c_sort " +
                "order by DYNASTIES.c_sort";
            SqlDataReader sdr;
            SQLHelper sh = new SQLHelper();


            string[] category = new string[73];
            string[] data1 = new string[73];

            try
            {
                sh.RunSQL(sql, out sdr);
                int i = 0;
                while (sdr.Read())
                {
                    category[i] = sdr["朝代"].ToString();
                    data1[i] = sdr["人数"].ToString();
                    i++;
                }
                sdr.Close();
                for (int j = 0; j < 73; j++)
                {
                    Response.Write(category[j]);
                    Response.Write(data1[j]);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {

                sh.Close();
            }
            List<string[]> ls = new List<string[]>();
            ls.Add(category);
            ls.Add(data1);
            Response.Write(ls.ToString());
            string output = JsonConvert.SerializeObject(ls);
            File.WriteAllText(@Server.MapPath("~/data/BarOfDynasties.json"), output);
        }
        public class classKSingleValueJson
        {
            public classKSingleValueJson(string s, double d)
            {
                this.name = s;
                this.value = d;
            }
            public string name { get; set; }
            public double value { get; set; }
        }
        public class classKArrayValueJson
        {
            public classKArrayValueJson(string s, string[] d)
            {
                this.name = s;
                this.value = d;
            }
            public string name { get; set; }
            public string[] value { get; set; }
        }
    
    }
}