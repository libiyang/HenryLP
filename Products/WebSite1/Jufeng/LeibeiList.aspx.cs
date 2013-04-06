using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_LeibeiList : System.Web.UI.Page
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
        Products2013.DAL.Products2013_Leibei dal = new Products2013.DAL.Products2013_Leibei();

        DataSet dsData = dal.GetList("");

        rpData.DataSource = dsData.Tables[0];
        rpData.DataBind();

    }
}
