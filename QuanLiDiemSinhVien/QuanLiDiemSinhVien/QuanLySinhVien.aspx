<%@ Page Title="Quản lý sinh viên" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuanLySinhVien.aspx.cs" Inherits="QuanLiDiemSinhVien.QuanLySinhVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="scripts/jquery-ui-1.12.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>QUẢN LÝ SINH VIÊN</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
      <div class="panel-heading">
          <h3 class="panel-title">Thông tin sinh viên</h3>
      </div>
      <div class="panel-body">
          <table class="table table-bordered">
              <tr>
                  <td  style="width: 10%;">Mã sinh viên:</td>
                  <td  style="width: 40%;"><asp:TextBox ID="txt_msv"  Style="width: 73%" runat="server"></asp:TextBox></td>
                  <td  style="width: 13%;">Tên sinh viên:</td>
                  <td  style="width: 40%;">
                      <asp:TextBox ID="txt_tensv" Style="width: 73%" runat="server"></asp:TextBox>
                      <div>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_tensv" ErrorMessage="Lỗi: Vui lòng nhập họ tên sinh viên!" Display="Dynamic" ValidationGroup="save" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                  </td>
              </tr>
              <tr>
                  <td>Ngày sinh:</td>
                  <td>
                      <asp:TextBox ID="txt_ngaysinh" class="txt_ngaysinh" Style="width: 73%" runat="server" autocomplete="off"></asp:TextBox>
                      <script type="text/javascript">
                        $(function () {
                            $('.txt_ngaysinh').datepicker({
                                changeMonth: true,
                                changeYear: true,
                                dateFormat: "dd/mm/yy",
                                language: "tr"
                            });
                        });
                    </script>
                  </td>
                  <td>Giới tính:</td>
                  <td>
                      <asp:RadioButton ID="rbt_nam" runat="server" GroupName="gioitinh" Text="Nam" />
                      <asp:RadioButton ID="rbt_nu" runat="server" GroupName="gioitinh" Text="Nữ" />
                  </td>
              </tr>
              <tr>
                  <td>Email:</td>
                  <td>
                      <asp:TextBox ID="txt_email" Style="width: 73%" runat="server" TextMode="Email"></asp:TextBox>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_email" ErrorMessage="Lỗi: Bạn chưa nhập Email!" ForeColor="Red"></asp:RequiredFieldValidator>                            
                      </div>
                  </td>
                  <td>Địa chỉ:</td>
                  <td>
                      <asp:TextBox ID="txt_diachi" Style="width: 73%" runat="server"></asp:TextBox>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_diachi" ErrorMessage="Lỗi: Bạn chưa nhập địa chỉ!" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                  </td>
              </tr>
              <tr>
                  <td>Khóa học:</td>
                  <td>
                      <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Tenkh" style="width:73%;" DataValueField="Makh" AppendDataBoundItems="true">
                          <asp:ListItem Value="" Text="----Chọn khóa học----"></asp:ListItem>
                      </asp:DropDownList>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Lỗi: Bạn chưa chọn khóa học!" ForeColor="Red"></asp:RequiredFieldValidator>                            
                      </div>
                  </td>
                  <td>Chuyên ngành:</td>
                  <td>
                      <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="Tencn" style="width:73%;" DataValueField="Macn" AppendDataBoundItems="true"> 
                          <asp:ListItem Value="" Text="----Chọn chuyên ngành----"></asp:ListItem>
                      </asp:DropDownList>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="DropDownList2" ErrorMessage="Lỗi: Bạn chưa chọn chuyên ngành!" ForeColor="Red"></asp:RequiredFieldValidator>                            
                      </div>
                  </td>
              </tr>
              <tr>
                  <td></td>
                    <td>
                        <div>
                            <asp:LinkButton ID="lbt_themsuaxoa" runat="server" CssClass="btn btn-primary" style="text-decoration: none; float: left;" ValidationGroup="save" OnClick="lbt_themsuaxoa_Click">Thêm mới</asp:LinkButton>
                            <asp:LinkButton ID="lbt_cancel" runat="server" CssClass="btn btn-danger" Style="text-decoration: none; margin-left: 20px;" CausesValidation="false" OnClick="lbt_cancel_Click"><i class="fa fa-reply-all" aria-hidden="true"> Hủy bỏ</i></asp:LinkButton><br />
                            <asp:Label ID="lbl_tb" runat="server" style="color: red;" Text=""></asp:Label>
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
                <th>Sửa</th>
                <th>Xóa</th>
            </tr>
          </thead>
          <tbody>
              <asp:Literal ID="ltr_quanlysv" runat="server"></asp:Literal>
          </tbody>
        </table>
    </div>
</asp:Content>

