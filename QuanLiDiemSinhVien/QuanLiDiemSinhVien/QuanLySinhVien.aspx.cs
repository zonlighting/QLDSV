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
    public partial class QuanLySinhVien : System.Web.UI.Page
    {
        cls_connectDB cls_con = new cls_connectDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_msv.ReadOnly = true;
            if (!IsPostBack)
            {
                try
                {
                    LoadKhoahocDropDownList();
                    LoadTencnDropDownList();
                    LoadDSSinhVien();
                    cls_con.connect_DB();
                    if (Request.QueryString["type"] != null && Request.QueryString["type"] == "delete")
                    {
                        lbt_themsuaxoa.Text = "Xóa thông tin";
                    }
                    else if (Request.QueryString["type"] != null && Request.QueryString["type"] == "edit")
                    {
                        lbt_themsuaxoa.Text = "Sửa thông tin";
                    }

                    if (Request.QueryString["type"] == "edit" || Request.QueryString["type"] == "delete")
                    {
                        string st_sql = "Select Masv, Tensv, Ngaysinh, Gioitinh, Email, Diachi, Chuyennganh, Makh from tbl_sinhvien inner join tbl_khoahoc on (khoahoc = Makh) where Masv = @ma;";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                        sqlcm.Parameters.Add(new SqlParameter("ma", Convert.ToInt32(Request.QueryString["id"])));

                        SqlDataReader sqlre = sqlcm.ExecuteReader();

                        sqlre.Read();
                        txt_msv.Text = sqlre["Masv"].ToString();
                        txt_tensv.Text = sqlre["Tensv"].ToString();
                        if (sqlre["Ngaysinh"] != DBNull.Value)
                        {
                            txt_ngaysinh.Text = Convert.ToDateTime(sqlre["Ngaysinh"]).ToString("dd/MM/yyyy");
                        }

                        if (sqlre["Gioitinh"].ToString() == "True")
                        {
                            rbt_nu.Checked = true;
                        }
                        else if (sqlre["Gioitinh"].ToString() == "False")
                        {
                            rbt_nam.Checked = true;
                        }

                        if (DropDownList1.Items.FindByValue(sqlre["Makh"].ToString()) != null)
                        {
                            DropDownList1.SelectedValue = sqlre["Makh"].ToString();
                        }
                        if (DropDownList2.Items.FindByValue(sqlre["Chuyennganh"].ToString()) != null)
                        {
                            DropDownList2.SelectedValue = sqlre["Chuyennganh"].ToString();
                        }
                        txt_email.Text = sqlre["Email"].ToString();
                        txt_diachi.Text = sqlre["Diachi"].ToString();
                    }

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
        private void LoadKhoahocDropDownList()
        {
            cls_connectDB cls_con = new cls_connectDB();
            cls_con.connect_DB();
            SqlCommand sqlcm = new SqlCommand("Select Makh, Tenkh from tbl_khoahoc order by Makh", cls_con.sql_con);
            SqlDataReader drd = sqlcm.ExecuteReader();
            DropDownList1.DataSource = drd;
            DropDownList1.DataBind();
        }
        private void LoadTencnDropDownList()
        {
            cls_connectDB cls_con = new cls_connectDB();
            cls_con.connect_DB();
            SqlCommand sqlcm = new SqlCommand("Select Macn, Tencn from tbl_chuyennganh order by Tencn", cls_con.sql_con);
            SqlDataReader drd = sqlcm.ExecuteReader();
            DropDownList2.DataSource = drd;
            DropDownList2.DataBind();
        }
        public void LoadDSSinhVien()
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {
                cls_con.connect_DB();
                string st_sql = "SELECT Masv, Tensv, Ngaysinh, Gioitinh, Email, Diachi, Khoahoc, Tencn from tbl_sinhvien inner join tbl_chuyennganh on (Chuyennganh = Macn);";
                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                SqlDataReader sqlre = sqlcm.ExecuteReader();

                int sott = 0;
                string st_kq = "";
                string gioitinh = "";
                while (sqlre.Read())
                {
                    sott++;
                    if (sqlre["Gioitinh"].ToString() == "True")
                    {
                        gioitinh = "Nữ";
                    }
                    else gioitinh = "Nam";
                    st_kq = st_kq + "<tr><td>" + sott + "</td><td>" + sqlre["Masv"].ToString() + "</td><td>" + sqlre["Tensv"].ToString() + "</td><td>" + Convert.ToDateTime(sqlre["Ngaysinh"]).ToString("dd/MM/yyyy") + "</td><td>" + gioitinh + "</td><td>" + sqlre["Email"].ToString() + "</td><td>" + sqlre["Diachi"].ToString() + "</td><td>" + sqlre["Khoahoc"].ToString() + "</td><td>" + sqlre["Tencn"].ToString() + "</td><td>" + "<a title='Sửa điểm' href='QuanLySinhVien.aspx?type=edit&id=" + sqlre["Masv"].ToString() + "'><i class='fa fa-edit' style='color:#6495ED'></i></a>" + "</td><td>" + "<a title='Xóa điểm' href='QuanlySinhVien.aspx?type=delete&id=" + sqlre["Masv"].ToString() + "'><i class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
                }
                sqlre.Close();
                ltr_quanlysv.Text = st_kq;
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

        protected void lbt_themsuaxoa_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] == "edit" && Request.QueryString["type"] != null)
            {
                string st_gioitinh = "";
                cls_con.connect_DB();
                try
                {
                    string st_masv = txt_msv.Text.Trim();
                    string st_tensv = txt_tensv.Text.Trim();
                    DateTime st_ngaysinh = DateTime.ParseExact(txt_ngaysinh.Text, "dd/MM/yyyy", null);
                    if (rbt_nam.Checked == true)
                    {
                        st_gioitinh = "False";
                    }
                    else st_gioitinh = "True";

                    string st_khoahoc = Convert.ToString(DropDownList1.SelectedValue).Trim();
                    string st_chuyennganh = Convert.ToString(DropDownList2.SelectedValue).Trim();
                    string st_email = txt_email.Text.Trim();
                    string st_diachi = txt_diachi.Text.Trim();

                    string st_sql = @"Update tbl_sinhvien set Tensv = @tensv, Ngaysinh = @ngaysinh, Gioitinh = @gioitinh, Email = @email, Diachi = @diachi, Khoahoc = @makhoa, chuyennganh = @chuyennganh from tbl_sinhvien where masv = @masv;";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                    sqlcm.Parameters.Add(new SqlParameter("masv", st_masv));
                    sqlcm.Parameters.Add(new SqlParameter("tensv", st_tensv));
                    sqlcm.Parameters.Add(new SqlParameter("ngaysinh", st_ngaysinh));
                    sqlcm.Parameters.Add(new SqlParameter("gioitinh", st_gioitinh));
                    sqlcm.Parameters.Add(new SqlParameter("email", st_email));
                    sqlcm.Parameters.Add(new SqlParameter("diachi", st_diachi));
                    sqlcm.Parameters.Add(new SqlParameter("makhoa", st_khoahoc));
                    sqlcm.Parameters.Add(new SqlParameter("chuyennganh", st_chuyennganh));

                    sqlcm.ExecuteNonQuery();
                    lbl_tb.Text = "Đã sửa sinh viên " + st_masv + " thành công";
                    LoadDSSinhVien();

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
            else if (Request.QueryString["type"] == "delete" && Request.QueryString["type"] != null)
            {
                cls_con.connect_DB();
                try
                {
                    string st_sql = "Delete From tbl_sinhvien where Masv = @Masv;";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    sqlcm.Parameters.Add(new SqlParameter("masv", Convert.ToInt32(Request.QueryString["id"])));
                    sqlcm.ExecuteNonQuery();
                    Response.Write("<script>alert('Bạn Có chắc chắn xóa sinh viên này không?')</script>");
                    lbl_tb.Text = "Đã xóa sinh viên @masv thành công";
                    LoadDSSinhVien();

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
            else
            {
                cls_con.connect_DB();
                try
                {
                    //----------Lấy dữ liệu nhập vào các ô textbox----
                    string st_masv = txt_msv.Text.Trim();
                    string st_tensv = txt_tensv.Text.Trim();
                    DateTime st_ngaysinh = DateTime.ParseExact(txt_ngaysinh.Text, "dd/MM/yyyy", null);
                    string st_gioitinh = "";
                    if (rbt_nam.Checked == true)
                    {
                        st_gioitinh = "False";
                    }
                    else st_gioitinh = "True";

                    string st_khoahoc = Convert.ToString(DropDownList1.SelectedValue).Trim();
                    string st_chuyennganh = Convert.ToString(DropDownList2.SelectedValue).Trim();
                    string st_email = txt_email.Text.Trim();
                    string st_diachi = txt_diachi.Text.Trim();

                    //-----------THỰC HIỆN THÊM MỚI BẢN GHI VÀO CSDL---
                    //----Kiểm tra trong csdl có bản ghi trùng mã ko?
                    string st_sql = "SELECT count(*) FROM tbl_sinhvien WHERE Masv = @masv;";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    //---Đưa tham số @ma vào câu lệnh SQL------
                    sqlcm.Parameters.Add(new SqlParameter("masv", st_masv));
                    //------Thực thi câu lệnh SQL----
                    int kt = (int)sqlcm.ExecuteScalar();


                    if (kt > 0)
                    {
                        lbl_tb.Text = "Sinh viên đã tồn tại! vui lòng kiểm tra lại.";
                    }
                    else
                    {
                        st_sql = "INSERT INTO tbl_sinhvien VALUES(@tensv, @ngaysinh, @gioitinh, @email, @diachi, @khoahoc, @chuyennganh);";
                        sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                        sqlcm.Parameters.Add(new SqlParameter("tensv", st_tensv));
                        sqlcm.Parameters.Add(new SqlParameter("ngaysinh", st_ngaysinh));
                        sqlcm.Parameters.Add(new SqlParameter("gioitinh", st_gioitinh));
                        sqlcm.Parameters.Add(new SqlParameter("email", st_email));
                        sqlcm.Parameters.Add(new SqlParameter("diachi", st_diachi));
                        sqlcm.Parameters.Add(new SqlParameter("khoahoc", st_khoahoc));
                        sqlcm.Parameters.Add(new SqlParameter("chuyennganh", st_chuyennganh));

                        //-----Thực thi câu lệnh SQL thêm mới
                        sqlcm.ExecuteNonQuery();
                        //-----Thông báo hiển thị kết quả
                        lbl_tb.Text = "Đã thêm thành công sinh viên" + st_masv;
                        LoadDSSinhVien();
                    }
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

        protected void lbt_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanLySinhVien.aspx");
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
                ltr_quanlysv.Text = kq;
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