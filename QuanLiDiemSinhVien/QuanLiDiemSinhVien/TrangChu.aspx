<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="QuanLiDiemSinhVien.TrangChu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/vender/sb-admin-2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>TRANG CHỦ</h2>
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-blue">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-graduation-cap fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="Label_sinhvien" runat="server" Text="Label"></asp:Label></div>
                            <div>Sinh Viên!</div>
                        </div>
                    </div>
                </div>
                <a href="DanhSachSinhVien.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">Xem chi tiết</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>

        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-university fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="Label_khoa" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>Khoa!</div>
                        </div>
                    </div>
                </div>
                <a href="DanhSachKhoa.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">Xem chi tiết</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-yellow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-trophy fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="Label_chuyennganh" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>Chuyên ngành!</div>
                        </div>
                    </div>
                </div>
                <a href="DanhSachChuyenNganh.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">Xem chi tiết</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-book fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="Label_monhoc" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>Môn học!</div>
                        </div>
                    </div>
                </div>
                <a href="DanhSachMonHoc.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">Xem chi tiết</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panel-heading">
            <h4 class="panel-title" style="font-weight: bold;">Thông kê sinh viên theo chuyên ngành</h4>
        </div>
        <div class="panel-body">
            <table class="table table-hover">
                <thead>
                    <tr style="color: black; background-color: cornflowerblue; font-weight: bold;">
                        <th>STT</th>
                        <th>Chuyên ngành</th>
                        <th>Số sinh viên</th>
                        <th>Danh sách</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="ltr_sv_cn" runat="server"></asp:Literal>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="panel ">
        <div class="panel-heading">
            <h4 class="panel-title" style="font-weight: bold;">Thông kê chuyên ngành theo khoa </h4>
        </div>
        <div class="panel-body">
            <table class="table table-hover">
                <thead>
                    <tr style="color: black; background-color: cornflowerblue; font-weight: bold;">
                        <th>STT</th>
                        <th>Khoa</th>
                        <th>Số chuyên ngành</th>
                        <th>Danh sách</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="ltr_cn_khoa" runat="server"></asp:Literal>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

