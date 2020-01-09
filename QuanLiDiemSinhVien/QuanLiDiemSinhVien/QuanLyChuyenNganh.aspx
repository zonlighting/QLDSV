<%@ Page Title="Quản lý chuyên ngành" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuanLyChuyenNganh.aspx.cs" Inherits="QuanLiDiemSinhVien.QuanLyChuyenNganh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>QUẢN LÝ CHUYÊN NGÀNH</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
      <div class="panel-heading">
          <h3 class="panel-title">Thông tin chuyên ngành</h3>
      </div>
      <div class="panel-body">
          <table class="table">
              <tr>
                  <td>Mã chuyên ngành:</td>
                  <td>
                      <asp:TextBox ID="txt_macn" runat="server"></asp:TextBox>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ValidationGroup="save" ControlToValidate="txt_macn" ErrorMessage="Lỗi: Bạn chưa nhập mã chuyên ngành" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                  </td>
                  <td>Tên chuyên ngành:</td>
                  <td>
                      <asp:TextBox ID="txt_tencn" runat="server"></asp:TextBox>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ValidationGroup="save" ControlToValidate="txt_tencn" ErrorMessage="Lỗi: Bạn chưa nhập tên chuyên ngành!" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                  </td>
              </tr>
              <tr>
                  <td></td>
                  <td></td>
                  <td>Khoa:</td>
                  <td>
                      <asp:DropDownList ID="DropDownList1" AppendDataBoundItems="true" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="" Text="----Chọn khoa----"></asp:ListItem>
                      </asp:DropDownList>
                      <div>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Lỗi: Bạn chưa chọn khoa!" ForeColor="Red"></asp:RequiredFieldValidator>                            
                      </div>
                  </td>
              </tr>
              <tr>
                  <td></td>
                    <td>
                        <div>
                            <asp:LinkButton ID="btn_them" runat="server" ValidationGroup="save" class="btn btn-primary" Style="text-decoration: none; float: left;" OnClick="btn_them_Click" >Thêm mới</asp:LinkButton>
                            <asp:LinkButton ID="btn_huy" runat="server" class="btn btn-danger" CausesValidation="false" Style="text-decoration: none; margin-left: 20px;" OnClick="btn_huy_Click"><i class="fa fa-reply-all" aria-hidden="true"> Hủy bỏ</i></asp:LinkButton><br />
                            <asp:Label ID="lbl_tb" runat="server" style="color: red;" Text=""></asp:Label>
                        </div>
                    </td>
                  <td></td>
                  <td></td>
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
                <th>Mã chuyên ngành</th>
                <th>Tên chuyên ngành</th>
                <th>Khoa</th>
                <th>Sửa</th>
                <th>Xóa</th>
            </tr>
          </thead>
          <tbody>
              <asp:Literal ID="ltr_chuyennganh" runat="server"></asp:Literal>
          </tbody>
        </table>
    </div>
</asp:Content>

