<%@ Page Title="Danh sách môn học" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DanhSachMonHoc.aspx.cs" Inherits="QuanLiDiemSinhVien.DanhSachMonHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>DANH SÁCH MÔN HỌC</h1> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="form-inline" style="margin-bottom: 15px;">
            <asp:TextBox ID="txt_timkiem" class="form-control" runat="server" style="width: 300px;" placeholder="Xin mời nhập để tìm kiếm"></asp:TextBox>
            <asp:Button ID="timkiem" runat="server" class="btn btn-primary" Text="Tìm kiếm" OnClick="timkiem_Click" /> 
            <br />
            <asp:Label ID="lbl_timkiem" class="label label-info" runat="server" Text=""></asp:Label>
        </div>
        <table class="table table-hover">
          <thead>
            <tr style = "color: black; background-color:cornflowerblue; font-weight: bold;">
                <th>STT</th>
                <th>Mã môn học</th>
                <th>Tên môn học</th>
                <th>Số tín chỉ</th>
                <th>Học kì</th>
                <th>Giáo viên</th>
            </tr>
          </thead>
          <tbody>
              <asp:Literal ID="ltr_monhoc" runat="server"></asp:Literal>
          </tbody>
        </table>
    </div>
</asp:Content>

