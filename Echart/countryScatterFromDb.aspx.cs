using Newtonsoft.Json;
using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Echarts
{
    public partial class countryScatterFromDb : System.Web.UI.Page
    {
        List<classKArrayValueJson> dataTang = new List<classKArrayValueJson>();
        List<classKArrayValueJson> dataSong = new List<classKArrayValueJson>();
        StringBuilder sql=new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            try
            {
                sql.Append("select b.c_name_chn as c_name_chn, c.c_addr_id,c.x_coord as x_coord ,c.y_coord as y_coord from biog_addr_data A,biog_main B,ADDR_CODES c");
                sql.Append(" where A.c_personid = B.c_personid AND c.c_addr_id = a.c_addr_id and ");
                sql.Append(" ((b.c_deathyear<=907 and  b.c_birthyear>=618) or (b.c_deathyear>=618 and b.c_birthyear<=618)) and c.x_coord is not null and c.y_coord is not null");
                DataSet ds = new DataSet();
                sh.RunSQL(sql.ToString(), ref ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    dataTang.Add(
                        new classKArrayValueJson(
                            dr["c_name_chn"].ToString(), 
                            new double[] { double.Parse(dr["x_coord"].ToString()), double.Parse(dr["y_coord"].ToString()) }
                            )
                        );
                }
                string output = JsonConvert.SerializeObject(dataTang);
                File.WriteAllText(@Server.MapPath("~/data/cbdbpointTang.json"), output);

                sql.Clear();
                sql.Append("select b.c_name_chn as c_name_chn, c.c_addr_id,c.x_coord as x_coord ,c.y_coord as y_coord from biog_addr_data A,biog_main B,ADDR_CODES c");
                sql.Append(" where A.c_personid = B.c_personid AND c.c_addr_id = a.c_addr_id and ");
                 sql.Append(" ((b.c_deathyear<=1279 and  b.c_birthyear>=960) or (b.c_deathyear>=960 and b.c_birthyear<=960)) and c.x_coord is not null and c.y_coord is not null");
                DataSet ds1 = new DataSet();
                sh.RunSQL(sql.ToString(), ref ds1);
                DataTable dt1 = ds1.Tables[0];
                foreach (DataRow dr in dt1.Rows)
                {
                    dataSong.Add(
                        new classKArrayValueJson(
                                dr["c_name_chn"].ToString(), 
                                new double[] { double.Parse(dr["x_coord"].ToString()), double.Parse(dr["y_coord"].ToString()) }
                                )
                    );
                }
                output = JsonConvert.SerializeObject(dataSong);
                File.WriteAllText(@Server.MapPath("~/data/cbdbpointSong.json"), output);
            }
            catch (Exception ex)
            {
                Response.Write("数据库出错" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
         
        }

      
    

    }

}