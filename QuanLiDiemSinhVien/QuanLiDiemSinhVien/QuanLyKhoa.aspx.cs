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
    public partial class QuanLyKhoa : System.Web.UI.Page
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
                        /* string st_ma;
                         st_ma = txt_makhoa.Text.Trim();
                         //--Kiểm tra khoa đó có đang tồn tại chuyên ngành không?
                         string st_sql = "SELECT count(Tencn) from tbl_khoa,tbl_chuyennganh where tbl_khoa.Makhoa=tbl_chuyennganh.Khoa and Makhoa=@ma group by Tenkhoa; ;";
                         SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                         //---Đưa tham số @ma vào câu lệnh SQL----
                         SqlParameter sqlpa = new SqlParameter();
                         sqlpa.ParameterName = "@ma";
                         sqlpa.Value = st_ma;
                         sqlcm.Parameters.Add(sqlpa);
                         //---Thực thi câu lệnh SQL--*/
                        /*int kt = (int)sqlcm.ExecuteScalar();

                        if (kt > 0)
                        {
                            lbl_tb.Text = "Khoa đang có chuyên ngành không thể xóa!";
                        }else {*/
                        //thực hiện chức năng xóa thông tin
                        string st_sql = "DELETE FROM tbl_khoa WHERE Makhoa=@ma";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);


                        //Truyền tham số @ma vào câu lệnh SQL
                        SqlParameter sqlpa = new SqlParameter();
                        sqlpa.ParameterName = "@ma";
                        sqlpa.Value = Request.QueryString["id"].ToString();

                        sqlcm.Parameters.Add(sqlpa);
                        //Thực thi câu lệnh xóa
                        sqlcm.ExecuteNonQuery();
                        //Thông báo và hiển thị lại dữ liệu trong bảng tbl_khoa
                        Response.Write("<script>alert('Bạn Có chắc chắn xóa khoa này không?')</script>");
                        lbl_tb.Text = "Đã xóa thành công khoa có mã: " + Request.QueryString["id"].ToString();
                        // }
                    }
                    else if (Request.QueryString["type"] != null && Request.QueryString["type"] == "update")
                    {
                        //Thực hiện chức năng sửa thông tin
                        //------------Trước tiên phải lấy được dữ liệu cũ-----------------
                        string st_sql = "SELECT * FROM tbl_khoa WHERE Makhoa=@ma";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                        //---------Truyền tham số cho câu lệnh sql-----
                        SqlParameter sqlpa = new SqlParameter();
                        sqlpa.ParameterName = "@ma";
                        sqlpa.Value = Request.QueryString["id"].ToString();
                        sqlcm.Parameters.Add(sqlpa);

                        //--Thực thi và hiển thị dữ liệu cũ vào textbox.....
                        SqlDataReader re = sqlcm.ExecuteReader();
                        re.Read();
                        txt_makhoa.Text = re[0].ToString();
                        txt_makhoa.ReadOnly = true;

                        txt_tenkhoa.Text = re[1].ToString();
                        re.Close();

                        btn_them.Text = "Sửa Khoa";
                    }
                    load_khoa();
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

        } // kết thúc Page_Load

        private void load_khoa()
        {
            string st_sql = "SELECT * FROM tbl_khoa";
            SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
            SqlDataReader re = sqlcm.ExecuteReader();
            int sott = 0;
            string st_kq = "";
            while (re.Read())
            {
                sott++;
                st_kq = st_kq + "<tr><td>" + sott + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td>";
                st_kq = st_kq + "<td><a href='QuanLyKhoa.aspx?type=update&id=" + re[0].ToString() + "'><i title='Sửa khoa' class='fa fa-edit' style='color:#6495ED'></i></a></td>";
                st_kq = st_kq + "<td><a href='QuanLyKhoa.aspx?type=delete&id=" + re[0].ToString() + "'><i title='Xóa khoa' class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
            }
            re.Close();
            ltr_khoa.Text = st_kq;
            lbl_timkiem.Text = "Có " + sott + " kết quả";
        }// kết thúc load cn

        protected void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                cls_con.connect_DB();
                //Lấy dữ liệu người dùng nhập vào ô textbox
                string st_ma, st_ten;
                st_ma = txt_makhoa.Text.Trim();
                st_ten = txt_tenkhoa.Text.Trim();

                if (Request.QueryString["type"] != null && Request.QueryString["type"] == "update")
                {
                    //Viết mã thực hiện chức năng update dữ liệu

                    string st_sql = "UPDATE tbl_khoa SET Tenkhoa=@ten WHERE Makhoa=@ma";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    //--Truyền các tham số: @ten @ma vào trong câu lệnh SQL
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
                    //------------Thực thi câu truy vấn sửa thông tin-----
                    sqlcm.ExecuteNonQuery();

                    lbl_tb.Text = "Đã sửa thành công khoa có mã: " + st_ma;

                    load_khoa();

                }
                else
                {
                    //---  THỰC HIỆN THÊM MỚI BẢN GHI VÀO CSDL---
                    //--Kiểm tra trong csdl có bản ghi trùng mã ko?
                    string st_sql = "SELECT count(*) FROM tbl_khoa WHERE Makhoa=@ma";
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
                        lbl_tb.Text = "Mã chuyên ngành đã có! vui lòng kiểm tra lại.";
                    }
                    else
                    {
                        st_sql = "INSERT INTO tbl_khoa VALUES(@Makhoa, @tenkhoa)";
                        sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                        //-----------thêm tham số @ma vào câu lệnh
                        SqlParameter sqlpa1 = new SqlParameter();
                        sqlpa1.ParameterName = "@Makhoa";
                        sqlpa1.Value = st_ma;
                        sqlcm.Parameters.Add(sqlpa1);
                        //---Thêm tham số @tencn----
                        sqlpa1 = new SqlParameter();
                        sqlpa1.ParameterName = "@tenkhoa";
                        sqlpa1.Value = st_ten;
                        sqlcm.Parameters.Add(sqlpa1);

                        // Thực thi câu lệnh SQL thêm mới

                        sqlcm.ExecuteNonQuery();
                        //THông báo và hiển thị kết quả
                        lbl_tb.Text = "Đã thêm mới thành công vào CSDL!";
                    }
                    //Load lại dữ liệu bảng chuyên ngành
                    load_khoa();
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
        }//kết thúc thêm

        protected void timkiem_Click(object sender, EventArgs e)
        {
            cls_connectDB cls_con = new cls_connectDB();
            try
            {
                cls_con.connect_DB();
                string st_key = txt_timkiem.Text.Trim().ToLower();
                string st_sql = "SELECT * FROM tbl_khoa Where Makhoa like '%' + @id + '%' OR lower(Tenkhoa) like N'%' + @id + '%' order by Makhoa;";
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
                    st_kq = st_kq + "<tr><td>" + sott + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td>";
                    st_kq = st_kq + "<td><a href='QuanLyKhoa.aspx?type=update&id=" + re[0].ToString() + "'><i class='fa fa-edit' style='color:#6495ED'></i></a></td>";
                    st_kq = st_kq + "<td><a href='QuanLyKhoa.aspx?type=delete&id=" + re[0].ToString() + "'><i class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
                }
                re.Close();
                ltr_khoa.Text = st_kq;
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
            Response.Redirect("QuanLyKhoa.aspx");
        }
    }
}