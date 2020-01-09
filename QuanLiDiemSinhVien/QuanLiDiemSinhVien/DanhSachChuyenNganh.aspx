<%@ Page Title="Danh sách chuyên ngành" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DanhSachChuyenNganh.aspx.cs" Inherits="QuanLiDiemSinhVien.DanhSachChuyenNganh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>DANH SÁCH CHUYÊN NGÀNH</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="form-inline" style="margin-bottom: 15px;">
            <asp:TextBox ID="txt_timkiem" class="form-control" style="width: 300px;" placeholder="Xin mời nhập để tìm kiếm" runat="server"></asp:TextBox>
            <asp:Button ID="timkiem" runat="server" Text="Tìm kiếm" class="btn btn-primary" OnClick="timkiem_Click" />
            <br /> 
            <asp:Label ID="lbl_timkiem" class="label label-info" runat="server" Text=""></asp:Label>
        </div>
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
    </div>
</asp:Content>

