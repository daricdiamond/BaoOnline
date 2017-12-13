<%@ Page Title='<%: Page.Title %>' MetaDescription='<%: Page.MetaDescription  %>' MetaKeywords='<%: Page.MetaKeywords  %>' Language="C#" MasterPageFile="~/themes/secondMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Posts_Default" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ctHead" runat="Server">
    <asp:Literal ID="ltImg" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ctBreakingS" runat="Server">
    <style>
        .post-inner-content table {
            text-align:center;
            border:none;
        }
        .post-inner-content table td{
            border:0px solid #e2e2e2;
        }
        .main-sections {
    margin: 25px auto;
}
    </style>
    <div class="breadcrumbs">
        <div class="crumbs">
            <a href="/"><i class="fa fa-home"></i>Home</a><span class="crumbs-span">&raquo;</span><span class="current"></span><asp:Literal ID="ltCat" runat="server"></asp:Literal>
            <span class="crumbs-span">&raquo;</span><span class="current"></span>
            <asp:Literal ID="ltTitle2" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctArticer" runat="Server">
    <article class="v-post single-article clearfix article-title-meta-image post-no-tags post--content image_post post-no-border post-review-active post-346 post type-post status-publish format-standard has-post-thumbnail hentry category-apple" itemscope="" itemtype="http://schema.org/Article">
        <iframe src="//adi.admicro.vn/adt/cpc/cpm7k/2017/08/1160x-1502685816.html?url=%2F%2Flg1.logging.admicro.vn%2Fcpx%3Fcov%3D1%26dmn%3Dhttp%253A%2F%2Fkenh14.vn%2F%26lsn%3D1503452245963%26ce%3D1%26lc%3D%26cr%3D%26ui%3D%26cmpg%3D1289602%26items%3D527064%26zid%3D13227%26cid%3D-1%26tp%3D8%26tpn%3D5%26re%3Dhttps%253A%252F%252Fwww.facebook.com%252Fyeudidungsomovie%252F%253Futm_source%253DAdMicro%2526amp%253Butm_medium%253DCPM%2526amp%253Butm_campaign%253DCGV_yeudidungso_1160x250_Aug2017&amp;admid=cpmzone_13227_0_527064" width="100%" height="250" frameborder="0" scrolling="no"></iframe>
		<h1 class="post-head-title">
            <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
        </h1>
        <div class="clearfix"></div>
        <div class="post-meta">
            <div class="post-meta-date"><i class="fa fa-calendar"></i>
                <asp:Literal ID="ltngaydang" runat="server"></asp:Literal></div>
            <div class="post-meta-category"><i class="fa fa-folder-o"></i>
                <asp:Literal ID="ltCattag" runat="server"></asp:Literal></div>
            <div class="post-meta-comment"><i class="fa fa-comments-o"></i><a href="index.html#respond">0 Comments</a></div>
            <div class="post-meta-view"><i class="fa fa-eye"></i>Views : 206</div>
            <div class="post-meta-like"><a class="post-like " title="Love" id="post-like-346"><i class="fa fa-heart-o"></i><span>0</span></a></div>
        </div>
        <div class="clearfix"></div>
        <div class="post-img post-img-9" style="display:none">
            <div class="post-type"><i class="fa fa-image"></i></div>
            <blockquote>
                 <asp:Literal ID="ltDescPost" runat="server" Text=""></asp:Literal>
            </blockquote>
        </div>
        <div class="post-inner">
            <div class="post-inner-content">
                <asp:Literal ID="ltContent" runat="server" Text=""></asp:Literal>
            </div>
            <div class="clearfix"></div>
            <div class="post-tag-share">
                <div class="post-share">
                    <i class="fa fa-share"></i>
                    <span>Share : </span>
                    <!-- Go to www.addthis.com/dashboard to customize your tools --> <div class="addthis_inline_share_toolbox"></div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="fb-comments" data-href='<%= BaseView.UrlServer() + HttpContext.Current.Request.RawUrl %>' data-numposts="5"></div>
    </article>
<iframe src="//adi.admicro.vn/adt/cpc/cpm7k/2017/08/1160x-1502685816.html?url=%2F%2Flg1.logging.admicro.vn%2Fcpx%3Fcov%3D1%26dmn%3Dhttp%253A%2F%2Fkenh14.vn%2F%26lsn%3D1503452245963%26ce%3D1%26lc%3D%26cr%3D%26ui%3D%26cmpg%3D1289602%26items%3D527064%26zid%3D13227%26cid%3D-1%26tp%3D8%26tpn%3D5%26re%3Dhttps%253A%252F%252Fwww.facebook.com%252Fyeudidungsomovie%252F%253Futm_source%253DAdMicro%2526amp%253Butm_medium%253DCPM%2526amp%253Butm_campaign%253DCGV_yeudidungso_1160x250_Aug2017&amp;admid=cpmzone_13227_0_527064" width="100%" height="250" frameborder="0" scrolling="no"></iframe>
    <div class="v-post user-area" style="display:none">
        <div class="post-inner">
            <div class="post-author">
                <a href="/">
                    <img alt='Ahmed Hassan' src='../content/images/up/dell-2-110x110.jpg'></a>
            </div>
            <div class="user-content">
                <h4>Ahmed Hassan</h4>
                <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                <div class="social-ul">
                    <ul>
                        <li class="social-facebook"><a data-title="Facebook" class="tooltip-n" href="#" target="_blank"><i class="fa fa-facebook"></i></a></li>
                        <li class="social-twitter"><a data-title="Twitter" class="tooltip-n" href="#" target="_blank"><i class="fa fa-twitter"></i></a></li>
                        <li class="social-google"><a data-title="Google+" class="tooltip-n" href="#" target="_blank"><i class="fa fa-google-plus"></i></a></li>
                        <li class="social-linkedin"><a data-title="Linkedin" class="tooltip-n" href="#" target="_blank"><i class="fa fa-linkedin"></i></a></li>
                        <li class="social-pinterest"><a data-title="Pinterest" class="tooltip-n" href="#" target="_blank"><i class="fa fa-pinterest"></i></a></li>
                        <li class="social-instagram"><a data-title="Instagram" class="tooltip-n" href="#" target="_blank"><i class="fa fa-instagram"></i></a></li>
                        <li class="social-youtube"><a data-title="Youtube" class="tooltip-n" href="#" target="_blank"><i class="fa fa-youtube-play"></i></a></li>
                    </ul>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <div class="v-post related-posts-div">
        <div class="post-inner">
            <div class="post-title">
                <h3>Related Posts</h3>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="head-slide related-posts head-slide-show related-posts-half">
                    <ul>
                        <asp:Literal ID="ltSliderPost" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <div id="respond" class="v-post" style="display:none">
        <div class="post-inner">
            <div class="post-title">
                <h3>Leave a reply</h3>
            </div>
            <div class="clearfix"></div>
            <div class="comment-form">
                <div  id="commentform">
                    <div class="form-input">
                        <input type="text" name="author" value="" id="comment_name" aria-required="true" placeholder="Your Name">
                    </div>
                    <div class="form-input form-input-last">
                        <input type="email" name="email" value="" id="comment_email" aria-required="true" placeholder="Email">
                    </div>
                    <div class="form-input form-input-full">
                        <input type="url" name="url" value="" id="comment_url" placeholder="URL">
                    </div>
                    <div class="form-input form-textarea">
                        <textarea id="comment" name="comment" aria-required="true" placeholder="Comment"></textarea>
                    </div>
                    <div class="cancel-comment-reply"><a rel="nofollow" id="cancel-comment-reply-link" href="index.html#respond" style="display: none;">Click here to cancel reply.</a></div>
                    <input name="submit" type="submit" id="submit" value="Post Comment" class="button-default">
                    <input type='hidden' name='comment_post_ID' value='346' id='comment_post_ID' />
                    <input type='hidden' name='comment_parent' id='comment_parent' value='0' />
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

