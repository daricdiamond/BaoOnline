﻿using System;
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
        //if (!IsPostBack)
        //{
            getHeader();

        //}
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
}