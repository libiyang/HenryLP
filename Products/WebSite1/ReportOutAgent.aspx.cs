using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ReportOutAll : System.Web.UI.Page
{
    public decimal TotalFee = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null || Session["LoginId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            InitData();
        }
    }
    private void InitData()
    {
        HenryLP.DAL.ReportOut dalReportOut = new HenryLP.DAL.ReportOut();
        string strWhere = "";
        if (txtDate.Text.Trim() != "")
        {
            DateTime d = DateTime.Parse(txtDate.Text.Trim());
            strWhere = "ReportDate between '" + d.ToString("yyyy-MM-dd") + "' and '" + d.ToString("yyyy-MM-dd 23:5:59") + "' and ReportOut.AgentId=" + Session["LoginId"].ToString();
        }

        DataSet dsData = dalReportOut.GetListWithProducts(strWhere);
        foreach (DataRow row in dsData.Tables[0].Rows)
        {
            TotalFee += (decimal)row["AmountFee"];
        }
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
            string Img = "<br><img src=\"/PPic/" + Pics[0] + "\" width=\"70px\" />";
            return Img;
        }
        return "";
    }
}
