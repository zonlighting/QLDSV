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
    public partial class TrangChu : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    try
                    {
                        cls_con.connect_DB();
                        Count();
                        //Thống kê sinh viên theo chuyên ngành
                        string st_sql1 = "SELECT cn.Tencn as 'Chuyên ngành',COUNT(sv.Masv) as 'Số sinh viên' FROM tbl_chuyennganh cn left JOIN tbl_sinhvien sv ON cn.Macn = sv.Chuyennganh GROUP BY cn.Tencn;";
                        //--hiển thị ds sv--//
                        SqlCommand sqlcm1 = new SqlCommand(st_sql1, cls_con.sql_con);
                        SqlDataReader sqlre = sqlcm1.ExecuteReader();

                        int sott = 0;
                        string kq = "";
                        while (sqlre.Read())
                        {
                            sott++;
                            kq = kq + "<tr><td>" + sott + "</td><td>" + sqlre[0].ToString() + "</td><td>" + sqlre[1].ToString() + "</td><td><a href='DssvTheoCn.aspx?id=" + sqlre[0].ToString() + "'>Danh sách</a></td></tr>";
                        }
                        sqlre.Close();

                        ltr_sv_cn.Text = kq;

                        //Thống kê đồ án tốt nghiệp theo lĩnh vực
                        //Thống kê chuyên ngành theo khoa
                        st_sql1 = "select Tenkhoa,count(Tencn) from tbl_khoa,tbl_chuyennganh where tbl_khoa.Makhoa=tbl_chuyennganh.Khoa group by Tenkhoa";
                        //--hiển thị ds sv--//
                        sqlcm1 = new SqlCommand(st_sql1, cls_con.sql_con);
                        SqlDataReader sqlre1 = sqlcm1.ExecuteReader();
                        string kq1 = "";
                        byte STT = 0;
                        while (sqlre1.Read())
                        {
                            STT++;
                            kq1 = kq1 + "<tr><td>" + STT + "</td><td>" + sqlre1[0].ToString() + "</td><td>" + sqlre1[1].ToString() + "</td><td><a href='DscnTheoKhoa.aspx?id=" + sqlre1[0].ToString() + "'>Danh Sách</a></td></tr>";
                        }
                        sqlre1.Close();
                        ltr_cn_khoa.Text = kq1;
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Lỗi thao tác:" + ex);
                    }
                    finally
                    {
                        cls_con.close_DB();
                    }
                }
            }

        }
        protected void Count()
        {
            string st_sql = "Select count(Masv) from tbl_sinhvien;";
            SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
            int so_sv;
            so_sv = (int)sqlcm.ExecuteScalar();
            Label_sinhvien.Text = so_sv.ToString();

            st_sql = "Select count(Makhoa) from tbl_khoa;";
            sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
            int so_khoa;
            so_khoa = (int)sqlcm.ExecuteScalar();
            Label_khoa.Text = so_khoa.ToString();

            st_sql = "Select count(Macn) from tbl_chuyennganh;";
            sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
            int so_cn;
            so_cn = (int)sqlcm.ExecuteScalar();
            Label_chuyennganh.Text = so_cn.ToString();

            st_sql = "Select count(Mamh) from tbl_monhoc;";
            sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
            int so_mh;
            so_mh = (int)sqlcm.ExecuteScalar();
            Label_monhoc.Text = so_mh.ToString();

        }
    }
}