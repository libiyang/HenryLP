using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }

    private void InitData()
    {
        Products2013.DAL.Products2013_Users dal = new Products2013.DAL.Products2013_Users();

        DataSet dsData = dal.GetList("");

        rpData.DataSource = dsData.Tables[0];
        rpData.DataBind();

    }
}
