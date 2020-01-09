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
    public partial class DssvTheoCn : System.Web.UI.Page
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
                    string st_sql = "Select Masv, Tensv, Ngaysinh, Case Gioitinh when 0 then N'Nam' else N'Nữ' end, Email, Diachi, Khoahoc, Tencn from tbl_sinhvien inner join tbl_chuyennganh on tbl_sinhvien.Chuyennganh = tbl_chuyennganh.Macn where Tencn = @key";
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
                        st_kq = st_kq + "<tr><td>" + i + "</td><td>" + sqlre[0].ToString() + "</td><td>" + sqlre[1].ToString() + "</td><td>" + Convert.ToDateTime(sqlre[2].ToString()).ToString("dd/MM/yyyy") + "</td><td>" + sqlre[3].ToString() + "</td><td>" + sqlre[4].ToString() + "</td><td>" + sqlre[5].ToString() + "</td><td>" + sqlre[6].ToString() + "</td><td>" + sqlre[7].ToString() + "</td></tr>";
                    }
                    sqlre.Close();

                    ltr_sinhvien.Text = st_kq;

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