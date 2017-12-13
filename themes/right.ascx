<%@ Control Language="C#" AutoEventWireup="true" CodeFile="right.ascx.cs" Inherits="themes_right" %>
<aside class="sidebar">
    <div id="search-2" class="widget widget_search">
       <iframe src="//adi.admicro.vn/adt/banners/nam2015/4043/min_html5/tungns/2017_08_07/amnhac-71/amnhac/amnhac.html?url=%2F%2Flg1.logging.admicro.vn%2Fcpx%3Fcov%3D1%26tpn%3D1%26dmn%3Dhttp%253A%252F%252Fkenh14.vn%252F%26cmpg%3D1289358%26items%3D525886%26zid%3D50%26cid%3D-1%26lsn%3D1503452245963%26ce%3D1%26lc%3D%26cr%3D%26ui%3D%26re%3Dhttps%253A%252F%252Fwww.facebook.com%252Fthandongamnhacofficial%252F%253Futm_source%253DAdMicro%2526utm_medium%253DCPD%2526utm_campaign%253Dthandongamnhac&amp;admid=ads_zone50_banner525886" width="100%" frameborder="0" scrolling="no" height="600"></iframe>
    </div>
    <div id="widget_counter-3" class="widget widget-statistics widget-margin-custom widget-margin-20">
        <div class="widget-title">
            <h3>Follow Us</h3>
        </div>
        <div class="clearfix"></div>
        <div class="widget-wrap">
            <div class="social-ul">
                <ul class=" social-background">
                    <li class="social-facebook">
                        <a href="https://www.facebook.com/" target="_blank"><i class="fa fa-facebook"></i></a>
                        <span>427</span>
                        Fans </li>
                    <li class="social-twitter">
                        <a href="http://twitter.com" target="_blank"><i class="fa fa-twitter"></i></a>
                        <span>61214</span>
                        Followers </li>
                    <li class="social-gplus">
                        <a href="https://plus.google.com" target="_blank"><i class="fa fa-google-plus"></i></a>
                        <span>12806</span>
                        Followers </li>
                    <li class="social-vimeo">
                        <a href="https://vimeo.com/channels/" target="_blank"><i class="fa fa-vimeo-square"></i></a>
                        <span>3</span>
                        Subscribers </li>
                    <li class="social-youtube">
                        <a href="http://www.youtube.com/channel/" target="_blank"><i class="fa fa-youtube-play"></i></a>
                        <span>446</span>
                        Followers </li>
                </ul>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <div class="worldplus-ad">
        <a href="/">
            <img alt="" src="../content/uploads/2016/05/336x280_3.png" />
        </a>
    </div>
    <div class="clearfix"></div>
    <div id="post_slideshow-widget-2" class="widget post_slideshow-widget widget-box-news" style='display:none'>
        <div class="widget-title">
            <h3>Slide</h3>
        </div>
        <div class="clearfix"></div>
        <div class="widget-wrap">
            <div class="box-news box-news-1 slider-arrow-top">
                <div class="row head-slide-show">
                    <ul>
                        <asp:Literal ID="ltSliderPost" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <div id="widget_posts-2" class="widget widget-posts">
        <div class="widget-title">
            <h3>Bài mới</h3>
        </div>
        <div class="clearfix"></div>
        <div class="widget-wrap">
            <ul class='widget-posts'>

                <asp:Repeater ID="rpMoi" runat="server">
                    <ItemTemplate>
                        <li class="widget-posts-image">
                            <div class="box-news-small">
                                <div class="box-news-img">
                                    <img alt='<%# Eval("tieude") %>' width='94' height='73' src='<%# Eval("hinhanh").ToString().IndexOf("http")==-1? "../uploadfile/postimages/" +Eval("hinhanh").ToString() : Eval("hinhanh").ToString() %>'>
                                    <div class="box-news-overlay"><a href='<%# Eval("url") %>' title='<%# Eval("tieude") %>' rel="bookmark"></a></div>
                                </div>
                                <div class="box-news-content">
                                    <div class="box-news-title"><a href='<%# Eval("url") %>' title='<%# Eval("tieude") %>' rel="bookmark"><%# Eval("tieude") %> </a></div>
                                    <div class="box-news-meta">
                                        <time class="box-news-meta-date" datetime='<%# Eval("ngaydang") %>'><i class="fa fa-calendar"></i><%# BaseView.getThang(ToSQL.SQLToDateTime(Eval("ngaydang"))) +" " +ToSQL.SQLToDateTime(Eval("ngaydang")).Day +" ,"+ ToSQL.SQLToDateTime(Eval("ngaydang")).Year  %></time>
                                        <a class="box-news-meta-comment" href='<%# Eval("url") %>'><i class="fa fa-comments-o"></i>0</a>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>


            </ul>
        </div>
    </div>
	
    <div id="categories-2" class="widget widget_categories">
		
        <div class="widget-title">
            <h3>Danh mục</h3>
        </div>
        <div class="clearfix"></div>
        <ul style="    margin-bottom: 50px;">
            <asp:Repeater ID="rpCat" runat="server">
                <ItemTemplate>
                    <li class="cat-item cat-item-12"><a href='<%# "../"+Eval("code")+".hxml" %>'><%# Eval("name") %></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>


        </ul>
		<iframe src="//adi.admicro.vn/adt/banners/nam2015/4043/min_html5/dieplamthi/2017_08_18/300x600.edit/300x600.edit/300x600.edit.html?url=%2F%2Flg1.logging.admicro.vn%2Fcpx%3Fcov%3D1%26tpn%3D1%26dmn%3Dhttp%253A%252F%252Fkenh14.vn%252F%26cmpg%3D1289620%26items%3D527131%26zid%3D253%26cid%3D-1%26lsn%3D1503452245963%26ce%3D1%26lc%3D%26cr%3D%26ui%3D%26re%3Dhttps%253A%252F%252Fgoo.gl%252F2L9vWL&amp;admid=ads_zone253_banner527131" width="300" frameborder="0" scrolling="no" height="600"></iframe>
    </div>
</aside>
