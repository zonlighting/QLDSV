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
    public partial class Frm_XemDiem : System.Web.UI.Page
    {
        cls_connectDB cls_con = new cls_connectDB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cls_con.connect_DB();

                SqlCommand sqlcm = new SqlCommand("select *from tbl_diem where Masv = @ma", cls_con.sql_con);
                sqlcm.Parameters.Add(new SqlParameter("@ma", txt_search.Text.Trim()));
                SqlDataReader sqlre = sqlcm.ExecuteReader();

                if (sqlre.Read())
                {
                    Session["xemdiem"] = sqlre["Masv"].ToString(); ;
                    Response.Redirect("Frm_ChiTietXemDiem.aspx?search=" + txt_search.Text);

                }
                else
                {
                    Response.Write("<script>alert('Mã sinh viên không hợp lệ, vui lòng nhập lại!')</script>");
                    Response.Redirect("Frm_XemDiem.aspx");
                }
                sqlre.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Lỗi thao tác: " + ex);
            }
            finally
            {
                cls_con.close_DB();
            }

        }
    }
}