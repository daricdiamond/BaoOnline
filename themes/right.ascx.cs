using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class themes_right : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
            getData();
    }
    private void getData()
    {
        DBClass _db = new DBClass();
        string sqlcommand = "select top(6)* from News order by id desc";
        DataTable dtItem = _db.sqlGetData(sqlcommand);
        ltSliderPost.Text = getSliderNews(dtItem);

        rpMoi.DataSource = dtItem;
        rpMoi.DataBind();

        sqlcommand = "select top(10)* from Loaitin";
        DataTable dtItemCat = _db.sqlGetData(sqlcommand);
        rpCat.DataSource = dtItemCat;
        rpCat.DataBind();
    }
    private string getSliderNews(DataTable data)
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
			if (img.IndexOf("http") == -1)
            {
                img = "../uploadFile/postImages/" + img;
            }
            DateTime ngaydang = BaseView.GetDateTimeFieldValue(row, "ngaydang");
            string tendanhmuc = "", urlloai = "";
            DBClass _db = new DBClass();
            DataRow rowLoai = _db.get_info_loai(BaseView.GetIntFieldValue(row, "maloai"));
            if (rowLoai != null)
            {
                tendanhmuc = BaseView.GetStringFieldValue(rowLoai, "name");
                urlloai = BaseView.GetStringFieldValue(rowLoai, "code") + ".hxml";
            }
            if (i == 1)
            {

                html += "<li class='col-md-12 slider-item'>";
                html += "<div class='box-slideshow-main box-slideshow-small'>";
                html += "<div class='box-slideshow-img'>";
                html += "<a href='" + url + "' title='" + title + "' rel='bookmark'>";
                html += "<img alt='" + title + "' width='360' height='229' src='" + img + "' />";
                html += "</a>";
                html += "<div class='slideshow-overlay'><a href='/' title='" + title + "' rel='bookmark'></a></div>";
                html += " </div>";
                html += "<div class='box-slideshow-content'>";
                html += "<div class='box-slideshow-outer'>";
                html += " <div class='box-slideshow-inner'>";
                html += "<span class='slide-category'>";
                html += " <a href='" + urlloai + "' title=''>" + tendanhmuc + "</a> </span>";
                html += "<span class='slide-date'><i class='fa fa-calendar'></i>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</span>";
                html += "<div class='clearfix'></div>";
                html += "<a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + " </a>";
                html += " </div>";
                html += " </div>";
                html += "</div>";
                html += "</div>";
                html += " </li>";
            }


        }
        return html;
    }
}