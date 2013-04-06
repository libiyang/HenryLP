using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jufeng_HeadControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null || Session["LoginId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
