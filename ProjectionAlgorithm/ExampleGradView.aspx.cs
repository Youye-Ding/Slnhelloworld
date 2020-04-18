using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProjectionAlgorithm
{
    public partial class ExampleGradView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                SQLHelper sh = new SQLHelper();
                string sql = "select c_dy, c_dynasty_chn from DYNASTIES where (c_start!=0 and c_end!=0) or c_sort=0 order by c_sort";
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                try
                {
                    sh.RunSQL(sql, ref ds);
                    if (ds.Tables[0] != null)
                    {
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.NewRow();
                            dr["c_dynasty_chn"] = "请选择";
                            dr["c_dy"] = "-1";
                            dt.Rows.Add(dr);
                            DropDownList1.DataTextField = "c_dynasty_chn";
                            DropDownList1.DataValueField = "c_dy";
                            DropDownList1.DataSource = dt;
                            DropDownList1.DataBind();
                            DropDownList1.SelectedIndex = dt.Rows.Count - 1;
                        }
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
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            int dynastyValue = Convert.ToInt32 (DropDownList1.SelectedValue);
            string sqlDy = string.Format("select c_start, c_end from dynasties where c_dy={0}",dynastyValue);
            SQLHelper sh = new SQLHelper();
            SqlDataReader sdr;
            int start=0;
            int end=0;
            try
            {
                sh.RunSQL(sqlDy, out sdr);
                if (sdr.Read())
                {
                    start += Convert.ToInt32(sdr[0]);
                    end += Convert.ToInt32(sdr[1]);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sh.Close();
            }
            string sqlAddr = "select b.c_name_chn as c_name_chn, c.c_addr_id,c.x_coord as x_coord ,c.y_coord as y_coord from biog_addr_data A,biog_main B,ADDR_CODES c";
            string sqlExist = string.Format("select * from biog_main where c_index_year<={0} and c_index_year>={1} and c_name_chn='{2}'",end,start,name);
            if (name.Length !=0)
            {
                sqlAddr += string.Format (" where A.c_personid = B.c_personid AND c.c_addr_id = a.c_addr_id and b.c_name_chn='{0}' and",name);
                sqlAddr += string.Format(" (b.c_index_year<={0}and b.c_index_year>={1}) and c.x_coord is not null and c.y_coord is not null",end,start);
            }
            else
            {
                sqlAddr += " where A.c_personid = B.c_personid AND c.c_addr_id = a.c_addr_id and";
                sqlAddr += string.Format(" (b.c_index_year<={0}and b.c_index_year>={1}) and c.x_coord is not null and c.y_coord is not null", end, start);
            }
            SQLHelper sh1 = new SQLHelper();
            try
            {
                DataSet dsAddr = new DataSet();
                DataSet dsExist = new DataSet();
                sh1.RunSQL(sqlAddr, ref dsAddr);
                sh1.RunSQL(sqlExist, ref dsExist);
                DataTable dt2 = dsAddr.Tables[0];
                DataTable dt3 = dsExist.Tables[0];
                if (dt3.Rows.Count == 0)
                {
                    Response.Write("该朝代不存在此人！");
                }
                else if (dt2.Rows.Count == 0)
                {
                    Response.Write("此人没有足迹！");
                }
                else
                {
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sh1.Close();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}