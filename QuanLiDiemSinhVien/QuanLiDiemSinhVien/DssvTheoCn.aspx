<%@ Page Title="DS sinh viên theo chuyên ngành" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DssvTheoCn.aspx.cs" Inherits="QuanLiDiemSinhVien.DssvTheoCn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>DANH SÁCH SINH VIÊN THEO CHUYÊN NGÀNH</h1> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-hover">
          <thead>
            <tr style = "color: black; background-color:cornflowerblue; font-weight: bold;">
                <th>STT</th>
                <th>Mã SV</th>
                <th>Tên SV</th>
                <th>Ngày sinh</th>
                <th>Giới tính</th>
                <th>Email</th>
                <th>Địa chỉ</th>
                <th>Khóa</th>
                <th>Chuyên ngành</th>
            </tr>
          </thead>
          <tbody>
              <asp:Literal ID="ltr_sinhvien" runat="server"></asp:Literal>
          </tbody>
    </table>
</asp:Content>

