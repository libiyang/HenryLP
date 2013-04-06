using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_ReportOrder : System.Web.UI.Page
{
    public decimal TotalFee = 0;
    public int TotalCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null || Session["LoginId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            ddlLeibei.Items.Add(new ListItem("所有类别", ""));
            Products2013.DAL.Products2013_Leibei bllLeibei = new Products2013.DAL.Products2013_Leibei();
            DataSet dsLeibei = bllLeibei.GetList("");
            foreach (DataRow row in dsLeibei.Tables[0].Rows)
            {
                ddlLeibei.Items.Add(new ListItem(row["leibeiName"].ToString(), row["leibeiName"].ToString()));
            }

            ddlAgent.Items.Add(new ListItem("所有代理", ""));
            Products2013.DAL.Products2013_Users bllUsers = new Products2013.DAL.Products2013_Users();
            DataSet dsAgent = bllUsers.GetList("");
            foreach (DataRow row in dsAgent.Tables[0].Rows)
            {
                ddlAgent.Items.Add(new ListItem(row["UserName"].ToString(), row["Id"].ToString()));
            }
            if (Session["UserType"].ToString() == "2")
            {
                ddlAgent.SelectedValue = Session["UserName"].ToString();
                ddlAgent.Enabled = false;
            }

            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtDate2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            InitData();
        }
    }
    private void InitData()
    {
        Products2013.DAL.Products2013_Order dalOrder = new Products2013.DAL.Products2013_Order();
        string strWhere = "";
        if (txtDate.Text.Trim() != "")
        {
            DateTime d = DateTime.Parse(txtDate.Text.Trim());
            DateTime d2 = DateTime.Parse(txtDate2.Text.Trim());
            strWhere = "OrderDate between '" + d.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd 23:5:59") + "'";
        }
        if (txtHuoHao.Text.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " HuoHao ='" + txtHuoHao.Text.Trim() + "'";
        }
        if (ddlLeibei.SelectedValue.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere = " leibei ='" + ddlLeibei.SelectedValue.Trim() + "'";
        }
        if (txtName.Text.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " ProductName like '%" + txtName.Text.Trim() + "%'";
        }
        if (ddlAgent.SelectedIndex > 0)
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere += " AgentId =" + ddlAgent.SelectedValue.Trim();
        }

        DataSet dsData = dalOrder.GetList(strWhere);
        foreach (DataRow row in dsData.Tables[0].Rows)
        {
            TotalFee += (decimal)row["AmountFee"];
            TotalCount += (int)row["OrderAmount"];
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
            string Img = "<br><img src=\"/PPic2013/" + Pics[0] + "\" width=\"70px\" />";
            return Img;
        }
        return "";
    }
}
