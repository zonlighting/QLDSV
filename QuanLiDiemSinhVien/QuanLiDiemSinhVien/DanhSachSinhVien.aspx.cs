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
    public partial class DanhSachSinhVien : System.Web.UI.Page
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
                        string st_sql = "Select Masv, Tensv, Ngaysinh, Gioitinh, Email, Diachi, Khoahoc, Tencn from tbl_sinhvien inner join tbl_chuyennganh on (Chuyennganh = Macn) order by Tensv;";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                        SqlDataReader sqlre = sqlcm.ExecuteReader();

                        int sott = 0;
                        string kq = "";
                        string gioitinh = "";
                        while (sqlre.Read())
                        {
                            if (sqlre["gioitinh"].ToString() == "True")
                            {
                                gioitinh = "Nữ";
                            }
                            else gioitinh = "Nam";
                            sott++;
                            kq = kq + "<tr><td>" + sott + "</td><td>" + sqlre["Masv"].ToString() + "</td><td>" + sqlre["Tensv"].ToString() + "</td><td>" + Convert.ToDateTime(sqlre["Ngaysinh"]).ToString("dd/MM/yyyy") + "</td><td>" + gioitinh + "</td><td>" + sqlre["Email"].ToString() + "</td><td>" + sqlre["Diachi"].ToString() + "</td><td>" + sqlre["Khoahoc"].ToString() + "</td><td>" + sqlre["Tencn"].ToString() + "</td><td><a title='Xem chi tiết' href='ChiTietXemDiem.aspx?search=" + sqlre["Masv"].ToString() + "'><i class='fa fa-id-card-o'style='color:#6495ED'></i></a></td></tr>";
                        }
                        sqlre.Close();
                        ltr_sinhvien.Text = kq;
                        lbl_timkiem.Text = "Có " + sott + " kết quả";
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

        protected void timkiem_Click(object sender, EventArgs e)
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {
                cls_con.connect_DB();
                string st_key = txt_timkiem.Text.Trim().ToLower();
                string st_sql = "Select Masv, Tensv, Ngaysinh, Gioitinh, Email, Diachi, Khoahoc, Tencn from (tbl_sinhvien inner join tbl_chuyennganh on (Chuyennganh = Macn)) Where Masv like '%' + @id + '%' OR lower(Tensv) like N'%' + @id + '%' order by Tensv;";
                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                SqlParameter sqlpa = new SqlParameter();
                sqlpa.ParameterName = "@id";
                sqlpa.Value = st_key;
                sqlcm.Parameters.Add(sqlpa);
                SqlDataReader sqlre = sqlcm.ExecuteReader();

                int sott = 0;
                string kq = "";
                string gioitinh = "";
                while (sqlre.Read())
                {
                    if (sqlre["gioitinh"].ToString() == "True")
                    {
                        gioitinh = "Nữ";
                    }
                    else gioitinh = "Nam";
                    sott++;
                    kq = kq + "<tr><td>" + sott + "</td><td>" + sqlre["Masv"].ToString() + "</td><td>" + sqlre["Tensv"].ToString() + "</td><td>" + Convert.ToDateTime(sqlre["Ngaysinh"]).ToString("dd/MM/yyyy") + "</td><td>" + gioitinh + "</td><td>" + sqlre["Email"].ToString() + "</td><td>" + sqlre["Diachi"].ToString() + "</td><td>" + sqlre["Khoahoc"].ToString() + "</td><td>" + sqlre["Tencn"].ToString() + "</td><td><a title='Xem chi tiết' href='ChiTietXemDiem.aspx?search=" + sqlre["Masv"].ToString() + "'><i class='fa fa-id-card-o'style='color:#6495ED'></i></a></td></tr>";
                }
                sqlre.Close();
                ltr_sinhvien.Text = kq;
                lbl_timkiem.Text = "Có " + sott + " kết quả";

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