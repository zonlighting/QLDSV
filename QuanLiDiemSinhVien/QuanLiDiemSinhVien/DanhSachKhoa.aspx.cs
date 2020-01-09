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
    public partial class DanhSachKhoa : System.Web.UI.Page
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
                        string st_sql = "SELECT Makhoa,Tenkhoa FROM tbl_khoa order by Makhoa; ";
                        SqlCommand sqlcm = new SqlCommand(st_sql, cls_con.sql_con);
                        SqlDataReader re = sqlcm.ExecuteReader();
                        byte i = 0;
                        string st_kq = "";
                        while (re.Read())
                        {
                            i++;
                            st_kq = st_kq + "<tr><td>" + i + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td><tr>";
                        }
                        re.Close();
                        ltr_khoa.Text = st_kq;
                        lbl_timkiem.Text = "Có " + i + " kết quả";

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
            try
            {
                cls_con.connect_DB();
                string st_key = txt_timkiem.Text.Trim().ToLower();
                string st_sql = "SELECT Makhoa,Tenkhoa FROM tbl_khoa where Makhoa like '%'+ @key +'%' or lower(Tenkhoa) like N'%' + @key + '%'   order by Makhoa";
                SqlCommand sqlcmd = new SqlCommand(st_sql, cls_con.sql_con);

                //Thêm tham số @key
                SqlParameter sqlpa = new SqlParameter();
                sqlpa.Value = st_key;
                sqlpa.ParameterName = "@key";
                sqlcmd.Parameters.Add(sqlpa);

                SqlDataReader re = sqlcmd.ExecuteReader();
                byte i = 0;
                string st_kq = "";
                while (re.Read())
                {
                    i++;
                    st_kq = st_kq + "<tr><td>" + i + "</td><td>" + re[0].ToString() + "</td><td>" + re[1].ToString() + "</td><tr>";
                }
                re.Close();
                ltr_khoa.Text = st_kq;
                if (i == 0)
                {
                    lbl_timkiem.Text = "Không có kết quả";
                }
                else
                {
                    lbl_timkiem.Text = "Có " + i + " kết quả";
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

}