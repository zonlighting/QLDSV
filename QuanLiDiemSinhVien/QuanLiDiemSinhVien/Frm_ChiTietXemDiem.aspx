<%@ Page Title="Chi tiết xem điểm" Language="C#" MasterPageFile="~/NguoiDung.Master" AutoEventWireup="true" CodeBehind="Frm_ChiTietXemDiem.aspx.cs" Inherits="QuanLiDiemSinhVien.Frm_ChiTietXemDiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container w3-center">
        <h3><b>BẢNG KẾT QUẢ HỌC TẬP</b></h3>
    </div>
    <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white" style="width: 500px; margin-left: 310px;">
        <tr>
            <td>Mã sinh viên:</td>
            <td>
                <asp:Label ID="lbl_masv" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Tên sinh viên:</td>
            <td>
                <asp:Label ID="lbl_tensv" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Ngày sinh:</td>
            <td>
                <asp:Label ID="lbl_ngaysinh" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Giới tính:</td>
            <td>
                <asp:Label ID="lbl_sex" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:Label ID="lbl_email" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Địa chỉ:</td>
            <td>
                <asp:Label ID="lbl_diachi" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Chuyên ngành:</td>
            <td>
                <asp:Label ID="lbl_chuyennganh" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Khóa học:</td>
            <td>
                <asp:Label ID="lbl_khoahoc" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>

    <div style="margin-top: 30px;">
        <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white">
            <thead class="w3-teal">
                <tr>
                    <td>STT</td>
                    <td>Mã môn học</td>
                    <td>Tên môn</td>
                    <td>C</td>
                    <td>B</td>
                    <td>Thi(1)</td>
                    <td>Thi(2)</td>
                    <td>Tổng kết</td>
                    <td>Xếp loại</td>
                    <td>Học kỳ</td>
                    <td>Năm học</td>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltr_ct_diemsv" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div>
    <div style="height: 100px;"></div>
</asp:Content>

