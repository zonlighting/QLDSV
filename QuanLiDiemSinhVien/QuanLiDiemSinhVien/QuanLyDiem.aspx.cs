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
    public partial class QuanLyDiem : System.Web.UI.Page
    {
        cls_connectDB cls_con = new cls_connectDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_masv.ReadOnly = true;
            if (!IsPostBack)
            {
                try
                {
                    LoadMonHocDropdown();
                    LoadSinhVienDropdown();
                    LoadDSDiem();
                    cls_con.connect_DB();
                    if (Request.QueryString["type"] != null && Request.QueryString["type"] == "delete")
                    {
                        lbt_themsuaxoa.Text = "Xóa điểm";
                    }
                    else if (Request.QueryString["type"] != null && Request.QueryString["type"] == "edit")
                    {
                        lbt_themsuaxoa.Text = "Sửa điểm";
                    }

                    if (Request.QueryString["type"] == "edit" || Request.QueryString["type"] == "delete")
                    {
                        string st_sql = "Select Masv, Tenmh, DiemC, DiemB, Diemthilan1, Diemthilan2, DiemTB, Xeploai, tbl_diem.Hocki, Namhoc From (tbl_diem inner join tbl_monhoc on (Monhoc = Mamh)) Where Masv = @masv and Monhoc = (select Mamh from tbl_monhoc where Tenmh = @tenmh );";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                        sqlcm.Parameters.Add(new SqlParameter("masv", Convert.ToInt32(Request.QueryString["id"])));
                        sqlcm.Parameters.Add(new SqlParameter("tenmh", Convert.ToString(Request.QueryString["code"])));

                        SqlDataReader sqlre = sqlcm.ExecuteReader();

                        sqlre.Read();
                        if (DropDownList1.Items.FindByValue(sqlre["Masv"].ToString()) != null)
                        {
                            DropDownList1.SelectedValue = sqlre["Masv"].ToString();
                            txt_masv.Text = sqlre["Masv"].ToString();
                        }
                        if (DropDownList2.Items.FindByValue(sqlre["Tenmh"].ToString()) != null)
                        {
                            DropDownList2.SelectedValue = sqlre["Tenmh"].ToString();
                        }
                        txt_diemC.Text = sqlre["DiemC"].ToString();
                        txt_diemB.Text = sqlre["DiemB"].ToString();
                        txt_thi1.Text = sqlre["Diemthilan1"].ToString();
                        txt_thi2.Text = sqlre["Diemthilan2"].ToString();
                        txt_diemtb.Text = sqlre["DiemTB"].ToString();
                        txt_xeploai.Text = sqlre["Xeploai"].ToString();
                        txt_hocky.Text = sqlre["Hocki"].ToString();
                        txt_namhoc.Text = sqlre["Namhoc"].ToString();
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
        public void LoadDSDiem()
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {
                cls_con.connect_DB();
                string st_sql = "Select tbl_diem.Masv, Tensv, Tenmh, DiemC, DiemB, Diemthilan1, Diemthilan2, DiemTB, Xeploai, tbl_diem.Hocki, Namhoc From (tbl_diem inner join tbl_monhoc on (Monhoc=Mamh) inner join tbl_sinhvien on (tbl_diem.Masv = tbl_sinhvien.Masv )) order by Masv;";
                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                SqlDataReader sqlre = sqlcm.ExecuteReader();

                int sott = 0;
                string kq = "";
                while (sqlre.Read())
                {
                    sott++;
                    kq = kq + "<tr><td>" + sott + "</td><td>" + sqlre["Masv"].ToString() + "</td><td>" + sqlre["Tensv"].ToString() + "</td><td>" + sqlre["Tenmh"].ToString() + "</td><td>" + sqlre["DiemC"].ToString() + "</td><td>" + sqlre["DiemB"].ToString() + "</td><td>" + sqlre["Diemthilan1"].ToString() + "</td><td>" + sqlre["Diemthilan2"].ToString() + "</td><td>" + sqlre["DiemTB"].ToString() + "</td><td>" + sqlre["Xeploai"].ToString() + "</td><td>" + sqlre["Hocki"].ToString() + "</td><td>" + sqlre["Namhoc"].ToString() + "</td><td><a title='Sửa điểm' href='QuanlyDiem.aspx?type=edit&id=" + sqlre["Masv"].ToString() + "&code=" + sqlre["Tenmh"].ToString() + "'><i class='fa fa-edit' style='color:#6495ED'></i></a>" + "</td><td>" + "<a title='Xóa điểm' href='QuanlyDiem.aspx?type=delete&id=" + sqlre["Masv"].ToString() + "&code=" + sqlre["Tenmh"].ToString() + "'><i class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
                }
                sqlre.Close();
                ltr_dsdiem.Text = kq;
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

        protected void lbt_search_Click(object sender, EventArgs e)
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {
                cls_con.connect_DB();
                string st_key = tbx_key.Text.Trim().ToLower();
                string st_sql = "Select Masv, Tenmh, DiemC, DiemB, Diemthilan1, Diemthilan2, DiemTB, Xeploai, tbl_diem.Hocki, Namhoc From (tbl_diem inner join tbl_monhoc on (Monhoc=Mamh)) Where Masv like '%' + @id + '%' OR lower(Tenmh) like N'%' + @id + '%' order by Masv;";
                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                SqlParameter sqlpa = new SqlParameter();
                sqlpa.ParameterName = "@id";
                sqlpa.Value = st_key;
                sqlcm.Parameters.Add(sqlpa);
                SqlDataReader sqlre = sqlcm.ExecuteReader();

                int sott = 0;
                string kq = "";
                while (sqlre.Read())
                {
                    sott++;
                    kq = kq + "<tr><td>" + sott + "</td><td>" + sqlre["Masv"].ToString() + "</td><td>" + sqlre["Tenmh"].ToString() + "</td><td>" + sqlre["DiemC"].ToString() + "</td><td>" + sqlre["DiemB"].ToString() + "</td><td>" + sqlre["Diemthilan1"].ToString() + "</td><td>" + sqlre["Diemthilan2"].ToString() + "</td><td>" + sqlre["DiemTB"].ToString() + "</td><td>" + sqlre["Xeploai"].ToString() + "</td><td>" + sqlre["Hocki"].ToString() + "</td><td>" + sqlre["Namhoc"].ToString() + "</td><td><a title='Sửa điểm' href='QuanlyDiem.aspx?type=edit&id=" + sqlre["Masv"].ToString() + "&code=" + sqlre["Tenmh"].ToString() + "'><i class='fa fa-edit' style='color:#6495ED'></i></a>" + "</td><td>" + " <a title='Xóa điểm' href='QuanlyDiem.aspx?type=delete&id=" + sqlre["Masv"].ToString() + "&code=" + sqlre["Tenmh"].ToString() + "'><i class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
                }
                sqlre.Close();
                ltr_dsdiem.Text = kq;
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyDiem.aspx");
        }
        private void LoadSinhVienDropdown()
        {
            cls_connectDB cls_con = new cls_connectDB();
            cls_con.connect_DB();
            SqlCommand sqlcm = new SqlCommand("Select Masv, Tensv from tbl_sinhvien order by Tensv", cls_con.sql_con);
            SqlDataReader drd = sqlcm.ExecuteReader();
            DropDownList1.DataSource = drd;
            DropDownList1.DataBind();

        }
        private void LoadMonHocDropdown()
        {
            cls_connectDB cls_con = new cls_connectDB();
            cls_con.connect_DB();
            SqlCommand sqlcm = new SqlCommand("Select Tenmh from tbl_monhoc order by Tenmh", cls_con.sql_con);
            SqlDataReader drd = sqlcm.ExecuteReader();
            DropDownList2.DataSource = drd;
            DropDownList2.DataBind();

        }
        protected void lbt_themsuaxoa_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] == "edit" && Request.QueryString["type"] != null)
            {
                cls_con.connect_DB();
                try
                {
                    //string st_masv, st_tenmh, st_diemc, st_diemb, st_thi1, st_thi2, st_diemtb, st_xeploai, st_hocky, st_namhoc;
                    string st_masv = Convert.ToString(DropDownList1.SelectedValue).Trim();
                    string st_tenmh = Convert.ToString(DropDownList2.SelectedValue).Trim();
                    string st_diemc = txt_diemC.Text.Trim();
                    string st_diemb = txt_diemB.Text.Trim();
                    string st_thi1 = txt_thi1.Text.Trim();
                    string st_thi2 = txt_thi2.Text.Trim();
                    string st_diemtb = txt_diemtb.Text.Trim();
                    string st_xeploai = txt_xeploai.Text.Trim();
                    string st_hocky = txt_hocky.Text.Trim();
                    string st_namhoc = txt_namhoc.Text.Trim();

                    string st_sql = @"Update tbl_diem set DiemC = @diemc, DiemB = @diemb, Diemthilan1 = @thi1, 
                    Diemthilan2 = @thi2, DiemTB = @diemtb, Xeploai = @xeploai, Hocki = @hocky, Namhoc = @namhoc Where Masv = @masv and Monhoc = (select Mamh from tbl_monhoc where Tenmh = @tenmh );";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                    sqlcm.Parameters.Add(new SqlParameter("masv", st_masv));
                    sqlcm.Parameters.Add(new SqlParameter("tenmh", st_tenmh));
                    sqlcm.Parameters.Add(new SqlParameter("diemc", st_diemc));
                    sqlcm.Parameters.Add(new SqlParameter("diemb", st_diemb));
                    sqlcm.Parameters.Add(new SqlParameter("thi1", st_thi1));
                    sqlcm.Parameters.Add(new SqlParameter("thi2", st_thi2));
                    sqlcm.Parameters.Add(new SqlParameter("diemtb", st_diemtb));
                    sqlcm.Parameters.Add(new SqlParameter("xeploai", st_xeploai));
                    sqlcm.Parameters.Add(new SqlParameter("hocky", st_hocky));
                    sqlcm.Parameters.Add(new SqlParameter("namhoc", st_namhoc));

                    sqlcm.ExecuteNonQuery();
                    Response.Redirect("QuanLyDiem.aspx");

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
                    string st_sql = "Delete From tbl_diem where Masv = @Masv and Monhoc = (select Mamh From tbl_monhoc where Tenmh = @tenmh);";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    sqlcm.Parameters.Add(new SqlParameter("masv", Convert.ToInt32(Request.QueryString["id"])));
                    sqlcm.Parameters.Add(new SqlParameter("tenmh", Convert.ToString(Request.QueryString["code"])));
                    sqlcm.ExecuteNonQuery();
                    Response.Redirect("QuanLyDiem.aspx");

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
                    string st_masv, st_tenmh, st_diemc, st_diemb, st_thi1, st_thi2, st_diemtb, st_xeploai, st_hocky, st_namhoc;
                    st_masv = Convert.ToString(DropDownList1.SelectedValue).Trim();
                    st_tenmh = (DropDownList2.SelectedValue).Trim();
                    st_diemc = txt_diemC.Text.Trim();
                    st_diemb = txt_diemB.Text.Trim();
                    st_thi1 = txt_thi1.Text.Trim();
                    st_thi2 = txt_thi2.Text.Trim();
                    st_diemtb = txt_diemtb.Text.Trim();
                    st_xeploai = txt_xeploai.Text.Trim();
                    st_hocky = txt_hocky.Text.Trim();
                    st_namhoc = txt_namhoc.Text.Trim();

                    //-----------THỰC HIỆN THÊM MỚI BẢN GHI VÀO CSDL---
                    //----Kiểm tra trong csdl có bản ghi trùng mã ko?
                    string st_sql = "SELECT count(*) FROM tbl_diem WHERE Masv = @masv and Monhoc = (Select Mamh from tbl_monhoc where Tenmh = @tenmh);";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    //---Đưa tham số @ma vào câu lệnh SQL------
                    sqlcm.Parameters.Add(new SqlParameter("masv", st_masv));
                    sqlcm.Parameters.Add(new SqlParameter("tenmh", st_tenmh));
                    //------Thực thi câu lệnh SQL----
                    int kt = (int)sqlcm.ExecuteScalar();


                    if (kt > 0)
                    {
                        lbl_thongbao.Text = "Sinh viên bạn chọn đang học môn này! vui lòng kiểm tra lại.";
                    }
                    else
                    {
                        st_sql = "INSERT INTO tbl_diem VALUES(@masv, (select Mamh from tbl_monhoc where Tenmh = @tenmh), @diemb, @diemc, @thi1, @thi2, @diemtb, @xeploai, @hocky, @namhoc);";
                        sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                        sqlcm.Parameters.Add(new SqlParameter("masv", st_masv));
                        sqlcm.Parameters.Add(new SqlParameter("tenmh", st_tenmh));
                        sqlcm.Parameters.Add(new SqlParameter("diemc", st_diemc));
                        sqlcm.Parameters.Add(new SqlParameter("diemb", st_diemb));
                        sqlcm.Parameters.Add(new SqlParameter("thi1", st_thi1));
                        sqlcm.Parameters.Add(new SqlParameter("thi2", st_thi2));
                        sqlcm.Parameters.Add(new SqlParameter("diemtb", st_diemtb));
                        sqlcm.Parameters.Add(new SqlParameter("xeploai", st_xeploai));
                        sqlcm.Parameters.Add(new SqlParameter("hocky", st_hocky));
                        sqlcm.Parameters.Add(new SqlParameter("namhoc", st_namhoc));

                        //-----Thực thi câu lệnh SQL thêm mới
                        sqlcm.ExecuteNonQuery();
                        //-----Thông báo hiển thị kết quả
                        Response.Redirect("QuanLyDiem.aspx");
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
    }
}