<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="QuanLiDiemSinhVien.DoiMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>QUẢN LÝ NGƯỜI DÙNG</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
      <div class="panel-heading">
          <h3 class="panel-title">Đổi mật khẩu tài khoản</h3>
      </div>
      <div class="panel-body">
          <table class="table table-bordered" >
              <tr>
                  <td style="text-align:right">Tên đăng nhập:</td>
                  <td>

                      <asp:TextBox ID="txt_user" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>

                  </td>
              </tr>
              <tr>
                  <td style="text-align:right">Mật khẩu mới:</td>
                  <td>

                      <asp:TextBox ID="txt_newpass" runat="server" TextMode="Password" Width="200px"></asp:TextBox>

                  </td>
              </tr>
              <tr>
                  <td style="text-align:right">Nhập lại mật khẩu mới:</td>
                  <td>

                      <asp:TextBox ID="txt_renewpass" runat="server" TextMode="Password" Width="200px"></asp:TextBox>

                      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_newpass" ControlToValidate="txt_renewpass" Display="Dynamic" EnableTheming="True" ErrorMessage="Lỗi ! Hai mật khẩu không trùng nhau " ForeColor="Red" Font-Bold="True"></asp:CompareValidator>

                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:LinkButton ID="btn_ok" runat="server"  class="btn btn-primary" Style="text-decoration: none; float: right;" OnClick="btn_ok_Click">Xác nhận</asp:LinkButton>
                  </td>
                  <td>
                      <asp:LinkButton ID="btn_cancel" runat="server" class="btn btn-danger"  Style="text-decoration: none; float: left; " OnClick="btn_cancel_Click">Hủy bỏ</asp:LinkButton>
                  </td>
              </tr>
              <tr>
                  <td >

                      <asp:Label ID="lbl_tb" runat="server"  Font-Bold="True" ForeColor="#009900"></asp:Label>

                  </td>
              </tr>
              </table>
      </div>
    </div>
</asp:Content>

