using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class themes_main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ltMenu.Text = getMenu();
       
            getCurrentPage();
            getBaiMoi();
            ltCanonical.Text = "<link rel='canonical' href='" + "http://" + Request.Url.Host + HttpContext.Current.Request.RawUrl+ "' />";
        }
    }
    private void getCurrentPage()
    {
        string html = "<meta name='DC.Publisher' content='News Online' />";
        html += "<meta name='DC.Title' content='" + Page.Title + "' />";
        html += "<meta name='DC.Description' content='" + Page.MetaDescription + "' />";
        html += "<meta property='og:type' content='website' />";
        html += "<meta property='og:locale' content='vi_VN' />";
        html += "<meta property='og:title' content='" + Page.Title + "' />";
        html += "<meta property='og:description' content='" + Page.MetaDescription + "' /> ";
        ltHeader.Text = html;
    }
    private string getMenu()
    {
        DBClass _db = new DBClass();
        string html = "";
        DataTable data = _db.get_menu_LoaiTin(0, 0);
        foreach (DataRow row in data.Rows)
        {
            string tieudeLoai = BaseView.GetStringFieldValue(row, "name"), urlLoai = "../" + BaseView.GetStringFieldValue(row, "code") + ".hxml";
            
            int idLoai = BaseView.GetIntFieldValue(row, "id");
            DataTable dataPa = _db.get_menu_LoaiTin(idLoai, 0);

            if (dataPa.Rows.Count > 0)
            {
                
                html += "<li id='menu-item-379' class='menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children menu-item-379 has-a-sub no-mega-menu menu-no-title'><a href='" + urlLoai + "' class=''>" + tieudeLoai + "</a>";
                html += "<ul class='sub-menu'>";
                foreach (DataRow rPa in dataPa.Rows)
                {
                    string tieudeLoai2 = BaseView.GetStringFieldValue(rPa, "name"), urlLoai2 = "../" + BaseView.GetStringFieldValue(rPa, "code") + ".hxml";
                    html += "<li id='menu-item-382' class='menu-item menu-item-type-taxonomy menu-item-object-category menu-item-382 no-mega-menu menu-no-title'><a href='"+urlLoai2+"' class=''>"+tieudeLoai2+"</a></li>";
                }
                html += "</ul></li>";
            }
            else
            {
                html += getItemForMenu(idLoai,urlLoai,tieudeLoai);
            }
            // Dong tat
            html += "</li>";
        }
        return html;
    }
    private string getItemForMenu(int idLoai, string urlLoai, string tieudeLoai)
    {
        string htnl = "";
        DBClass _db = new DBClass();
        string html = "";
        html += "<li id='menu-item-375' class='menu-item menu-item-type-taxonomy menu-item-object-category menu-item-375 has-a-sub mega-menu-posts mega-menu-posts-2 mega-menu menu-no-title two-columns'><a href='" + urlLoai + "' class=''>" + tieudeLoai + "</a><div class='mega-menu-content menu-sub-content'>";
        DataTable dataNews = _db.sqlGetData("select top(7) * from News where maloai =" + idLoai+" order by id desc");
        if (dataNews.Rows.Count > 0)
        {
            html += "<div class='mega-menu-block'>";
            html += "<div class='row'>";
            html += "<div class='box-news box-news-1'>";
            html += "<ul>";
            string title = "", desc = "", url = "", img = "";
            int i = 0;
            foreach (DataRow rowNews in dataNews.Rows)
            {
                i++;
                title = BaseView.GetStringFieldValue(rowNews, "tieude");
                desc = BaseView.GetStringFieldValue(rowNews, "tomtat");
                url = "../" + BaseView.GetStringFieldValue(rowNews, "url");
                img = BaseView.GetStringFieldValue(rowNews, "hinhanh");
                if (img.IndexOf("http") == -1)
                {
                    img = "../uploadFile/postImages/" + img;
                }
                DateTime ngaydang = BaseView.GetDateTimeFieldValue(rowNews, "ngaydang");
                if (i == 1)
                {
                    html += "<li class='col-md-4'>";
                    html += "<div class='box-news-big'>";
                    html += "<div class='box-news-img'>";
                    html += "<img alt='" + title + "' width='550' height='350' src='" + img + "'><div class='box-news-overlay'><a href='" + url + "' title='" + title + "' rel='bookmark'></a></div>";
                    html += "</div>";
                    html += "<div class='box-news-content'>";
                    html += "<div class='box-news-title'><a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + "</a></div>";
                    html += "<div class='box-news-meta'>";
                    html += "<time class='box-news-meta-date' datetime='" + ngaydang + "'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</time>";
                    html += "<a class='box-news-meta-comment' href='" + url + "#respond'><i class='fa fa-comments-o'></i>0</a><div class='box-news-meta-view'><i class='fa fa-eye'></i>232</div>";
                    html += "</div>";
                    html += "</div>";
                    html += "<div class='clearfix'></div>";
                    html += "</div>";
                    html += "</li>";
                }
                else
                {
                    html += "<li class='col-md-4'>";
                    html += "<div class='box-news-small'>";
                    html += "<div class='box-news-img'>";
                    html += "<img alt='" + title + "' width='188' height='144' src='" + img + "'><div class='box-news-overlay'><a href='" + url + "' title='" + title + "' rel='bookmark'></a></div>";
                    html += "</div>";
                    html += "<div class='box-news-content'>";
                    html += "<div class='box-news-title'><a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + "</a></div>";
                    html += "<div class='box-news-meta'>";
                    html += "<time class='box-news-meta-date' datetime='" + ngaydang + "'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</time>";
                    html += "<a class='box-news-meta-comment' href='" + url + "#respond'><i class='fa fa-comments-o'></i>0</a><div class='box-news-meta-view'><i class='fa fa-eye'></i>57</div>";
                    html += " </div>";
                    html += "</div>";
                    html += "<div class='clearfix'></div>";
                    html += "</div>";
                    html += "</li>";
                }
            }

            html += "</ul>";
            html += "</div>";
            html += "<div class='clear'></div>";
            html += "</div>";
            html += " </div>";
            html += "</div>";
        }
        
        return html;
    }


    private void getBaiMoi()
    {
        DBClass _db = new DBClass();
        string sqlCMD = "select top 4 * from news order by id desc";
        DataTable dt = _db.sqlGetData(sqlCMD);
        rpBai.DataSource = dt;
        rpBai.DataBind();

        sqlCMD = "select top 16 * from news order by id desc";
        dt = _db.sqlGetData(sqlCMD);
        rpNewImages.DataSource = dt;
        rpNewImages.DataBind();

        sqlCMD = "select top 1 * from news order by newid()";
        dt = _db.sqlGetData(sqlCMD);
        rpFootNews.DataSource = dt;
        rpFootNews.DataBind();

    }
}
