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
        Form.Action = Request.RawUrl;
        if (!IsPostBack)
        {
            getDataLoai();

            DBClass _db = new DBClass();
            if (!String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string urlServer = BaseView.UrlServer();
                string urlCode = Request.QueryString["code"];
                string[] urlShort = Request.QueryString["code"].Split('/');
                if (urlShort.Length > 0)
                    urlCode = urlShort[urlShort.Length - 1];
                DataRow infoDM = _db.sqlGetData("select * from LoaiTin where code = '" + urlCode + "'").Rows[0];

                if (infoDM != null)
                {
                    int id = BaseView.GetIntFieldValue(infoDM, "id");
                    string sqlcommand = "select top(6) * from News where isActived = 1 and  (maloai = " + id + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + id + " ) ) order by id desc";
                    DataTable dtItemTopNews = _db.sqlGetData(sqlcommand);
                    ltbreaking_news.Text = getBreakNews(dtItemTopNews);

                    ltSileFoot.Text = fullSlideFoot();
                }
            }
        }
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

    private void getDataLoai()
    {
        DBClass _db = new DBClass();
        if (!String.IsNullOrEmpty(Request.QueryString["code"]))
        {
            string urlServer = BaseView.UrlServer();
            string urlCode = Request.QueryString["code"];
            string[] urlShort = Request.QueryString["code"].Split('/');
            if (urlShort.Length > 0)
                urlCode = urlShort[urlShort.Length - 1];
            DataRow infoDM = _db.sqlGetData("select * from LoaiTin where code = '" + urlCode + "'").Rows[0];

            if (infoDM != null)
            {
                int id = BaseView.GetIntFieldValue(infoDM, "id");
                string name = BaseView.GetStringFieldValue(infoDM, "name");
                string title = BaseView.GetStringFieldValue(infoDM, "title");
                string desc = BaseView.GetStringFieldValue(infoDM, "description");
                string content = BaseView.GetStringFieldValue(infoDM, "noidung");
                string keywords = BaseView.GetStringFieldValue(infoDM, "keywords");

                Page.Title = title == "" ? (BaseView.GetStringFieldValue(infoDM, "name")) : (title);
                Page.MetaDescription = desc;
                Page.MetaKeywords = keywords;
                //ltImg.Text = "<meta property='og:image' content='" + BaseView.UrlServer() + "/UploadFile/DanhMuc/" + BaseView.GetStringFieldValue(row, "hinhanh") + "'>";

                string sqlcommand = "SELECT top(5) * from News where isActived = 1 and  (maloai = " + id + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + id + " ) ) order by id desc";
                DataTable dtItemSlider = _db.sqlGetData(sqlcommand);
                ltItemSlider.Text = getItemSlider(dtItemSlider);


                sqlcommand = "SELECT top(6) * from News where isActived = 1 and  (maloai = " + id + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + id + " ) ) order by id desc";
                DataTable dtItem = _db.sqlGetData(sqlcommand);
                ltItem.Text = getHomeNewsF(dtItem);

              
                //Last Post
                sqlcommand = "SELECT top(5) * from News where isActived = 1 and  (maloai = " + id + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + id + " ) ) order by id desc";
                DataTable dtItemlastPost = _db.sqlGetData(sqlcommand);
                ltlastnews.Text = gethomeLastPost(dtItemlastPost);

                // Top news
                sqlcommand = "SELECT top(6) * from News where isActived = 1 and  (maloai = " + id + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + id + " ) ) order by id desc";
                DataTable dtItemTopNews = _db.sqlGetData(sqlcommand);
                ltbreaking_news.Text = getBreakNews(dtItemTopNews);
            }

        }
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
                html += "<time class='box-news-meta-date' datetime='"+ngaydang+"'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</time>";
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
        DBClass _db = new DBClass();
        string title = "", desc = "", url = "", img = "", html = "";
        string tendanhmuc = "", urlloai = "";
        int i = 0;

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
                html += "<a href='" + urlloai + "' title='" + tendanhmuc + "'>" + tendanhmuc + "</a>  </span>";
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
            if (desc.Length > 80)
                desc = desc.Substring(0, 80) + " ...";
            html += "<p>" + desc + "</p>";
            html += "<div class='post-more'><a class='button-default medium' href='/' title='" + title + "' rel='bookmark'><i class='fa fa-long-arrow-right'></i>Đọc tiếp</a></div>";
            html += "<div class='clearfix'></div>";
            html += "</div>";
            html += "</div>";
            html += "</article>";
        }
        return html;
    }
}