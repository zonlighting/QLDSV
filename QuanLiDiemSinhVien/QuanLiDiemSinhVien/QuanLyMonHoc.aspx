<%@ Page Title="Quản lý môn học" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuanLyMonHoc.aspx.cs" Inherits="QuanLiDiemSinhVien.QuanLyMonHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>QUẢN LÝ MÔN HỌC</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
      <div class="panel-heading">
          <h3 class="panel-title">Thông tin môn học</h3>
      </div>
      <div class="panel-body">
          <table class="table">
         <tr>
             <td> Mã môn học:</td>
             <td><asp:TextBox ID="txt_mamh" runat="server"></asp:TextBox>
                 <div>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_mamh" ErrorMessage="Lỗi: Bạn chưa nhập mã môn học!" ForeColor="Red"></asp:RequiredFieldValidator>
                 </div>
             </td>
             <td>Tên môn học:</td>
             <td>
                 <asp:TextBox ID="txt_tenmh" runat="server"></asp:TextBox>
                 <div>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_tenmh" ErrorMessage="Lỗi: Bạn chưa nhập tên môn học!" ForeColor="Red" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
             </td>
         </tr>
         <tr>
             <td>Số tín chỉ:</td>
             <td>
                 <asp:TextBox ID="txt_tinchi" runat="server"></asp:TextBox>
                 <div>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_tinchi" ErrorMessage="Lỗi: Bạn chưa nhập số tín chỉ!" ForeColor="Red" ValidationGroup="save" Display="Dynamic" ></asp:RequiredFieldValidator>
                 </div>
             </td>
             <td>Học kì:</td>
             <td>
                 <asp:TextBox ID="txt_hocki" runat="server"></asp:TextBox>
                 <div>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_hocki" ErrorMessage="Lỗi: Bạn chưa nhập học kì!" ForeColor="Red" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>
             </td>
         </tr> 
        <tr>
            <td></td>
            <td></td>
            <td>Giáo viên:</td>
            <td>
                <asp:TextBox ID="txt_gv" runat="server"></asp:TextBox>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_gv" ErrorMessage="Lỗi: Bạn chưa nhập tên giáo viên!" ForeColor="Red" ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                 <div>
                     <asp:LinkButton ID="btn_them" runat="server" ValidationGroup="save" class="btn btn-primary" Style="text-decoration: none; float: left;" OnClick="btn_them_Click">Thêm mới</asp:LinkButton>
                     <asp:LinkButton ID="btn_huy" runat="server" class="btn btn-danger" CausesValidation="false" Style="text-decoration: none; margin-left: 20px;" OnClick="btn_huy_Click"><i class="fa fa-reply-all" aria-hidden="true"> Hủy bỏ</i></asp:LinkButton><br />
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
                <th>Mã môn học</th>
                <th>Tên môn học</th>
                <th>Số tín chỉ</th>
                <th>Học kì</th>
                <th>Giáo viên</th>
                <th>Sửa</th>
                <th>Xóa</th>
            </tr>
          </thead>
          <tbody>
              <asp:Literal ID="ltr_monhoc" runat="server"></asp:Literal>
          </tbody>
        </table>
    </div>
</asp:Content>

