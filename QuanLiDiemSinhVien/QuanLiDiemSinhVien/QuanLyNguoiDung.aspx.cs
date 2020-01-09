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
    public partial class QuanLyNguoiDung : System.Web.UI.Page
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
                if (Session["Quyen"].ToString() == "1")
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
                                string st_sql = "DELETE FROM tbl_acount WHERE id=@ma";
                                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                                //Truyền tham số @ma vào câu lệnh SQL
                                SqlParameter sqlpa = new SqlParameter();
                                sqlpa.ParameterName = "@ma";
                                sqlpa.Value = Request.QueryString["id"].ToString();

                                sqlcm.Parameters.Add(sqlpa);
                                //Thực thi câu lệnh xóa
                                sqlcm.ExecuteNonQuery();
                                //Thông báo và hiển thị lại dữ liệu trong bảng tbl_chuyennganh
                                Response.Write("<script>alert('Bạn Có chắc chắn xóa tài khoản này không?')</script>");
                                lbl_tb.Text = "Đã xóa thành công \tài khoản có mã: " + Request.QueryString["id"].ToString();
                            }
                            else if (Request.QueryString["type"] != null && Request.QueryString["type"] == "update")
                            {
                                //Thực hiện chức năng sửa thông tin
                                //------------Trước tiên phải lấy được dữ liệu cũ-----------------
                                string st_sql = "SELECT * FROM tbl_acount WHERE id=@ma";
                                SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);

                                //---------Truyền tham số cho câu lệnh sql-----
                                SqlParameter sqlpa = new SqlParameter();
                                sqlpa.ParameterName = "@ma";
                                sqlpa.Value = Request.QueryString["id"].ToString();
                                sqlcm.Parameters.Add(sqlpa);

                                //--Thực thi và hiển thị dữ liệu cũ vào textbox.....
                                SqlDataReader re = sqlcm.ExecuteReader();
                                re.Read();
                                txt_id.Text = re[0].ToString();
                                txt_id.ReadOnly = true;

                                txt_user.Text = re[1].ToString();
                                txt_pass.Text = re[2].ToString();
                                txt_hoten.Text = re[3].ToString();
                                if (re[4].ToString() == "False") rbt_nam.Checked = true;
                                else rbt_nu.Checked = true;

                                txt_email.Text = re[5].ToString();
                                DropDownList1.SelectedValue = re[6].ToString();

                                re.Close();

                                btn_them.Text = "Sửa TT";

                            }

                            LoadDataToDropDownList();
                            load_Acount();
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Lỗi: " + ex);
                        }
                        finally
                        {
                            cls_con.close_DB();
                        }
                    }//kết thúc lệnh if
                }
                else
                {
                    Response.Write("<script>alert('Bạn không có quyền dùng chức năng này!')</script>");
                    Response.Redirect("TrangChu.aspx");
                }

            }

        }//két thúc load

        private void LoadDataToDropDownList()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select id, Tenquyen From tbl_qyen", cls_con.sql_con);
            adapter.Fill(dataTable);
            DropDownList1.DataSource = dataTable;

            DropDownList1.DataTextField = "Tenquyen"; //Text hiển thị
            DropDownList1.DataValueField = "id"; //Giá trị khi chọn
            DropDownList1.DataBind();
        }

        private void load_Acount()
        {
            string st_sql = "SELECT ac.id,ac.Tendn, ac.Matkhau,ac.Hoten,Case ac.Gioitinh when 0 then N'Nam' else N'Nữ' end,ac.Email,q.Tenquyen FROM tbl_acount ac  JOIN tbl_qyen q ON ac.Quyen = q.id";
            SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
            SqlDataReader re = sqlcm.ExecuteReader();
            int sott = 0;
            string st_kq = "";
            while (re.Read())
            {
                sott++;
                st_kq = st_kq + "<tr><td>" + sott + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td><td>" + re[2].ToString() + "</td><td>" + re[3].ToString() + "</td><td>" + re[4].ToString() + "</td><td>" + re[5].ToString() + "</td><td>" + re[6].ToString() + "</td>";
                st_kq = st_kq + "<td><a href='QuanLyNguoiDung.aspx?type=update&id=" + re[0].ToString() + "'><i class='fa fa-edit' style='color:#6495ED'></i></a></td>";

                st_kq = st_kq + "<td><a href='QuanLyNguoiDung.aspx?type=delete&id=" + re[0].ToString() + "'><i class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
            }
            re.Close();
            ltr_acc.Text = st_kq;
            lbl_timkiem.Text = "Có " + sott + " kết quả";
        } // kết thúc load_count


        protected void btn_them_Click1(object sender, EventArgs e)
        {
            try
            {
                string st_gioitinh = "";
                cls_con.connect_DB();
                //Lấy dữ liệu người dùng nhập vào ô textbox
                string st_ma, st_use, st_pass, st_ten, st_email, st_quyen;
                st_ma = txt_id.Text.Trim();
                st_use = txt_user.Text.Trim();
                st_pass = txt_pass.Text.Trim();
                st_ten = txt_hoten.Text.Trim();
                if (rbt_nam.Checked == true)
                {
                    st_gioitinh = "False";
                }
                else st_gioitinh = "True";
                st_email = txt_email.Text.Trim();
                st_quyen = Convert.ToString(DropDownList1.SelectedValue).Trim();

                if (Request.QueryString["type"] != null && Request.QueryString["type"] == "update")
                {
                    //Viết mã thực hiện chức năng update dữ liệu

                    string st_sql = "UPDATE tbl_acount SET Tendn=@user,Matkhau=@pass,Hoten=@ten,Gioitinh=@gt,Email=@em,Quyen=@quyen WHERE id=@ma";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    //--Truyền các tham số: @ten, @gc, @ma vào trong câu lệnh SQL
                    //----------------Tham số @user----------------
                    SqlParameter sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@user";
                    sqlpa.Value = st_use;
                    sqlcm.Parameters.Add(sqlpa);
                    //----------------Tham số @pass----------------
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@pass";
                    sqlpa.Value = st_pass;
                    sqlcm.Parameters.Add(sqlpa);
                    //----------------Tham số @ten----------------
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@ten";
                    sqlpa.Value = st_ten;
                    sqlcm.Parameters.Add(sqlpa);
                    //----------------Tham số @gt----------------
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@gt";
                    sqlpa.Value = st_gioitinh;
                    sqlcm.Parameters.Add(sqlpa);
                    //----------------Tham số @em----------------
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@em";
                    sqlpa.Value = st_email;
                    sqlcm.Parameters.Add(sqlpa);
                    //----------------Tham số @quyen----------------
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@quyen";
                    sqlpa.Value = st_quyen;
                    sqlcm.Parameters.Add(sqlpa);
                    //----------------Tham số @ma----------------
                    sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@ma";
                    sqlpa.Value = st_ma;
                    sqlcm.Parameters.Add(sqlpa);
                    //------------Thực thi câu truy vấn sửa thông tin-----
                    sqlcm.ExecuteNonQuery();

                    lbl_tb.Text = "Đã sửa thành công chuyên ngành có mã: " + st_ma;

                    load_Acount();

                } //kết thúc if
                else
                {
                    string st_sql = "INSERT INTO tbl_acount VALUES(@user,@pass,@ten,@gt,@em,@quyen)";
                    SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                    //-----------thêm tham số @ma vào câu lệnh
                    SqlParameter sqlpa1 = new SqlParameter();
                    /* sqlpa1.ParameterName = "@macn";
                     sqlpa1.Value = st_ma;
                     sqlcm.Parameters.Add(sqlpa1);*/
                    //---Thêm tham số @tencn----
                    sqlpa1 = new SqlParameter();
                    sqlpa1.ParameterName = "@user";
                    sqlpa1.Value = st_use;
                    sqlcm.Parameters.Add(sqlpa1);

                    //---Thêm tham số @pass----
                    sqlpa1 = new SqlParameter();
                    sqlpa1.ParameterName = "@pass";
                    sqlpa1.Value = st_pass;
                    sqlcm.Parameters.Add(sqlpa1);
                    //---Thêm tham số @ten----
                    sqlpa1 = new SqlParameter();
                    sqlpa1.ParameterName = "@ten";
                    sqlpa1.Value = st_ten;
                    sqlcm.Parameters.Add(sqlpa1);
                    //---Thêm tham số @gt----   ;
                    sqlpa1 = new SqlParameter();
                    sqlpa1.ParameterName = "@gt";
                    sqlpa1.Value = st_gioitinh;
                    sqlcm.Parameters.Add(sqlpa1);
                    //---Thêm tham số @em----
                    sqlpa1 = new SqlParameter();
                    sqlpa1.ParameterName = "@em";
                    sqlpa1.Value = st_email;
                    sqlcm.Parameters.Add(sqlpa1);
                    //---Thêm tham số @quyen----
                    sqlpa1 = new SqlParameter();
                    sqlpa1.ParameterName = "@quyen";
                    sqlpa1.Value = st_quyen;
                    sqlcm.Parameters.Add(sqlpa1);
                    // Thực thi câu lệnh SQL thêm mới

                    sqlcm.ExecuteNonQuery();
                    //THông báo và hiển thị kết quả
                    lbl_tb.Text = "Đã thêm mới thành công vào CSDL!";

                    //}
                    //Load lại dữ liệu bảng chuyên ngành
                } //KẾt thúc else
                load_Acount();
            }//Kết thúc try

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
                string st_sql = "SELECT ac.id,ac.Tendn, ac.Matkhau,ac.Hoten,Case ac.Gioitinh when 0 then N'Nam' else N'Nữ' end,ac.Email,q.Tenquyen FROM tbl_acount ac  JOIN tbl_qyen q ON ac.Quyen = q.id WHERE tbl_acount.id=@ma Where id like '%' + @id + '%' OR lower(Hoten) like N'%' + @id + '%' order by id;";
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
                    st_kq = st_kq + "<tr><td>" + sott + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td><td>" + re[2].ToString() + "</td><td>" + re[3].ToString() + "</td><td>" + re[4].ToString() + "</td><td>" + re[5].ToString() + "</td><td>" + re[6].ToString() + "</td>";
                    st_kq = st_kq + "<td><a href='QuanLyNguoiDung.aspx?type=update&id=" + re[0].ToString() + "'><i class='fa fa-edit' style='color:#6495ED'></i></a></td>";
                    st_kq = st_kq + "<td><a href='QuanLyNguoiDung.aspx?type=delete&id=" + re[0].ToString() + "'><i class='fa fa-remove' style='color:#6495ED'></i></a></td></tr>";
                }
                re.Close();
                ltr_acc.Text = st_kq;
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
            Response.Redirect("QuanLyNguoiDung.aspx");
        }
    }
}