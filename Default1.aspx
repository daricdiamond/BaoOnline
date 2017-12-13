<%@ Page Title='<%: Page.Title %>' Language="C#" MasterPageFile="~/Share/san-khoa/Main.master" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/Share/san-khoa/Home_CamNghi.ascx" TagPrefix="uc1" TagName="Home_CamNghi" %>
<%@ Register Src="~/Share/san-khoa/Home_DichVu.ascx" TagPrefix="uc1" TagName="Home_DichVu" %>
<%@ Register Src="~/Share/san-khoa/Home_DatHen.ascx" TagPrefix="uc1" TagName="Home_DatHen" %>
<%@ Register Src="~/Share/san-khoa/Home_QuiTrinh.ascx" TagPrefix="uc1" TagName="Home_QuiTrinh" %>
<%@ Register Src="~/Share/san-khoa/Home_TaiSao.ascx" TagPrefix="uc1" TagName="Home_TaiSao" %>
<%@ Register Src="~/Share/san-khoa/Home_Banner.ascx" TagPrefix="uc1" TagName="Home_Banner" %>
<%@ Register Src="~/Share/san-khoa/Home_BaiMoi.ascx" TagPrefix="uc1" TagName="Home_BaiMoi" %>








<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Banner" runat="Server">
    <uc1:Home_Banner runat="server" ID="Home_Banner" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">


    <uc1:Home_TaiSao runat="server" ID="Home_TaiSao" />

    <uc1:Home_QuiTrinh runat="server" ID="Home_QuiTrinh" />

    <uc1:Home_DichVu runat="server" ID="Home_DichVu" />

 <%--   <uc1:Home_DatHen runat="server" ID="Home_DatHen" />--%>

    <div class="height40"></div>

    <uc1:Home_BaiMoi runat="server" id="Home_BaiMoi" />



    <uc1:Home_CamNghi runat="server" ID="Home_CamNghi" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
    <!-- This page
	============================================= -->

    <script src='<%= ResolveUrl("~/Share/san-khoa/js/jquery.themepunch.plugins.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/Share/san-khoa/js/jquery.themepunch.revolution.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/Share/san-khoa/js/color-switcher.js") %>'></script>

    <script>

        (function () {

            // Revolution slider
            var revapi;
            revapi = jQuery('.tp-banner').revolution(
            {
                delay: 9000,
                startwidth: 1170,
                startheight: 576,
                hideThumbs: 200,
                fullWidth: "on",
                forceFullWidth: "on"
            });


            /* ------------------------------------------------------------------------ 
               SMALL HEADER 
            ------------------------------------------------------------------------ */
            function checkWidth() {
                var windowSize = $(window).width();

                if (windowSize >= 767) {
                    jQuery(window).scroll(function () {
                        var scroll = jQuery(window).scrollTop();
                        if (scroll >= 1) {
                            jQuery(".fixed-header").addClass("small-header");
                            jQuery(".navbar-brand img").attr("src", "Share/san-khoa/images/logo.png");
                        }
                        else {
                            jQuery(".fixed-header").removeClass("small-header");
                            jQuery(".navbar-brand img").attr("src", "Share/san-khoa/images/logo2.png");
                        }
                    });
                }
            }

            // Execute on load
            checkWidth();
            // Bind event listener
            $(window).resize(checkWidth);








        })(jQuery);

    </script>



    <!-- Mirrored from wahabali.com/work/medicom/index2.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 05 Oct 2016 06:43:04 GMT -->
</asp:Content>

