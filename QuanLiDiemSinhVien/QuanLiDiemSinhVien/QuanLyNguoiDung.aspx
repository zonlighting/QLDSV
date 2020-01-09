<%@ Page Title="Quản lý người dùng" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuanLyNguoiDung.aspx.cs" Inherits="QuanLiDiemSinhVien.QuanLyNguoiDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Thông tin người dùng</h3>
        </div>
        <div class="panel-body">
            <table class="table table-bordered">
                <tr>
                    <td style="width: 10%;">id:</td>
                    <td style="width: 40%;">
                        <asp:TextBox ID="txt_id" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="save" Display="Dynamic" ControlToValidate="txt_id" ErrorMessage="Lỗi: Vui lòng điền id!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td style="width: 10%;">Giới tính:</td>
                    <td style="width: 40%;">
                      <asp:RadioButton ID="rbt_nam" runat="server" GroupName="gioitinh" Text="Nam" />
                      <asp:RadioButton ID="rbt_nu" runat="server" GroupName="gioitinh" Text="Nữ" />
                    </td>
                </tr>
                <tr>
                    <td>Tên đăng nhập: </td>
                    <td>
                        <asp:TextBox ID="txt_user" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save" Display="Dynamic" ControlToValidate="txt_user" ErrorMessage="Lỗi: Vui lòng điền tên đăng nhập!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>Mật khẩu:</td>
                    <td>
                        <asp:TextBox ID="txt_pass" runat="server" TextMode="Password"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_pass" ErrorMessage="Lỗi: Bạn chưa nhập mật khẩu.Vui lòng kiểm tra lại!" ForeColor="Red" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Họ tên:</td>
                    <td>
                        <asp:TextBox ID="txt_hoten" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_hoten" ErrorMessage="Lỗi: Vui lòng nhập họ tên!" ForeColor="Red" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txt_email" runat="server" TextMode="Email"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_email" ErrorMessage="Lỗi: Bạn chưa nhập Email!" ForeColor="Red" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>Quyền:</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="" Text="----Chọn quyền----"></asp:ListItem>
                      </asp:DropDownList>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Lỗi: Bạn chưa chọn quyền!" ForeColor="Red"></asp:RequiredFieldValidator>                            
                      </div>
                    </td>

                </tr>

                <tr>
                    <td></td>
                    <td>
                        <div>
                            <asp:LinkButton ID="btn_them" runat="server" ValidationGroup="save" class="btn btn-primary" Style="text-decoration: none; float: left;" OnClick="btn_them_Click1">Thêm mới</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger" CausesValidation="false" Style="text-decoration: none; margin-left: 20px;" OnClick="LinkButton1_Click"><i class="fa fa-reply-all" aria-hidden="true"> Hủy bỏ</i></asp:LinkButton><br />
                            <asp:Label ID="lbl_tb" runat="server" Style="color: red;" Text=""></asp:Label>
                        </div>
                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div>
        <div class="form-inline" style="margin-bottom: 15px;">
            <asp:TextBox ID="txt_timkiem" class="form-control" runat="server" style="width: 300px;" placeholder="Xin mời nhập để tìm kiếm"></asp:TextBox>
            <asp:Button ID="timkiem" runat="server" class="btn btn-primary" Text="Tìm kiếm" OnClick="timkiem_Click" /> 
            <br />
            <asp:Label ID="lbl_timkiem" class="label label-info" runat="server" Text=""></asp:Label>
        </div>
        <table class="table table-hover">
            <thead>
                <tr style="color: black; background-color: cornflowerblue; font-weight: bold;">
                    <th>STT</th>
                    <th>id</th>
                    <th>Tên đăng nhập</th>
                    <th>Mật khẩu</th>
                    <th>Họ tên</th>
                    <th>Giới tính</th>
                    <th>Email</th>
                    <th>Quyền</th>
                    <th>Sửa</th>
                    <th>Xóa</th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltr_acc" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>QUẢN LÝ NGƯỜI DÙNG</h1>
</asp:Content>

