using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Posts_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        HttpCookie cookie = Request.Cookies["adminUserName"];
        if (cookie != null)
        {
            //btnSua.Visible = true;
        }
        if (!IsPostBack)
        {
            getInfo();
            getData();
            //getComments();
        }
    }
    public string geturlShare()
    {
        DBClass _db = new DBClass();
        string urlOut = "";
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            string url = Request.QueryString["id"] + ".html";
            DataRow rowPost = _db.sqlGetDataRow("select * from News where url = '" + url + "'");
            if (rowPost == null)
            {
                rowPost = _db.Get_URL_Pages(url);
            }
            if (rowPost != null)
            {
                string title = BaseView.GetStringFieldValue(rowPost, "title");
                string desc = BaseView.GetStringFieldValue(rowPost, "desc");
                urlOut = "http://2code.info/demo/themes/WorldPlus/TechDemo/2016/05/19/48-million-in-iphone-sales-leads-apples-q4-2015-earnings/&amp;";
                urlOut += "p[images][0]=http://2code.info/demo/themes/WorldPlus/TechDemo/wp-content/uploads/2016/05/apple-9-1024x682-400x200.jpg&amp;";
                urlOut += "p[title]=" + title + "&amp;";
                urlOut += "p[summary]="+desc;
            }
        }
        return urlOut;
    }
    private void getData()
    {
        DBClass _db = new DBClass();
        string sqlcommand = "select top(6)* from News";
        DataTable dtItem = _db.sqlGetData(sqlcommand);
        ltSliderPost.Text = getSliderfoot(dtItem);
    }

    private string convertStringLinks(string s)
    {
        s = BaseView.convertToUnSign2(s);
        s = BaseView.repalce_UrlFriendly(s);
        return (s.ToLower());
    }
    private void getDataLQ(string idPost)
    {
        DBClass _db = new DBClass();

        string sqlData = "select * from BaiLQ where url_Post = '" + idPost + "'";
        //rpLQ.DataSource = _db.sqlGetData(sqlData);
        //rpLQ.DataBind();
    }
    private void getInfo()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {

            DBClass _db = new DBClass();
            string url = Request.QueryString["id"] + ".html";
            string[] urlShort = Request.QueryString["id"].Split('/');
            if (urlShort.Length > 0)
                url = urlShort[urlShort.Length - 1] + ".html";
            DataRow rowPost = _db.sqlGetDataRow("select * from News where url = '" + url + "'");
            //int countKey = 0;
            if (rowPost == null)
            {
                rowPost = _db.Get_URL_Pages(url);
            }
            if (rowPost != null)
            {
                string name = BaseView.GetStringFieldValue(rowPost, "tieude");
                string title = BaseView.GetStringFieldValue(rowPost, "title");
                string desc = BaseView.GetStringFieldValue(rowPost, "desc");
                string tomtat = BaseView.GetStringFieldValue(rowPost, "tomtat");
                string content = BaseView.GetStringFieldValue(rowPost, "noidung");
                string keywords = BaseView.GetStringFieldValue(rowPost, "keywords");
                int maloai = BaseView.GetIntFieldValue(rowPost, "maloai");

                Page.Title = title == "" ? BaseView.GetStringFieldValue(rowPost, "title") : title;
                Page.MetaDescription = desc;
                Page.MetaKeywords = keywords;
                string hinh = BaseView.GetStringFieldValue(rowPost, "hinhanh");
                hinh = hinh.IndexOf("http") == -1 ? BaseView.UrlServer() + "/UploadFile/postImages/" + BaseView.GetStringFieldValue(rowPost, "hinhanh") : hinh;
                ltImg.Text = "<meta property='og:image' content='" + hinh + "'>";
                ltTitle.Text = name;
                ltTitle2.Text = name;
                ltDescPost.Text = "<div class=''>" + tomtat + "</div>";
                ltContent.Text = content;
                getDataLQ(BaseView.GetStringFieldValue(rowPost, "id"));
                DateTime ngaydang = BaseView.GetDateTimeFieldValue(rowPost, "ngaydang");
                ltngaydang.Text = BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year;
                DataRow infoLoai = _db.get_info_loai(maloai);


                if (infoLoai != null)
                {
                    ltCat.Text = "<a itemprop='url' href='" + BaseView.GetStringFieldValue(infoLoai, "code").ToLower() + ".hxml'>" + BaseView.GetStringFieldValue(infoLoai, "name") + "</a>";
                    ltCattag.Text = "<a  href='" + BaseView.GetStringFieldValue(infoLoai, "code").ToLower() + ".hxml' rel='category tag'>" + BaseView.GetStringFieldValue(infoLoai, "name") + "</a>";

                    string hinhanh = BaseView.GetStringFieldValue(infoLoai, "Images").ToLower();
                    //if (hinhanh == "")
                    //    imgDanhMuc.Visible = false;
                    //else
                    //    imgDanhMuc.Visible = true;
                    //imgDanhMuc.ImageUrl = BaseView.UrlServer() + "/uploadFile/DanhMuc/" + hinhanh;
                    //imgDanhMuc.AlternateText = name;
                }
                //ltCat.Text = "<a itemprop='url' href='" + BaseView.GetStringFieldValue(rowPost, "code").ToLower() + ".hxml'>" + name + "</a>";

                BindRepeater(maloai);

                //btnSua.PostBackUrl = "~/EditPost/default.aspx?id=" + BaseView.GetStringFieldValue(rowPost, "id");
                //try
                //{
                string[] keywordArr = BaseView.GetStringFieldValue(rowPost, "keywords").Split(',');
                string tags = "";
                if (keywordArr.Length > 0)
                {
                    for (int i = 0; i < keywordArr.Length - 1; i++)
                    {
                        //lbTags.Text += i.ToString() + " ";
                        string[] ids = keywordArr[i].Split('-');
                        int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                        DataRow row = _db.get_info_words(idKey);
                        if (row != null)
                        {
                            tags += "<h6><a class='button small' itemprop='keywords' href='../tags/" + BaseView.GetStringFieldValue(row, "id") + "-" + convertStringLinks(BaseView.GetStringFieldValue(row, "keywords")) + "'>" + BaseView.GetStringFieldValue(row, "keywords") + "</a></h6>";
                        }

                    }
                }
                //lbTags.Text = tags;
                //}
                //catch { }


                //getLienQuan(BaseView.GetIntFieldValue(r, "maloai"));
                //getCamNangLienQuan(BaseView.GetIntFieldValue(r, "maloai"));
            }
            else
            {
                Response.Redirect("~/404/");
            }

        }
        if (Page.Title == "")
        {
            Page.Title = "Trang không tồn tại.";
        }

    }
    private void getPostWithCat(int id)
    {
        DBClass _db = new DBClass();

        //rpData.DataSource = _db.Get_All_News();
        //rpData.DataBind();
    }
    private DataRow getLoai()
    {
        try
        {
            DBClass _db = new DBClass();
            if (!String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string id = Request.QueryString["code"];
                return _db.sqlGetData("select * from LoaiTin where code = '" + id + "'").Rows[0];
            }
            return null;
        }
        catch { return null; }

    }
    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
            {
                return Convert.ToInt32(ViewState["PageNumber"]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState["PageNumber"] = value; }
    }
    private void BindRepeater(int id)
    {
        //Do your database connection stuff and get your data
        DBClass _db = new DBClass();

        //Create the PagedDataSource that will be used in paging
        PagedDataSource pgitems = new PagedDataSource();
        pgitems.DataSource = _db.Get_all_post_actived(id, true).DefaultView;
        pgitems.AllowPaging = true;

        //Control page size from here 
        pgitems.PageSize = 6;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            //rptPaging.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i <= pgitems.PageCount - 1; i++)
            {
                pages.Add((i + 1).ToString());
            }
            //rptPaging.DataSource = pages;
            //rptPaging.DataBind();
        }
        else
        {
            //rptPaging.Visible = false;
        }

        //Finally, set the datasource of the repeater
        //rpData.DataSource = _db.Get_All_News_IDLoai(id);
        //rpData.DataSource = pgitems;
        //rpData.DataBind();

    }

    //This method will fire when clicking on the page no link from the pager repeater
    protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        //ltPage.Text = (PageNumber + 1).ToString();
        BindRepeater(0);
    }
    protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    //protected void btnDH_Click(object sender, EventArgs e)
    //{

    //    if (txtFullname.Text.Trim() == "" || txtEmail.Text == "")
    //    {
    //        ltError.Text = "<span style='display:block;padding:5px;border-radius:5px; border:1px solid red;color:red;margin:10px'>Vui lòng điền đầy đủ thông tin!</span>";
    //    }
    //    else
    //    {
    //        DBClass _db = new DBClass();
    //        string subject = "Đăng ký Y Khoa Diamond";
    //        string body = "<br/>------------ Đăng ký Y Khoa Diamond ------------------";
    //        body += "<br/>Họ tên: " + txtFullname.Text;
    //        body += "<br/>Email: " + txtEmail.Text;
    //        body += "<br/>Nội dung: " + txtMsg.Text;
    //        _db.insert_update_comments(0, txtFullname.Text, txtEmail.Text, txtMsg.Text, getParent(), getPostID(), false, "insert");
    //        //MailDaemon.DatHen("dathen.diamond@gmail.com", subject, body);
    //        ltError.Text = "<span style='display:block;padding:5px;border-radius:5px; border:1px solid red;color:red;margin:10px'>Đã gửi phản hồi thành công, phản hồi của bạn sẽ được hiện thị sau khi được duyệt bởi ban quản trị!</span>";
    //        getComments();
    //    }
    //}
    private int getParent()
    {
        return 0;
    }
    //private void getComments()
    //{
    //    DBClass _db = new DBClass();
    //    RpComment.DataSource = _db.get_all_comments_width_post(getPostID(), true);
    //    RpComment.DataBind();
    //}
    private int getPostID()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {

            DBClass _db = new DBClass();
            string url = Request.QueryString["id"] + ".html";
            string[] urlShort = Request.QueryString["id"].Split('/');
            if (urlShort.Length > 0)
                url = urlShort[urlShort.Length - 1] + ".html";
            DataRow rowPost = _db.Get_Info_url(url);
            if (rowPost == null)
            {
                rowPost = _db.Get_URL_Pages(url);
            }
            if (rowPost != null)
            {
                return BaseView.GetIntFieldValue(rowPost, "id");
            }
        }
        return 0;
    }
    private string getSliderfoot(DataTable data)
    {
        string title = "", desc = "", url = "", img = "", html = "";
        int i = 0;
        DBClass _db = new DBClass();
        foreach (DataRow row in data.Rows)
        {
            i++;
            title = BaseView.GetStringFieldValue(row, "tieude");
            desc = BaseView.GetStringFieldValue(row, "tomtat");
            url = BaseView.GetStringFieldValue(row, "url");
            img = BaseView.GetStringFieldValue(row, "hinhanh");
            DateTime ngaydang = BaseView.GetDateTimeFieldValue(row, "ngaydang");
            if (i == 1)
            {
                html += "<li class='slider-item'>";
            }
            string tendanhmuc = "", urlloai = "";
            DataRow rowLoai = _db.get_info_loai(BaseView.GetIntFieldValue(row, "maloai"));
            if (rowLoai != null)
            {
                tendanhmuc = BaseView.GetStringFieldValue(rowLoai, "name");
                urlloai = BaseView.GetStringFieldValue(rowLoai, "code") + ".hxml";
            }
            html += "<article class='slide-item col-xs-6 col-md-4'>";
            html += "<div class='slide-content'>";
            html += "<div class='slide-data'>";
            html += "<div class='slide-data-outer'>";
            html += "<div class='slide-data-inner'>";
            html += "<a class='slide-link' href='" + url + "' title='" + title + "' rel='bookmark'></a>";
            html += "<span class='slide-category'>";
            html += "<a href='"+urlloai+"' title=''>"+tendanhmuc+"</a> </span>";
            html += "<span class='slide-date'>" + BaseView.getThang(ngaydang) + " " + ngaydang.Day + ", " + ngaydang.Year + "</span>";
            html += "<h4 class='slide-title'><a href='" + url + "' title='" + title + "' rel='bookmark'>" + title + "</a></h4>";
            html += "</div>";
            html += "</div>";
            html += " </div>";
            html += "<div class='slide-hover'></div>";
            html += "<div class='slide-image'>";
            html += "<span>";
            html += "<img alt='" + title + "' width='263' height='187' src='" + img + "'></span>";
            html += "</div>";
            html += "</div>";
            html += "</article>";

            if (i == 3)
            {
                html += "</li>";
                html += "<li class='slider-item'>";
            }

            if (i != 3 && i == data.Rows.Count)
            {
                html += "</li>";
            }
        }
        return html;
    }
}