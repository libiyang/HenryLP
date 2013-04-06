using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ReportOutDate : System.Web.UI.Page
{
    public decimal TotalFee = 0;
    public int TotalCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            ddlLeibei.Items.Add(new ListItem("所有类别", ""));
            HenryLP.DAL.Leibei bllLeibei = new HenryLP.DAL.Leibei();
            DataSet dsLeibei = bllLeibei.GetList("");
            foreach (DataRow row in dsLeibei.Tables[0].Rows)
            {
                ddlLeibei.Items.Add(new ListItem(row["leibeiName"].ToString(), row["leibeiName"].ToString()));
            }

            ddlAgent.Items.Add(new ListItem("所有代理", ""));
            HenryLP.DAL.Users bllUsers = new HenryLP.DAL.Users();
            DataSet dsAgent = bllUsers.GetList("");
            foreach (DataRow row in dsAgent.Tables[0].Rows)
            {
                ddlAgent.Items.Add(new ListItem(row["UserName"].ToString(), row["UserName"].ToString()));
            }

            if (Session["UserType"].ToString() == "2")
            {
                ddlAgent.SelectedValue = Session["UserName"].ToString();
                ddlAgent.Enabled = false;
            }

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
            strWhere = "ReportDate between '" + d.ToString("yyyy-MM-dd") + "' and '" + d.ToString("yyyy-MM-dd 23:5:59") + "'";
        }
        if (txtHuoHao.Text.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " ReportOut.HuoHao ='" + txtHuoHao.Text.Trim() + "'";
        }
        if (ddlLeibei.SelectedValue.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere = " ReportOut.leibei ='" + ddlLeibei.SelectedValue.Trim() + "'";
        }
        if (txtName.Text.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " ReportOut.ProductName like '%" + txtName.Text.Trim() + "%'";
        }
        if (ddlAgent.SelectedIndex > 0)
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " ReportOut.AgentName ='" + ddlAgent.SelectedValue.Trim() + "'";
        }
        DataSet dsData = dalReportOut.GetListWithProducts(strWhere);
        foreach (DataRow row in dsData.Tables[0].Rows)
        {
            TotalFee += (decimal)row["AmountFee"];
            TotalCount += (int)row["AmountOut"];
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
