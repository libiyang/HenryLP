using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_ReportOrderStat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null || Session["LoginId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Today.ToString("yyyy-MM-01");
            txtDate2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            InitData();
        }
    }
    private void InitData()
    {
        Products2013.DAL.Products2013_Order dalOrder = new Products2013.DAL.Products2013_Order();
        string strWhere = @"select AgentId,max(AgentName)AgentName,ProductId,max(ProductName) ProductName,max(HuoHao)HuoHao,sum(OrderAmount) OrderAmount,max(pic) pic from dbo.Products2013_Order";
        if (txtDate.Text.Trim() != "")
        {
            DateTime d = DateTime.Parse(txtDate.Text.Trim());
            DateTime d2 = DateTime.Parse(txtDate2.Text.Trim());
            strWhere += " where OrderDate between '" + d.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd 23:5:59") + "'";
        }
        strWhere += " group by AgentId,ProductId";

        DataSet dsData = dalOrder.Query(strWhere);
        
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
            string Img = "<br><img src=\"/PPic2013/" + Pics[0] + "\" width=\"70px\" />";
            return Img;
        }
        return "";
    }
}
