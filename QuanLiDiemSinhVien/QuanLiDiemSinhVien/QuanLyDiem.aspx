<%@ Page Title="Quản lý điểm" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuanLyDiem.aspx.cs" Inherits="QuanLiDiemSinhVien.QuanLyDiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>QUẢN LÝ ĐIỂM</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Thông tin điểm sinh viên</h3>
        </div>
        <div class="panel-body">
            <table class="table table-bordered">
                <tr>
                    <td style="width: 10%;">Mã sinh viên:</td>
                    <td style="width: 40%;">
                        <asp:TextBox ID="txt_masv" CssClass="txt_masv" Style="width: 73%" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 10%;">Điểm C:</td>
                    <td style="width: 40%;">
                        <asp:TextBox ID="txt_diemC" CssClass="txtdiem txt_diemC" Style="width: 73%" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_diemC" ErrorMessage="Lỗi: Bạn chưa nhập điểm!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Tên sinh viên:  </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" CssClass="DropDownList1" runat="server" DataTextField="Tensv" style="width:73%;" DataValueField="Masv" AppendDataBoundItems="true">
                            <asp:ListItem Value="" Text="----Chọn sinh viên----"></asp:ListItem>
                        </asp:DropDownList>
                    <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Chưa chọn sinh viên" ControlToValidate="DropDownList1" ValidationGroup="save">

                        </asp:RequiredFieldValidator>
                    </div>
                    </td>
                    <td>Điểm B:</td>
                    <td>
                        <asp:TextBox ID="txt_diemB" CssClass="txtdiem txt_diemB" Style="width: 73%" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_diemB" ErrorMessage="Lỗi: Bạn chưa nhập điểm!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Tên môn học:</td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="Tenmh" style="width:73%;" DataValueField="Tenmh" AppendDataBoundItems="true">
                            <asp:ListItem Value="" Text="----Chọn môn học----"></asp:ListItem>
                        </asp:DropDownList>
                        <div>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="Red" ControlToValidate="DropDownList2" ErrorMessage="Chưa chọn môn học" ValidationGroup="save">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>Thi lần 1:</td>
                    <td>
                        <asp:TextBox ID="txt_thi1" CssClass="txtdiem txt_thi1" Style="width: 73%" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_thi1" ErrorMessage="Lỗi: Bạn chưa nhập điểm!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Học kỳ:</td>
                    <td>
                        <asp:TextBox ID="txt_hocky" Style="width: 73%" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_hocky" ErrorMessage="Lỗi: Bạn chưa nhập học kỳ!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>Thi lần 2:</td>
                    <td>
                        <asp:TextBox ID="txt_thi2" CssClass="txtdiem txt_thi2" Style="width: 73%" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Năm học:</td>
                    <td>
                        <asp:TextBox ID="txt_namhoc" Style="width: 73%" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_namhoc" ErrorMessage="Lỗi: Bạn chưa nhập năm học!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>Tổng kết:</td>
                    <td>
                        <asp:TextBox ID="txt_diemtb" CssClass="txtdiem txt_diemtb" Style="width: 73%" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_diemtb" ErrorMessage="Lỗi: Bạn chưa nhập điểm!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div>
                            <asp:LinkButton ID="lbt_themsuaxoa" runat="server" class="btn btn-primary" ValidationGroup="save" Style="text-decoration: none; float: left;" OnClick="lbt_themsuaxoa_Click">Thêm mới</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger" CausesValidation="false" Style="text-decoration: none; margin-left: 20px;" OnClick="LinkButton1_Click"><i class="fa fa-reply-all" aria-hidden="true"> Hủy bỏ</i></asp:LinkButton><br />
                            <asp:Label ID="lbl_thongbao" runat="server" style="color: red;" Text=""></asp:Label>
                        </div>
                    </td>
                    <td>Xếp loại:</td>
                    <td>
                        <asp:TextBox ID="txt_xeploai" CssClass="txt_xeploai" Style="width: 73%" runat="server"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="save" Display="Dynamic" runat="server" ControlToValidate="txt_xeploai" ErrorMessage="Lỗi: Bạn chưa dữ liệu!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                        
            </table>
        </div>
    </div>
<script>
        $(".DropDownList1").change(function () {
            var selectedValue = $(this).val();
            $(".txt_masv").val($(this).find("option:selected").attr("value"))
        });
        function Diem(txtSelector)
        {
            if ($(txtSelector).val() !== null) {
                if ($.isNumeric($(txtSelector).val())) {
                    return parseFloat($(txtSelector).val());
                }
            }
            return 0;
        }
        function Summary()
        {
            var diemB = Diem("input.txt_diemB");
            var diemC = Diem("input.txt_diemC");
            var diemThi1 = Diem("input.txt_thi1");
            var diemThi2 = Diem("input.txt_thi2");
            var diemThi = 0;
            if (diemThi1 >= diemThi2)
                diemThi = diemThi1;
            else
                diemThi = diemThi2;

            var n = (diemB*0.3 + diemC*0.1 + diemThi*0.6);
            x = Math.round(n * 100) / 100;
            return x;
        }

        function Xeploai(xeploai) {
            if (xeploai < 4) {
                d = 'F';
            }
            else if (xeploai >= 4 && xeploai < 5) {
                    d = 'D';
            }
            else if (xeploai >= 5 && xeploai < 5.5) {
                d = 'D+';
            }
            else if (xeploai >= 5.5 && xeploai < 6.5) {
                d = 'C'; 
            }
            else if (xeploai >= 6.5 && xeploai < 7) {
                d = 'C+'; 
            }
            else if (xeploai >= 7 && xeploai < 8) {
                d = 'B'; 
            }
            else if (xeploai >= 8 && xeploai < 8.5) {
                d = 'B+'; 
            }
            else{
                d = 'A';

            }
            return d;
        }

        $('input.txtdiem').change(function () {
            var diem = Summary();
            $('input.txt_diemtb').val(diem);
            $('input.txt_xeploai').val(Xeploai(diem));
        });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <div class="form-inline" style="margin-bottom: 15px;">
            <asp:TextBox ID="tbx_key" class="form-control" style="width: 300px;" placeholder="Xin mời nhập để tìm kiếm" runat="server"></asp:TextBox>
            <asp:LinkButton ID="lbt_search" runat="server" class="btn btn-primary" style="text-decoration: none;" OnClick="lbt_search_Click"><i class="fa fa-search"></i>Tìm kiếm</asp:LinkButton>
            <br />
            <asp:Label ID="lbl_timkiem" class="label label-info" runat="server" Text=""></asp:Label>
        </div>
    <div>
        <table class="table table-hover">
            <thead>
                <tr style="color: black; background-color: cornflowerblue; font-weight: bold;">
                    <td>STT</td>
                    <td>Mã sinh viên</td>
                    <td>Tên SV</td>
                    <td>Tên môn</td>
                    <td>C</td>
                    <td>B</td>
                    <td>Thi(1)</td>
                    <td>Thi(2)</td>
                    <td>Tổng kết</td>
                    <td>Xếp loại</td>
                    <td>Học kỳ</td>
                    <td>Năm học</td>
                    <td>Sửa</td>
                    <td>Xóa</td>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltr_dsdiem" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div>
</asp:Content>

