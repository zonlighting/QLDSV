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
    public partial class QuanLyMonHoc : System.Web.UI.Page
    {
        cls_connectDB cls_con = new cls_connectDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    cls_con.connect_DB();

                    //Kiểm tra chức năng thực hiện

                    if (Request.QueryString["type"] != null && Request.QueryString["type"] == "delete")
                    {
                        //thực hiện chức năng xóa thông tin
                        string st_sql = "DELETE FROM tbl_monhoc WHERE Mamh=@ma";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                        //Truyền tham số @ma vào câu lệnh SQL
                        SqlParameter sqlpa = new SqlParameter();
                        sqlpa.ParameterName = "@ma";
                        sqlpa.Value = Request.QueryString["id"].ToString();

                        sqlcm.Parameters.Add(sqlpa);
                        //Thực thi câu lệnh xóa
                        sqlcm.ExecuteNonQuery();
                        //Thông báo và hiển thị lại dữ liệu trong bảng tbl_khoa
                        Response.Write("<script>alert('Bạn Có chắc chắn xóa môn học này không?')</script>");
                        lbl_tb.Text = "Đã xóa thành công môn học có mã: " + Request.QueryString["id"].ToString();

                    }
                    else if (Request.QueryString["type"] != null && Request.QueryString["type"] == "update")
                    {
                        //Thực hiện chức năng sửa thông tin
                        //------------Trước tiên phải lấy được dữ liệu cũ-----------------
                        string st_sql = "SELECT * FROM tbl_monhoc WHERE Mamh=@ma";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                        //---------Truyền tham số cho câu lệnh sql-----
                        SqlParameter sqlpa = new SqlParameter();
                        sqlpa.ParameterName = "@ma";
                        sqlpa.Value = Request.QueryString["id"].ToString();
                        sqlcm.Parameters.Add(sqlpa);

                        //--Thực thi và hiển thị dữ liệu cũ vào textbox.....
                        SqlDataReader re = sqlcm.ExecuteReader();
                        re.Read();
                        txt_mamh.Text = re[0].ToString();
                        txt_mamh.ReadOnly = true;

                        txt_tenmh.Text = re[1].ToString();
                        txt_tinchi.Text = re[2].ToString();
                        txt_hocki.Text = re[3].ToString();
                        txt_gv.Text = re[4].ToString();
                        re.Close();

                        btn_them.Text = "Sửa TT";
                    }
                    load_monhoc();
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
        private void load_monhoc()
        {
            string st_sql = "SELECT * FROM tbl_monhoc";
            SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
            SqlDataReader re = sqlcm.ExecuteReader();
            int sott = 0;
            string st_kq = "";
            while (re.Read())
            {
                sott++;
                st_kq = st_kq + "<tr><td>" + sott + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td><td>" + re[2].ToString() + "</td><td>" + re[3].ToString() + "</td><td>" + re[4].ToString() + "</td>";
                st_kq = st_kq + "<td><a href='QuanLyMonHoc.aspx?type=update&id=" + re[0].ToString() + "'><i title='Sửa môn học' class='fa fa-edit' style='color:#6495ED'></i></a></td>";
                st_kq = st_kq + "<td><a href='QuanLyMonHoc.aspx?type=delete&id=" + re[0].ToString() + "'><i title='Xóa môn học' class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
            }
            re.Close();
            ltr_monhoc.Text = st_kq;
            lbl_timkiem.Text = "Có " + sott + " kết quả";
        }// kết thúc load cn

        protected void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                cls_con.connect_DB();
                //Lấy dữ liệu người dùng nhập vào ô textbox
                string st_ma, st_ten, st_tinchi, st_hocki, st_giaovien;
                st_ma = txt_mamh.Text.Trim();
                st_ten = txt_tenmh.Text.Trim();
                st_tinchi = txt_tinchi.Text.Trim();
                st_hocki = txt_hocki.Text.Trim();
                st_giaovien = txt_gv.Text.Trim();

                if (Request.QueryString["type"] != null && Request.QueryString["type"] == "update")
                {
                    //Viết mã thực hiện chức năng update dữ liệu

                    string st_sql = "UPDATE tbl_monhoc SET Tenmh=@ten, Sotinchi=@tinchi, Hocki=@hocki, Giaovien=@giaovien WHERE Mamh=@ma";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    //--Truyền các tham số: @ten @ma @tinchi @hocki @giaovien vào trong câu lệnh SQL
                    //----------------Tham số @ten----------------
                    SqlParameter sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@ten";
                    sqlpa.Value = st_ten;
                    sqlcm.Parameters.Add(sqlpa);
                    //----------------Tham số @ma----------------
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@ma";
                    sqlpa.Value = st_ma;
                    sqlcm.Parameters.Add(sqlpa);
                    //-------Tham số @tinhchi
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@tinchi";
                    sqlpa.Value = st_tinchi;
                    sqlcm.Parameters.Add(sqlpa);
                    //------Tham số @hocki
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@hocki";
                    sqlpa.Value = st_hocki;
                    sqlcm.Parameters.Add(sqlpa);
                    //--------Tham số @giaovien
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@giaovien";
                    sqlpa.Value = st_giaovien;
                    sqlcm.Parameters.Add(sqlpa);

                    //------------Thực thi câu truy vấn sửa thông tin-----
                    sqlcm.ExecuteNonQuery();

                    lbl_tb.Text = "Đã sửa thành công môn học có mã: " + st_ma;

                    load_monhoc();

                }
                else
                {
                    //---  THỰC HIỆN THÊM MỚI BẢN GHI VÀO CSDL---
                    //--Kiểm tra trong csdl có bản ghi trùng mã ko?
                    string st_sql = "SELECT count(*) FROM tbl_monhoc WHERE Mamh=@ma";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    //---Đưa tham số @ma vào câu lệnh SQL----
                    SqlParameter sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@ma";
                    sqlpa.Value = st_ma;
                    sqlcm.Parameters.Add(sqlpa);
                    //---Thực thi câu lệnh SQL--
                    int kt = (int)sqlcm.ExecuteScalar();

                    if (kt > 0)
                    {
                        lbl_tb.Text = "Mã môn học đã có! vui lòng kiểm tra lại.";
                    }
                    else
                    {
                        st_sql = "INSERT INTO tbl_monhoc VALUES(@tenmh, @tinchi, @hocki, @giaovien) ";
                        sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                        SqlParameter sqlpa1 = new SqlParameter();

                        //---Thêm tham số @tenmh----
                        sqlpa1 = new SqlParameter();
                        sqlpa1.ParameterName = "@tenmh";
                        sqlpa1.Value = st_ten;
                        sqlcm.Parameters.Add(sqlpa1);
                        //---Thêm tham số @tinchi----
                        sqlpa1 = new SqlParameter();
                        sqlpa1.ParameterName = "@tinchi";
                        sqlpa1.Value = st_tinchi;
                        sqlcm.Parameters.Add(sqlpa1);
                        //---Thêm tham số @hocki----
                        sqlpa1 = new SqlParameter();
                        sqlpa1.ParameterName = "@hocki";
                        sqlpa1.Value = st_hocki;
                        sqlcm.Parameters.Add(sqlpa1);
                        //---Thêm tham số @giaovien----
                        sqlpa1 = new SqlParameter();
                        sqlpa1.ParameterName = "@giaovien";
                        sqlpa1.Value = st_giaovien;
                        sqlcm.Parameters.Add(sqlpa1);


                        // Thực thi câu lệnh SQL thêm mới

                        sqlcm.ExecuteNonQuery();
                        //THông báo và hiển thị kết quả
                        lbl_tb.Text = "Đã thêm mới thành công vào CSDL!";
                    }
                    //Load lại dữ liệu bảng môn học
                    load_monhoc();
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

        protected void timkiem_Click(object sender, EventArgs e)
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {
                cls_con.connect_DB();
                string st_key = txt_timkiem.Text.Trim().ToLower();
                string st_sql = "SELECT * FROM tbl_monhoc Where Mamh like '%' + @id + '%' OR lower(Tenmh) like N'%' + @id + '%' order by Mamh;";
                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                SqlParameter sqlpa = new SqlParameter();
                sqlpa.ParameterName = "@id";
                sqlpa.Value = st_key;
                sqlcm.Parameters.Add(sqlpa);
                SqlDataReader re = sqlcm.ExecuteReader();

                int sott = 0;
                string st_kq = "";
                while (re.Read())
                {
                    sott++;
                    st_kq = st_kq + "<tr><td>" + sott + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td><td>" + re[2].ToString() + "</td><td>" + re[3].ToString() + "</td><td>" + re[4].ToString() + "</td>";
                    st_kq = st_kq + "<td><a href='QuanLyMonHoc.aspx?type=update&id=" + re[0].ToString() + "'><i class='fa fa-edit' style='color:#6495ED'></i></a></td>";
                    st_kq = st_kq + "<td><a href='QuanLyMonHoc.aspx?type=delete&id=" + re[0].ToString() + "'><i class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
                }
                re.Close();
                ltr_monhoc.Text = st_kq;
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

        protected void btn_huy_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyMonHoc.aspx");
        }
    }
}