﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jufeng_ReportOrderDel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        int id = int.Parse(Request["id"].ToString());
        Products2013.DAL.Products2013_Order dal = new Products2013.DAL.Products2013_Order();
        dal.Delete(id);
        Response.Write("<script>window.close();</script>");
    }
}
