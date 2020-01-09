<%@ Page Title="Trang đăng nhập" Language="C#" MasterPageFile="~/NguoiDung.Master" AutoEventWireup="true" CodeBehind="Frm_Login.aspx.cs" Inherits="QuanLiDiemSinhVien.frm_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class=" w3-border w3-round-xlarge" style="width:500px; height:auto; margin:5px auto; padding: 10px; background: #cce6ff; box-shadow: -1px 2px 3px 3px #e1e1d0;
    -moz-box-shadow: -1px 2px 3px 3px #e1e1d0;
    -webkit-box-shadow: -1px 2px 3px 3px #e1e1d0;">
            <h3 style="text-align: center;">    Đăng nhập hệ thống</h3>
              <div class="w3-center">
              </div>
            <div style=" margin-left:50px;">
                Tên đăng nhập:
                <br />
                <asp:TextBox ID="txt_user" runat="server" class="w3-input w3-border w3-round-xlarge" style="width:370px;" placeholder="Tên đăng nhập"></asp:TextBox>
                <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_user" ForeColor="Red" ErrorMessage="Vui lòng nhập tên đăng nhập!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div style=" margin-left:50px;">
                Mật khẩu:
                <br />
                <asp:TextBox ID="txt_pass" runat="server" class="w3-input w3-border w3-round-xlarge" style="width:370px;" placeholder="Mật khẩu" TextMode="Password" ></asp:TextBox>
                <div>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pass" ForeColor="Red" ErrorMessage="Bạn chưa nhập password!"></asp:RequiredFieldValidator>
                </div>             
            </div>
                       <!-- <asp:TextBox ID="TextBox2" class="w3-input w3-border w3-round-xlarge" style="width:370px; margin-left:50px;" runat="server" placeholder="Tên đăng nhập"></asp:TextBox>  
                        <asp:TextBox ID="TextBox3" class="w3-input w3-border w3-round-xlarge" style="width:370px; margin-left:50px; margin-top:10px;" runat="server" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox> 
            <br /> -->
                <div style="text-align: center;">
                    <asp:Button ID="btn_ok" class="w3-btn w3-border w3-ho w3-round-xlarge" style="width:120px; background-color:#3C8DBC; color:white;" runat="server" Text="Đăng nhập" OnClick="btn_ok_Click" />
                    <asp:Button ID="btn_cancel" class="w3-btn w3-border w3-ho w3-round-xlarge w3-red" style="width:120px;" runat="server" Text="Hủy bỏ" CausesValidation="false" OnClick="btn_cancel_Click"/>
                    <asp:Label ID="lbl_tb" runat="server"></asp:Label>
                </div>
      </div>
</asp:Content>

