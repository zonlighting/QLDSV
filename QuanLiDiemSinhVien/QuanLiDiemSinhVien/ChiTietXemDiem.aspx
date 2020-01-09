    <%@ Page Title="Chi tiết xem điểm" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChiTietXemDiem.aspx.cs" Inherits="QuanLiDiemSinhVien.XemDiemChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>CHI TIẾT XEM ĐIỂM</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Thông tin sinh viên</h3>
        </div>
        <div class="panel-body">
            <table class="table table-bordered" style="width: 500px; margin-left: 350px;">
                <tr>
                    <td>Mã sinh viên:</td>
                    <td>
                        <asp:label id="lbl_masv" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>Tên sinh viên:</td>
                    <td>
                        <asp:label id="lbl_tensv" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>Ngày sinh:</td>
                    <td>
                        <asp:label id="lbl_ngaysinh" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>Giới tính:</td>
                    <td>
                        <asp:label id="lbl_sex" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:label id="lbl_email" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>Địa chỉ:</td>
                    <td>
                        <asp:label id="lbl_diachi" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>Chuyên ngành:</td>
                    <td>
                        <asp:label id="lbl_chuyennganh" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>Khóa học:</td>
                    <td>
                        <asp:label id="lbl_khoahoc" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <table class="table table-hover">
            <thead>
                <tr style="color: black; background-color: cornflowerblue; font-weight: bold;">
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
                <asp:Literal ID="ltr_thongtinsinhvien" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

