using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_SalesFooter : System.Web.UI.Page
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
        Products2013.DAL.Products2013_SalesFooter dal = new Products2013.DAL.Products2013_SalesFooter();

        string strWhere = "";
        if (txtSCID.Text.Trim() != "")
        {
            strWhere = "SCID like '%" + txtSCID.Text.Trim() + "%'";
        }
        DataSet dsData = dal.GetList(strWhere);

        rpData.DataSource = dsData.Tables[0];
        rpData.DataBind();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        InitData();
    }

    public string GetImagesItem(string strPic)
    {
        string[] Pics = strPic.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        if (Pics.Length > 0)
        {
            string Img = "<br><img src=\"/PPic2013/SalesFooter/" + Pics[0] + "\" width=\"70px\" />";
            return Img;
        }
        return "";
    }
}
