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
    public partial class frm_Login : System.Web.UI.Page
    {
        cls_connectDB cls_con = new cls_connectDB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                cls_con.connect_DB();

                SqlCommand sqlcm = new SqlCommand("select *from tbl_acount where Tendn = @user and Matkhau = @pass", cls_con.sql_con); //tbl_acount1


                sqlcm.Parameters.Add(new SqlParameter("@user", txt_user.Text.Trim()));
                sqlcm.Parameters.Add(new SqlParameter("@pass", txt_pass.Text.Trim()));

                SqlDataReader sqlre = sqlcm.ExecuteReader();

                if (sqlre.Read())
                {
                    Session["login"] = 1;
                    Session["Quyen"] = sqlre["Quyen"].ToString();
                    Session["user"] = sqlre["Hoten"].ToString();



                    Response.Write("<script>alert('Đăng nhập thành công!')</script>");
                    Response.Redirect("TrangChu.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Đăng nhập không thành công!')</script>");
                    return;
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

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_user.Text = "";
            txt_pass.Text = "";
            txt_pass.Focus();
            txt_user.Focus();
        }
    }
}