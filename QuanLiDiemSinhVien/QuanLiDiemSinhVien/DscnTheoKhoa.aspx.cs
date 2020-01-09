using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using QuanLiDiemSinhVien.All_class;

namespace QuanLiDiemSinhVien
{
    public partial class DscnTheoKhoa : System.Web.UI.Page
    {
        cls_connectDB cls_con = new cls_connectDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            int dangnhap = (Int32)Session["login"];
            if (dangnhap == 0)
            {
                Response.Redirect("Frm_Login.aspx");
            }
            else
            {
                try
                {
                    cls_con.connect_DB();
                    string st_id = Request.QueryString["id"].ToString();
                    string st_sql = "Select Macn, Tencn, Tenkhoa from tbl_chuyennganh inner join tbl_khoa on tbl_chuyennganh.Khoa = tbl_khoa.Makhoa where Tenkhoa = @key";
                    SqlCommand sqlcmd = new SqlCommand(st_sql, cls_con.sql_con);

                    //Thêm tham số @key cho câu truy vấn SQL
                    SqlParameter sqlpa = new SqlParameter();
                    sqlpa.Value = st_id;
                    sqlpa.ParameterName = "@key";
                    sqlcmd.Parameters.Add(sqlpa);

                    SqlDataReader sqlre = sqlcmd.ExecuteReader();
                    byte i = 0;
                    string st_kq = "";
                    while (sqlre.Read())
                    {
                        i++;
                        st_kq = st_kq + "<tr><td>" + i + "</td><td>" + sqlre[0].ToString() + "</td><td>" + sqlre[1].ToString() + "</td><td>" + sqlre[2].ToString() + "</td></tr>";
                    }
                    sqlre.Close();

                    ltr_cn.Text = st_kq;

                    sqlre.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi: " + ex);
                }
                finally
                {
                    cls_con.close_DB();
                }
            }

        }
    }
}