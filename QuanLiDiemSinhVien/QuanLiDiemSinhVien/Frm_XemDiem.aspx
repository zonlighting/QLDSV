<%@ Page Title="Trang xem thông tin sinh viên" Language="C#" MasterPageFile="~/NguoiDung.Master" AutoEventWireup="true" CodeBehind="Frm_XemDiem.aspx.cs" Inherits="QuanLiDiemSinhVien.Frm_XemDiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-panel w3-border w3-round-xlarge w3-animate-top" style="width:500px; margin: auto; margin-top:80px; padding-left: 80px; background: #cce6ff; box-shadow: -1px 2px 3px 3px #e1e1d0;
    -moz-box-shadow: -1px 2px 3px 3px #e1e1d0;
    -webkit-box-shadow: -1px 2px 3px 3px #e1e1d0;"">
        <h3><strong>Xem điểm của sinh viên</strong></h3>
        <asp:TextBox ID="txt_search" class="w3-input w3-border w3-round-xlarge" style="width: 260px;" placeholder="Nhập vào mã sinh viên" runat="server"></asp:TextBox>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_search" ValidationGroup="save" Display="Dynamic" ErrorMessage="Mời bạn nhập mã sinh viên" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div style="padding-left:100px; padding-bottom: 20px;">
            <asp:Button ID="btn_search" class="w3-button w3-hover-blue-gray" ValidationGroup="save" style="width:120px; background-color: #3C8DBC; color: white;" runat="server" Text="OK" OnClick="Button1_Click" />
        <br />
    </div>
    </div>
</asp:Content>

