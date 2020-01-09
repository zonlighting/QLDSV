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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //cls_connectDB cls_con = new cls_connectDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["user"]) != "")
                {
                    lbl_user.Text = Session["user"].ToString();
                }
                else
                {
                    Response.Redirect("Frm_Login.aspx");
                }

                int dangnhap = (Int32)Session["login"];
                string kq = "";
                if (dangnhap == 0)
                {
                    Response.Redirect("Frm_Login.aspx");
                }
                else
                {
                    if (Session["Quyen"].ToString() == "1")
                    {
                        kq = @"<li><a href='QuanLyKhoa.aspx'><i class='fa fa-pie-chart fa-fw'></i>Quản lý khoa</a></li>
                                <li><a href='QuanLyChuyenNganh.aspx'><i class='fa fa-share-alt fa-fw'></i>Quản lý chuyên ngành</a></li>
                                <li><a href='QuanLyNguoiDung.aspx'><i class='fa fa-users fa-fw'></i>Quản lý người dùng</a></li>";
                        Ltr_phanquyen.Text = kq;
                    }
                    else if (Session["Quyen"].ToString() == "2")
                    {
                        kq = @"<li><a href='QuanLyMonHoc.aspx'><i class='fa fa-map-o fa-fw'></i>Quản lý môn học</a></li>
                                <li><a href='QuanLySinhVien.aspx'><i class='fa fa-graduation-cap fa-fw'></i>Quản lý sinh viên</a></li>";
                        Ltr_phanquyen.Text = kq;
                    }
                    else if (Session["Quyen"].ToString() == "3")
                    {
                        kq = @"<li><a href='QuanLyDiem.aspx'><i class='fa fa-bank fa-fw'></i>Quản lý điểm</a></li>";
                        Ltr_phanquyen.Text = kq;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Lỗi thao tác: " + ex);
            }
            finally
            {
                //cls_con.close_DB();
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["login"] = 0;
            Response.Redirect("Frm_Login.aspx");
        }

        protected void lbt_doimatkhau_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoiMatKhau.aspx?id=" + Session["user"].ToString());
        }
    }
}