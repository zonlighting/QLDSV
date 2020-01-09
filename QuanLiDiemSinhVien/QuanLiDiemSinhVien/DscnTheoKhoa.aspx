<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DscnTheoKhoa.aspx.cs" Inherits="QuanLiDiemSinhVien.DscnTheoKhoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>DANH SÁCH CHUYÊN NGÀNH THEO KHOA</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-hover">
          <thead>
            <tr style = "color: black; background-color:cornflowerblue; font-weight: bold;">
                <th>STT</th>
                <th>Mã chuyên ngành</th>
                <th>Tên chuyên ngành</th>
                <th>Khoa</th>
            </tr>
          </thead>
          <tbody>
              <asp:Literal ID="ltr_cn" runat="server"></asp:Literal>
          </tbody>
    </table>
</asp:Content>
