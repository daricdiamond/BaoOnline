using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();

            ltHome.Text = htmlHome();

            getHeader();

        }
    }
    private void getHeader()
    {
        DBClass _db = new DBClass();
        DataRow dr = _db.get_info_caidat();
        if (dr != null)
        {
            string title = BaseView.GetStringFieldValue(dr, "tieudetrangchu");
            string desc = BaseView.GetStringFieldValue(dr, "description").Replace("&nbsp;", " ");
            string keys = BaseView.GetStringFieldValue(dr, "keywords").Replace("&nbsp;", " ");

            Page.Title = title;
            Page.MetaDescription = desc;
            Page.MetaKeywords = keys;

        }
    }
    private void getData()
    {
        DBClass _db = new DBClass();
        string sqlcommand = "select top(6)* from News order by id desc";
        DataTable dtItem = _db.sqlGetData(sqlcommand);
        //ltItem.Text = getHomeNewsF(dtItem);

        // Slider
        sqlcommand = "select top(5)* from News order by id desc";
        DataTable dtItemSlider = _db.sqlGetData(sqlcommand);
        ltItemSlider.Text = getItemSlider(dtItemSlider);
        //Last Post
        sqlcommand = "select top(5)* from News order by id desc";
        DataTable dtItemlastPost = _db.sqlGetData(sqlcommand);
        ltlastnews.Text = gethomeLastPost(dtItemlastPost);

        // Top news
        sqlcommand = "select top(6)*  from News order by id desc";
        DataTable dtItemTopNews = _db.sqlGetData(sqlcommand);
        ltbreaking_news.Text = getBreakNews(dtItemTopNews);

        ltSileFoot.Text = fullSlideFoot();


        sqlcommand = "select top(3)*  from News order by id desc";
        DataTable dtItemRandomNews = _db.sqlGetData(sqlcommand);
        rpRandom.DataSource = dtItemRandomNews;
        rpRandom.DataBind();



    }
    private string getBreakNews(DataTable data)
    {
        string title = "", desc = "", url = "", img = "", html = "";
        int i = 0;
        foreach (DataRow row in data.Rows)
        {
            i++;
            title = BaseView.GetStringFieldValue(row, "tieude");
            desc = BaseView.GetStringFieldValue(row, "tomtat");
            url = BaseView.GetStringFieldValue(row, "url");
            img = BaseView.GetStringFieldValue(row, "hinhanh");
            html += "<li><a href='" + url + "' title='' rel='bookmark'>" + title + " </a></li>";
        }
        return html;
    }

    private string getHomeNewsF(DataTable dt)
    {
        string title = "", desc = "", url = "", img = "", html = "";
        int i = 0;
        foreach (DataRow row in dt.Rows)
        {
            i++;
            title = BaseView.GetStringFieldValue(row, "tieude");
            desc = BaseView.GetStringFieldValue(row, "tomtat");
            url = BaseView.GetStringFieldValue(row, "url");
            img = BaseView.GetStringFieldValue(row, "hinhanh");
            if (img.IndexOf("http") == -1)
            {
                img = "../uploadFile/postImages/" + img;
            }
            DateTime ngaydang = BaseView.GetDateTimeFieldValue(row, "ngaydang");
            if (i == 1)
            {
                html += "<li class='col-md-6 col-sm-6 col-xs-6 col-mo-100'>";
                html += "<div class='box-news-big'>";
                html += "<div class='box-news-img'>";
                html += "<img alt='" + title + "' width='409' height='260' src='" + img + "'>";
                html += "<div class='box-news-overlay'><a href='" + url + "' title='" + title + "' rel='bookmark'></a></div>";
                html += "</div>";
                html += "<div class='box-news-content'>";
                html += "<div class='box-news-title'><a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + " </a></div>";
                html += "<div class='box-news-meta box-meta-author'>";
                html += "<div class='box-news-meta-author'>";
                html += "<div class='post-meta-author'>";
                html += "<img alt='Phong Lê' src='content/images/up/dell-2-27x27.jpg'><a href='" + url + "' title='Làm đẹp' rel='author'>Phong Lê</a>";
                html += "</div>";
                html += "</div>";
                html += "<time class='box-news-meta-date' datetime='" + ngaydang + "'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</time>";
                html += "<a class='box-news-meta-comment' href='" + url + "#respond'><i class='fa fa-comments-o'></i>0</a>";
                html += "<div class='box-news-meta-view'><i class='fa fa-eye'></i>377</div>";
                html += "</div>";
                html += "<div class='box-news-desc'>";
                html += "<p>" + desc + "</p>";
                html += "</div>";
                html += "<div class='box-news-more'><a href='" + url + "' title='" + title + "' rel='bookmark'>Đọc tiếp</a></div>";
                html += "</div>";
                html += "<div class='clearfix'></div>";
                html += "</div>";
                html += "</li>";
            }
            else
            {
                html += "<li class='col-md-6 col-sm-6 col-xs-6 col-mo-100'>";
                html += "<div class='box-news-small'>";
                html += "<div class='box-news-img'>";
                html += "<img alt='" + title + "' width='94' height='73' src='" + img + "'>";
                html += "<div class='box-news-overlay'><a href='" + url + "' title='" + title + "' rel='bookmark'></a></div>";
                html += " </div>";
                html += "<div class='box-news-content'>";
                html += "<div class='box-news-title'><a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + "</a></div>";
                html += "<div class='box-news-meta'>";
                html += "<time class='box-news-meta-date' datetime=''" + ngaydang + "'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</time>";
                html += "<a class='box-news-meta-comment' href='" + url + "#respond'><i class='fa fa-comments-o'></i>0</a>";
                html += "<div class='box-news-meta-view'><i class='fa fa-eye'></i>216</div>";
                html += "</div>";
                html += "</div>";
                html += "<div class='clearfix'></div>";
                html += "</div>";
                html += "</li>";
            }
        }
        return html;
    }

    private string getItemSlider(DataTable data)
    {
        string title = "", desc = "", url = "", img = "", html = "";

        int i = 0;
        DBClass _db = new DBClass();
        html += "<li class='slider-item'>";
        foreach (DataRow row in data.Rows)
        {
            i++;
            title = BaseView.GetStringFieldValue(row, "tieude");
            desc = BaseView.GetStringFieldValue(row, "tomtat");
            url = BaseView.GetStringFieldValue(row, "url");
            img = BaseView.GetStringFieldValue(row, "hinhanh");

            if (img.IndexOf("http") == -1)
            {
                img = "../uploadFile/postImages/" + img;
            }
            string tendanhmuc = "", urlloai = "";
            DataRow rowLoai = _db.get_info_loai(BaseView.GetIntFieldValue(row, "maloai"));
            if (rowLoai != null)
            {
                tendanhmuc = BaseView.GetStringFieldValue(rowLoai, "name");
                urlloai = BaseView.GetStringFieldValue(rowLoai, "code") + ".hxml";
            }
            DateTime ngaydang = BaseView.GetDateTimeFieldValue(row, "ngaydang");
            if (i == 1)
            {
                html += "<div class='box-slideshow-main box-slideshow-big'>";
                html += "<div class='box-slideshow-img'>";
                html += "<img alt='" + title + "' width='570' height='500' src='" + img + "'>";
                html += "</div>";
                html += "<div class='slideshow-overlay'></div>";
                html += "<div class='box-slideshow-content'>";
                html += "<div class='box-slideshow-outer'>";
                html += "<div class='box-slideshow-inner'>";
                html += "<a class='box-news-overlay-3' href='" + url + "' title='" + title + "' rel='bookmark'></a>";
                html += "<span class='slide-category'>";

                html += "<a href='" + urlloai + "' title='" + tendanhmuc + "'>" + tendanhmuc + "</a> </span>";
                html += " <span class='slide-date'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</span>";
                html += "<div class='clearfix'></div>";
                html += "<a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + " </a>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";

            }
            else
            {
                html += "<div class='box-slideshow-main box-slideshow-small'>";
                html += "<div class='box-slideshow-img'>";
                html += "<img alt='" + title + "' width='285px' height='250px' src='" + img + "'>";
                html += "</div>";
                html += "<div class='slideshow-overlay'></div>";

                html += "<div class='box-slideshow-content'>";
                html += "<div class='box-slideshow-outer'>";
                html += "<div class='box-slideshow-inner'>";
                html += "<a class='box-news-overlay-3' href='" + url + "' title='" + title + "' rel='bookmark'></a>";
                html += "<span class='slide-category'>";
                html += "<a href='" + urlloai + "' title='" + tendanhmuc + "'>" + tendanhmuc + "</a>  </span>";
                html += "<span class='slide-date'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</span>";
                html += "<div class='clearfix'></div>";
                html += "<a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + "</a>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += " </div>";
            }
        }
        html += "</li>";
        return html;
    }

    private string gethomeLastPost(DataTable data)
    {
        string title = "", desc = "", url = "", img = "", html = "";
        int i = 0;

        foreach (DataRow row in data.Rows)
        {
            i++;
            title = BaseView.GetStringFieldValue(row, "tieude");
            desc = BaseView.RemoveHtmlTagsUsingCompiledRegex(BaseView.GetStringFieldValue(row, "noidung"));
            url = BaseView.GetStringFieldValue(row, "url");
            img = BaseView.GetStringFieldValue(row, "hinhanh");
            if (img.IndexOf("http") == -1)
            {
                img = "../uploadFile/postImages/" + img;
            }
            DateTime ngaydang = BaseView.GetDateTimeFieldValue(row, "ngaydang");
            html += "<article class='v-post clearfix article-title-meta-image post-style-6 animation post--content image_post post-no-border post-349 post type-post status-publish format-standard has-post-thumbnail hentry category-apple' data-animate='fadeInUp' itemscope='' itemtype='http://schema.org/Article'>";
            html += "<div class='post-img post-img-9'>";
            html += "<div class='post-type'><i class='fa fa-image'></i></div>";
            html += "<a href='" + url + "' title='" + title + "' rel='bookmark' class='post-img-link'>";
            html += "<img alt='" + title + "' width='280px' height='230px' style='width: 250px;' src='" + img + "' />";
            html += "</a>";
            html += "</div>";
            html += "<div class='post-inner-6'>";
            html += "<h3 class='post-head-title'>";
            html += "<a itemprop='url' href='" + url + "' title='" + title + "' rel='bookmark'>" + title + "</a>";
            html += " </h3>";
            html += "<div class='post-meta'>";
            html += "<div class='post-meta-author'>";
            html += "<img alt='Ahmed Hassan' src='content/images/up/dell-2-27x27.jpg'><a href='author/' title='Posts by Ahmed Hassan' rel='author'>Ahmed Hassan</a>";
            html += "</div>";
            html += "<div class='post-meta-date'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</div>";
            html += "<div class='post-meta-category'><i class='fa fa-folder-o'></i><a href='/' rel='category tag'>Apple</a></div>";
            html += "<div class='post-meta-comment'><i class='fa fa-comments-o'></i><a href='" + url + "#respond'>0 Comments</a></div>";
            html += "</div>";
            html += "<div class='clearfix'></div>";
            html += "<div class='post-inner'>";
            if (desc.Length > 150)
                desc = desc.Substring(0, 150) + " ...";
            html += "<p>" + desc + "</p>";
            html += "<div class='post-more'><a class='button-default medium' href='/' title='" + title + "' rel='bookmark'><i class='fa fa-long-arrow-right'></i>Đọc tiếp</a></div>";
            html += "<div class='clearfix'></div>";
            html += "</div>";
            html += "</div>";
            html += "</article>";
        }
        return html;
    }

    private string htmlHome()
    {
        string html = "";
        DBClass _db = new DBClass();

        DataTable data = _db.get_menu_LoaiTin(0, 0);
        int id_box_news = 0;
        foreach (DataRow row in data.Rows)
        {
            id_box_news++;

            html += "<div class='col-md-12'><div class='box-border'>";
            int idLoai = BaseView.GetIntFieldValue(row, "id");
            string tieudeLoai = BaseView.GetStringFieldValue(row, "name"), urlLoai = "../" + BaseView.GetStringFieldValue(row, "code") + ".hxml";
            html += "<div class='post-title post-title-news post-title-tabs' data-not_duplicate='' data-sidebar='sidebar' data-box='home_1' data-rand='15' data-posts='6' data-orderby='recent' data-meta='on' data-date='on' data-author='on' data-comment='on' data-views='on' data-title='10' data-excerpt='35' data-more='on' data-meta_another='on' data-date_another='on' data-comment_another='on' data-views_another='on' data-title_another='10' data-excerpt_another='35'>";
            html += "<ul class='tabs tabs-" + id_box_news + "'>";
            html += "<li class='tab' data-cat-id='" + idLoai + "'><a href='" + urlLoai + "'>" + tieudeLoai + "</a></li>";
            DataTable dataPa = _db.get_menu_LoaiTin(idLoai, 0);
            if (dataPa.Rows.Count > 0)
            {
                foreach (DataRow rPa in dataPa.Rows)
                {
                    int idLoai2 = BaseView.GetIntFieldValue(rPa, "id");
                    string tieudeLoai2 = BaseView.GetStringFieldValue(rPa, "name"), urlLoai2 = "../" + BaseView.GetStringFieldValue(rPa, "code") + ".hxml";
                    html += "<li class='tab' data-cat-id='" + idLoai2 + "'><a href='" + urlLoai2 + "'>" + tieudeLoai2 + "</a></li>";
                }
            }
            html += "<li class='clearfix'></li>";
            html += "</ul>";
            html += "</div>";

            // process body
            html += "<div class='clearfix'></div>";
            html += "<div class='box-news box-news-1 box-news-sidebar'>";

            html += "<div class='tab-inner-warp tab-inner-warp-" + id_box_news + " tab-inner-warp-" + id_box_news + "-" + idLoai + "'>";
            html += "<div class='row'>";
            html += "<ul>";
            string sql = "SELECT top(5) * from News where isActived = 1 and  (maloai = " + idLoai + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + idLoai + " ) ) order by id desc";
            DataTable dataItem = _db.sqlGetData(sql);
            html += getHomeNewsF(dataItem);
            html += "</ul>";
            html += " </div>";
            html += "</div>";

            //DataTable dataPa2 = _db.get_menu_LoaiTin(idLoai, 0);
            //if (dataPa2.Rows.Count > 0)
            //{
            //    foreach (DataRow rPa2 in dataPa.Rows)
            //    {
            //        int idLoai2 = BaseView.GetIntFieldValue(rPa2, "id");
            //        string tieudeLoai2 = BaseView.GetStringFieldValue(rPa2, "name"), urlLoai2 = "../" + BaseView.GetStringFieldValue(rPa2, "code") + ".hxml";
            //        html += "<div class='tab-inner-warp tab-inner-warp-1 tab-inner-warp-" + id_box_news + "-" + idLoai2 + "'>";
            //        html += "<div class='row'>";
            //        html += "<ul>";
            //        //"select top(5)* from News order by id desc";
            //        sql = "SELECT top(5) * from News where isActived = 1 and  (maloai = " + idLoai2 + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + idLoai2 + " ) ) order by id desc";
            //        DataTable dataItem2 = _db.sqlGetData(sql);
            //        html += getHomeNewsF(dataItem);

            //        html += "</ul>";
            //        html += " </div>";
            //        html += "</div>";

            //    }
            //}
            html += " <div class='clearfix'></div>";
            html += " </div></div>";

            //Endbody
            html += "</div>";

            //html += htmlBody + htmlEnd;
        }

        return html;
    }
    private string fullSlideFoot()
    {
        string html = "";
        DBClass _db = new DBClass();
        DataTable data = _db.get_menu_LoaiTin(0, 0);

        foreach (DataRow row in data.Rows)
        {
            html += "<li class='slider-item'>";
            int idLoai = BaseView.GetIntFieldValue(row, "id");
            string sql = "SELECT top(6) * from News where isActived = 1 and  (maloai = " + idLoai + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + idLoai + " ) ) order by id desc";
            DataTable dataItem = _db.sqlGetData(sql);
            html += itemSlideFootHome(dataItem);
            html += "</li>";
        }
        return html;
    }
    private string itemSlideFootHome(DataTable dt)
    {
        DBClass _db = new DBClass();
        string title = "", desc = "", url = "", img = "", html = "";
        int i = 0;
        foreach (DataRow row in dt.Rows)
        {
            i++;
            title = BaseView.GetStringFieldValue(row, "tieude");
            desc = BaseView.GetStringFieldValue(row, "tomtat");
            url = BaseView.GetStringFieldValue(row, "url");
            img = BaseView.GetStringFieldValue(row, "hinhanh");
            if (img.IndexOf("http") == -1)
            {
                img = "../uploadFile/postImages/" + img;
            }
            string tendanhmuc = "", urlloai = "";
            DataRow rowLoai = _db.get_info_loai(BaseView.GetIntFieldValue(row, "maloai"));
            if (rowLoai != null)
            {
                tendanhmuc = BaseView.GetStringFieldValue(rowLoai, "name");
                urlloai = "../" + BaseView.GetStringFieldValue(rowLoai, "code") + ".hxml";
            }
            DateTime ngaydang = BaseView.GetDateTimeFieldValue(row, "ngaydang");
            html += "<article class='slide-item col-xs-6 col-md-2'>";
            html += "<div class='slide-content'>";
            html += "<div class='slide-data'>";
            html += "<div class='slide-data-outer'>";
            html += "<div class='slide-data-inner'>";
            html += "<a class='slide-link' href='" + url + "' title='" + title + "' rel='bookmark'></a>";
            html += "<span class='slide-category'>";
            html += "<a href='" + urlloai + "' title='" + tendanhmuc + "'> " + tendanhmuc + "</a> </span>";
            html += "<span class='slide-date'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</span>";
            html += "<span class='slide-review'></span>";
            html += "</div>";
            html += "</div>";
            html += "</div>";
            html += "<div class='slide-hover'></div>";
            html += "<div class='slide-image'>";
            html += "<span><img alt='" + title + "' width='263' height='187' src='" + img + "'></span>";
            html += "</div>";
            html += " </div>";
            html += "<h4 class='slide-title'><a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + "</a></h4>";
            html += "</article>";

        }
        return html;
    }


}