<%@ Page Title="Liên hệ " MetaDescription="Đ/c:Số 9, Trần Quốc Thảo, P.6, Q3" Language="C#" MasterPageFile="~/Share/san-khoa/Right_layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ban_do_Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="Server">
    <asp:Literal ID="ltImg" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentbanner" runat="Server">

    <div class="container">
        <div class="main-wrapper">
            <div class="row">

                <div class="large-4 columns">
                    <ul class="nav-tags">
                        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
                            <a itemprop='url' href="/"><i class="fa fa-home"></i>Home</a>
                        </li>
                        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
                            <i class="fa fa-hand-o-right"></i>
                            Liên Hệ
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="main-wrapper" style="display: none">
        <div class="content_wrapper">
            <div class="row" style="border-top: 1px solid rgb(236, 190, 62);">
                <asp:Image ID="imgDanhMuc" runat="server" Width="100%" Visible="false" />
                <img src="../Share/images/shadow-foot.png" style="width: 100%; height: 15px" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPost" runat="Server">
    <h1 class="bordered light" style="font-weight: bold">Liên Hệ</h1>
    <div style="padding: 10px; background: #f3f3f3;font-weight:bold;margin-bottom:1px;">
        <span class="icon-map-marker"></span>Số 9, Trần Quốc Thảo, P.6, Q3, TP HCM.
    </div>
    <div style="padding: 10px; background: #f3f3f3;font-weight:bold">
        <span class="icon-phone"></span>Hotline: 0904 72 06 72 - 0938 228 768
    </div>

    <div style="padding: 10px; border-radius: 10px; margin: 10px 0 10px 0; background: #f3f3f3">

        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.430537665241!2d106.69140200000002!3d10.7783!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3a7b8a740f%3A0xab40f2706e9304f3!2zOSBUcuG6p24gUXXhu5FjIFRo4bqjbywgcGjGsOG7nW5nIDYsIFF14bqtbiAzLCBI4buTIENow60gTWluaCwgVmlldG5hbQ!5e0!3m2!1sen!2s!4v1441703410030" width="100%" height="450" frameborder="0" style="border: 0" allowfullscreen=""></iframe>

    </div>
</asp:Content>

