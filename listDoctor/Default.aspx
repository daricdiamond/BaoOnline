<%@ Page Title="Lịch bác sĩ Y khoa Diamond" Language="C#" MasterPageFile="~/Share/layout/_Share.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="listDoctor_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">

    <%--<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>--%>
    <script>
        $(function () {
            $("#txtNgayHen").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholder" runat="Server">
    <div class="lich-bs">
        <h1 style="padding: 10px; color: #434645; font-weight: bold; text-transform: uppercase; text-align: center">Lịch Bác Sĩ</h1>

        -  Thứ Hai - Thứ Sáu: 7:30 - 20:30
        <br />

        - Thứ Bảy: 7:30 - 16:30<br />

        - Chủ Nhật: 7:30 - 11:30<br />

        - Ngày lễ - Tết: nghỉ<br />

        <h2 style="padding: 10px; color: #434645; font-weight: bold; text-transform: uppercase; text-align: center">Chọn Bác Sĩ Để Xem Lịch</h2>

        <div>Chọn chuyên khoa</div>
        <asp:DropDownList ID="ddlChuyenKhoa" DataTextField="name" DataValueField="Id" runat="server" OnSelectedIndexChanged="ddlChuyenKhoa_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <div>Chọn bác sĩ</div>
        <asp:DropDownList ID="lsBacsi" runat="server" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="lsBacsi_SelectedIndexChanged"></asp:DropDownList>
        <asp:GridView ID="grvTaskNew" runat="server"
            AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="id"
            ShowHeaderWhenEmpty="True" PageSize="15"
            AllowSorting="True" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lbThu" runat="server" Text='<%# Eval("Thu") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ff9966" Font-Bold="true" ForeColor="White" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sáng">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%" CssClass='<%# Eval("Sang").ToString().ToLower().Trim() != ""? "td-active":"td"  %>'>

                            <asp:TextBox ID="txtSang" runat="server" Text='<%# Eval("Sang") %>' Enabled="false" CssClass="txtLich"></asp:TextBox>
                        </asp:Panel>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chiều">
                    <ItemTemplate>
                        <asp:Panel ID="Panel12" runat="server" Width="100%" Height="100%" CssClass='<%# Eval("Chieu").ToString().ToLower().Trim() != ""? "td-active":"td"  %>'>

                            <asp:TextBox ID="txtChieu" runat="server" Text='<%# Eval("Chieu") %>' Enabled="false" CssClass="txtLich"></asp:TextBox>
                        </asp:Panel>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tối">
                    <ItemTemplate>
                        <asp:Panel ID="Panel11" runat="server" Width="100%" Height="100%" CssClass='<%# Eval("Toi").ToString().ToLower().Trim() != ""? "td-active":"td"  %>'>

                            <asp:TextBox ID="txtToi" runat="server" Text='<%# Eval("Toi") %>' Enabled="false" CssClass="txtLich"></asp:TextBox>
                        </asp:Panel>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <section class="widget widget-appointment" style="margin-top: 50px;">
            <div class="widget-title">Đặt lịch hẹn</div>

            <div class="row">
                <asp:TextBox ID="txtHoTen" runat="server" Height="50px" Width="100%" placeholder="Họ tên"></asp:TextBox>
                <i class="fa fa-user"></i>
            </div>
            <div class="row">
                <asp:TextBox ID="txtSoDienThoai" runat="server" Height="50px" Width="100%" placeholder="Số điện thoại"></asp:TextBox>
                <i class="fa fa-phone"></i>
            </div>
            <div class="row">
                <asp:TextBox ID="txtEmail" runat="server" Height="50px" Width="100%" placeholder="Địa chỉ email"></asp:TextBox>
                <i class="fa fa-envelope"></i>
            </div>
            <div class="row">
                <asp:TextBox ID="txtNgayHen" runat="server" ClientIDMode="Static" Height="50px" Width="100%" placeholder="Ngày hẹn"></asp:TextBox>
                <i class="fa fa-calendar"></i>
            </div>
            <div class="row">
                <asp:TextBox ID="txtLoiNhan" runat="server" Height="50px" Width="100%" placeholder="Lời nhắn (Ví dụ: tôi đặt hẹn lúc 9h30, ...)" cols="30" Rows="5" CssClass="textarea"></asp:TextBox>
                <i class="fa fa-align-left"></i>
            </div>
            <asp:Button ID="btnDatLich" runat="server" Text="Đặt lịch" OnClick="btnDatLich_Click" class="button button-primary" />

        </section>
        <!--/ appointment -->
    </div>



</asp:Content>

