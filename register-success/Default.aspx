<%@ Page Title="Cảm ơn quý khách đã gửi thông tin, chúng tôi sẽ phản hồi thông tin sớm nhât!" Language="C#" MasterPageFile="~/Share/san-khoa/Right_layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="register_success_Default" %>

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
                            <asp:Literal ID="ltCat" runat="server"></asp:Literal>
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
   
    <span style="    display: block;
    padding: 25px;
    color: #48b24b;
    border: 1px solid #48b24b;
    border-radius: 10px;
    background: #f3f3f3;
    font-weight: bold;
    font-size: 2em;"> Cảm ơn quý khách đã gửi thông tin, chúng tôi sẽ phản hồi thông tin sớm nhât!</span>

</asp:Content>

