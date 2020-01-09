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
    public partial class DoiMatKhau : System.Web.UI.Page
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
                if ((Session["Quyen"].ToString() == "1") || (Session["Quyen"].ToString() == "2") || (Session["Quyen"].ToString() == "3"))
                {
                    if (!IsPostBack)
                    {
                        try
                        {
                            cls_con.connect_DB();
                            string st_sql = "SELECT * FROM tbl_acount WHERE Hoten=@ma ;";

                            SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                            ////---------Truyền tham số cho câu lệnh sql-----
                            SqlParameter sqlpa = new SqlParameter();
                            sqlpa.ParameterName = "@ma";
                            sqlpa.Value = Request.QueryString["id"].ToString();
                            sqlcm.Parameters.Add(sqlpa);

                            //--Thực thi và hiển thị dữ liệu cũ vào textbox
                            SqlDataReader re = sqlcm.ExecuteReader();
                            re.Read();
                            txt_user.Text = re["Tendn"].ToString();
                            txt_user.ReadOnly = true;

                            re.Close();
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

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                cls_con.connect_DB();
                string st_user, st_newpass;
                st_user = txt_user.Text.Trim();
                st_newpass = txt_newpass.Text.Trim();

                string st_sql = "UPDATE tbl_acount SET Matkhau=@pass WHERE Tendn=@user;";
                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                SqlParameter sqlpa = new SqlParameter();
                sqlpa.ParameterName = "@pass";
                sqlpa.Value = st_newpass;
                sqlcm.Parameters.Add(sqlpa);

                sqlpa = new SqlParameter();
                sqlpa.ParameterName = "@user";
                sqlpa.Value = st_user;
                sqlcm.Parameters.Add(sqlpa);

                sqlcm.ExecuteNonQuery();

                lbl_tb.Text = "Đã đổi mật khẩu thành công !";
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

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoiMatKhau.aspx");
        }
    }
}