using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace QuanLiDiemSinhVien.All_class
{
    public class cls_connectDB
    {
        //Khai báo biến Sqlconnection dùng cho toàn bộ Project
        public SqlConnection sql_con;
        //Lấy chuỗi kết nối trong web.config
        public string st_con = WebConfigurationManager.ConnectionStrings["ketnoi_QLDSV"].ToString();

        // mở kết nối tới CSDL
        public void connect_DB()
        {
            if (sql_con == null) sql_con = new SqlConnection(st_con);
            if (sql_con.State == ConnectionState.Closed) sql_con.Open();

        }
        //Xây dựng thủ tục đóng kết nối tới CSDL
        public void close_DB()
        {
            if (sql_con != null)
            {
                sql_con.Close();
                //sql_con.Dispose();
            }
        }
    }
}