<%@ Page Title='<%: Page.Title %>' MetaDescription='<%: Page.MetaDescription  %>' MetaKeywords='<%: Page.MetaKeywords  %>' Language="C#" MasterPageFile="~/themes/main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/themes/right.ascx" TagPrefix="uc1" TagName="right" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctBreking" runat="Server">
    <div class="breaking-news-all">
        <div class="breaking-news-title">
            <h3 class="title">Tin mới nhất</h3>
        </div>
        <div class="breaking-news-content">
            <ul>
                <asp:Literal ID="ltbreaking_news" runat="server"></asp:Literal>
            </ul>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sections-id-1" style='margin-top: -60px; margin-bottom: 60px; padding-top: 30px; padding-bottom: 0px; background: #f8f8f8;' class="sections-content sections-builder sections sections-full-width">
        <div class="container">
            <div class="row">
                <div class="with-sidebar-container sidebar-container-builder">
                    <div class="main-container col-md-12">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box-slideshow box-slideshow-full slide-show-full slideshow-style-1">
                                    <ul>
                                        <asp:Literal ID="ltItemSlider" runat="server"></asp:Literal>
                                    </ul>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="sections-id-2" style='' class="sections-content sections-builder sections sections-right-sidebar">
        <div class="container">
            <div class="row">
                <div class="with-sidebar-container sidebar-container-builder">
                    <div class="main-container col-md-8">

                        <div class="row">
                            <asp:Literal ID="ltHome" runat="server"></asp:Literal>

                            <div class="col-md-12">
                                <div class="post-title post-title-news">
                                    <h3>Random News</h3>
                                </div>
                                <div class="clearfix"></div>
                                <div class="box-slideshow slide-show-sidebar slideshow-style-14">
                                    <ul>
                                        <li class="slider-item">

                                            <asp:Repeater ID="rpRandom" runat="server">
                                                <ItemTemplate>
                                                    <div class="box-slideshow-main box-slideshow-small">
                                                        <div class="box-slideshow-img">
                                                            <img alt='<%# Eval("tieude") %>' width='250' height='340' src='<%# Eval("hinhanh").ToString().IndexOf("http")==-1? "../uploadfile/postimages/" +Eval("hinhanh").ToString() : Eval("hinhanh").ToString() %>'>
                                                        </div>
                                                        <div class="slideshow-overlay"></div>
                                                        <div class="box-slideshow-content">
                                                            <div class="box-slideshow-outer">
                                                                <div class="box-slideshow-inner">
                                                                    <a class="box-news-overlay-3" href='<%# Eval("url") %>' title='<%# Eval("tieude") %>' rel="bookmark"></a>
                                                                    <span class="slide-category">
                                                                        <a href="/" title="View all posts in Oracle">Tin tuc</a> </span>
                                                                    <span class="slide-date"><i class="fa fa-calendar"></i><%# BaseView.getThang(ToSQL.SQLToDateTime(Eval("ngaydang"))) +" " +ToSQL.SQLToDateTime(Eval("ngaydang")).Month +" ,"+ ToSQL.SQLToDateTime(Eval("ngaydang")).Year  %></span>
                                                                    <div class="clearfix"></div>
                                                                    <a href='<%# Eval("url") %>' title='<%# Eval("tieude") %>' rel="bookmark"><%# Eval("tieude") %></a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </ItemTemplate>
                                            </asp:Repeater>



                                        </li>
                                    </ul>
                                </div>
                                <div class="clearfix"></div>
                            </div>

                            <div class="col-md-12">
                                <div class="box-border">
                                    <div class="post-title post-title-news">
                                        <h3>Bài mới</h3>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class='all-blogs'>
                                        <asp:Literal ID="ltlastnews" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="first-sidebar sidebar-col col-md-4 sticky-sidebar">
                        <uc1:right runat="server" ID="right" />
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
    <div id="sections-id-3" style='' class="sections-content sections-builder sections sections-full-width">
        <div class="container">
            <div class="row">
                <div class="with-sidebar-container sidebar-container-builder">
                    <div class="main-container col-md-12">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="scroll-news scroll-posts-full scroll-news-new scroll-news-small scroll-news-2 scroll-arrow-top">
                                    <div class="post-title post-title-news">
                                        <h3>Slideshow News</h3>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="row">
                                        <div class="head-slide scroll-posts head-slide-show">
                                            <ul>
                                                <asp:Literal ID="ltSileFoot" runat="server"></asp:Literal>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

