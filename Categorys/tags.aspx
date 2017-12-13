<%@ Page Title='<%: Page.Title %>' Language="C#" MasterPageFile="~/Share/medical/_layoutRightBar.master" AutoEventWireup="true" CodeFile="tags.aspx.cs" Inherits="Categorys_tags" %>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="Server">
    <asp:Literal ID="ltImg" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ptTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentLeft" runat="Server">
     <div class="postOfCat">
        <asp:Repeater ID="rpData" runat="server">
            <ItemTemplate>
                <div class="large-4 columns">
                    <article class="post col-2">
                        <div class="post_img">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("url") %>' AlternateText='<%# Eval("Title") %>' ImageUrl='<%# "~/UploadFile/postImages/"+Eval("HinhAnh") %>'> <%# Eval("Title") %></asp:HyperLink>
                            <ul class="meta">
                                <li><i class="icon-comment"></i>13 comments</li>
                                <li><i class="icon-calendar"></i>Mar 09, 2013</li>
                            </ul>
                        </div>
                        <h2>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("url")  %>'> <%# Eval("Title") %></asp:HyperLink></h2>
                        <p class="post_text"><%# Eval("Desc").ToString().Length > 75? Eval("Desc").ToString().Substring(0,75) : Eval("Desc") %> ...</p>
                        <a href='<%# "~/" + Eval("url") %>' class="button">Xem thêm</a>
                        <div class='fb-like' data-href='<%# "~/" + Eval("url")  %>' data-layout='standard' data-action='like' data-show-faces='true' data-share='true'></div>
                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
    </div>
    <div>
        Trang hiện tại:
        <asp:Literal ID="ltPage" runat="server" Text="1"></asp:Literal>
        <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" >
            <ItemTemplate>
                <asp:LinkButton ID="btnPage" CssClass="btnPager"
                    CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

