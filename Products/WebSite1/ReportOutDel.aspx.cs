using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportOutDel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        int id = int.Parse(Request["id"].ToString());
        HenryLP.DAL.ReportOut dal = new HenryLP.DAL.ReportOut();
        dal.Delete(id);
        Response.Write("<script>window.close();</script>");
    }
}
