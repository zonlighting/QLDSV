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
    public partial class XemDiemChiTiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int dangnhap = (Int32)Session["login"];
            if (dangnhap == 0)
            {
                Response.Redirect("Frm_Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadInfoForm();
                    LoadScoreTable();
                }
            }

        }
        public void LoadInfoForm()
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {
                cls_con.connect_DB();
                string st_sql = "Select Masv, Tensv, Ngaysinh, Gioitinh, Email, Diachi, tencn, Khoahoc from tbl_sinhvien inner join tbl_chuyennganh on (Chuyennganh = macn) where Masv = @ma;";
                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                sqlcm.Parameters.Add(new SqlParameter("Ma", Convert.ToInt32(Request.QueryString["search"])));
                SqlDataReader sqlre = sqlcm.ExecuteReader();

                sqlre.Read();
                lbl_masv.Text = sqlre["Masv"].ToString();
                lbl_tensv.Text = sqlre["Tensv"].ToString();
                if (sqlre["Ngaysinh"] != DBNull.Value)
                {
                    lbl_ngaysinh.Text = Convert.ToDateTime(sqlre["Ngaysinh"]).ToString("dd/MM/yyyy");
                }

                if (sqlre["Gioitinh"].ToString() == "True")
                {
                    lbl_sex.Text = "Nữ";
                }
                else if (sqlre["Gioitinh"].ToString() == "False")
                {
                    lbl_sex.Text = "Nam";
                }
                lbl_email.Text = sqlre["Email"].ToString();
                lbl_diachi.Text = sqlre["Diachi"].ToString();
                lbl_chuyennganh.Text = sqlre["tencn"].ToString();
                lbl_khoahoc.Text = sqlre["Khoahoc"].ToString();

                sqlre.Close();



            }
            catch (Exception ex)
            {
                Response.Write("Lỗi :" + ex);
            }
            finally
            {
                cls_con.close_DB();
            }
        }
        public void LoadScoreTable()
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {

                string sql = @"SELECT      Mamh, Tenmh, DiemC, DiemB, Diemthilan1, Diemthilan2, DiemTB, Xeploai, tbl_diem.Hocki, Namhoc 
                    FROM            (dbo.tbl_diem inner join dbo.tbl_monhoc ON Monhoc = Mamh)
                    WHERE      Masv = @masv;";
                cls_con.connect_DB();
                SqlCommand sqlcm = new SqlCommand(sql, cls_con.sql_con);
                sqlcm.Parameters.Add(new SqlParameter("Masv", Convert.ToInt32(Request.QueryString["search"])));
                SqlDataReader sqlre = sqlcm.ExecuteReader();
                string kq = "";
                int sott = 0;
                while (sqlre.Read())
                {
                    sott++;
                    kq = kq + "<tr><td>" + sott + "</td><td>" + sqlre["Mamh"].ToString() + "</td><td>" + sqlre["Tenmh"].ToString() + "</td><td>" + sqlre["DiemC"].ToString() + "</td><td>" + sqlre["DiemB"].ToString() + "</td><td>" + sqlre["Diemthilan1"].ToString() + "</td><td>" + sqlre["Diemthilan2"].ToString() + "</td><td>" + sqlre["DiemTB"].ToString() + "</td><td>" + sqlre["Xeploai"].ToString() + "</td><td>" + sqlre["Hocki"].ToString() + "</td><td>" + sqlre["Namhoc"].ToString() + "</td></tr>";
                }
                sqlre.Close();
                ltr_thongtinsinhvien.Text = kq;
            }
            catch (Exception ex)
            {
                Response.Write("Lỗi :" + ex);
            }
            finally
            {
                cls_con.close_DB();
            }
        }
    }
}