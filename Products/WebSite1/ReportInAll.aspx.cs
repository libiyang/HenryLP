using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ReportInAll : System.Web.UI.Page
{
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
            DataSet dsAgent = bllUsers.GetList("id in(2,5)");
            foreach (DataRow row in dsAgent.Tables[0].Rows)
            {
                ddlAgent.Items.Add(new ListItem(row["UserName"].ToString(), row["UserName"].ToString()));
            }
            if (Session["UserType"].ToString() == "2")
            {
                ddlAgent.SelectedValue = Session["UserName"].ToString();
                if (Session["UserName"].ToString() == "小弟")
                {
                    ddlAgent.SelectedValue = "英冠";
                }
                ddlAgent.Enabled = false;
            }

            txtDate.Text = DateTime.Today.ToString("yyyy-MM-01");
            txtDate2.Text = DateTime.Parse(DateTime.Today.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1).ToString("yyyy-MM-dd");
            InitData();
        }
    }
    private void InitData()
    {
        HenryLP.DAL.ReportIn dalReportIn = new HenryLP.DAL.ReportIn();
        string strWhere = "";
        if (txtDate.Text.Trim() != "")
        {
            DateTime d = DateTime.Parse(txtDate.Text.Trim());
            DateTime d2 = DateTime.Parse(txtDate2.Text.Trim());
            strWhere = "ReportDate between '" + d.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd 23:5:59") + "'";
        }
        if (txtHuoHao.Text.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " ReportIn.HuoHao ='" + txtHuoHao.Text.Trim() + "'";
        }
        if (ddlLeibei.SelectedValue.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere = " ReportIn.leibei ='" + ddlLeibei.SelectedValue.Trim() + "'";
        }
        if (txtName.Text.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " ReportIn.ProductName like '%" + txtName.Text.Trim() + "%'";
        }
        if (ddlAgent.SelectedIndex > 0)
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " ReportIn.AgentName ='" + ddlAgent.SelectedValue.Trim() + "'";
        }
        DataSet dsData = dalReportIn.GetListWithProducts(strWhere);
        foreach (DataRow row in dsData.Tables[0].Rows)
        {
            TotalCount += (int)row["AmountIn"];
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
