<%@ Page Title="TƯ VẤN TRỰC TUYẾN VỚI CHUYÊN GIA" Language="C#" MasterPageFile="~/Share/san-khoa/Right_layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tu_van_Default" %>

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
                            Tư vấn trực tuyến
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
      <h1 class="bordered light" style="font-weight: bold">Tư vấn trực tuyến</h1>
    <div style="padding: 10px; background: #f3f3f3;font-weight:bold;margin-bottom:1px;">
        <span class="icon-map-marker"></span>Số 9, Trần Quốc Thảo, P.6, Q3, TP HCM.
    </div>
    <div style="padding: 10px; background: #f3f3f3;font-weight:bold">
        <span class="icon-phone"></span>Hotline: 0904 72 06 72 - 0938 228 768
    </div>
    <div style="padding:10px;border-radius:10px;margin:10px 0 10px 0;background:#f3f3f3">

    <iframe src="https://tawk.to/b0f6dd84ee4be193c148619b67fd391eb691c997/popout/default/?$_tawk_popout=true&$_tawk_sk=582191c88759b753e4cab7bb&$_tawk_tk=43484adfe1b7941980aa04bfbe50a4d1&v=518" width="100%" height="650" frameborder="0" style="border:0" allowfullscreen=""></iframe>
        
    </div>
</asp:Content>

