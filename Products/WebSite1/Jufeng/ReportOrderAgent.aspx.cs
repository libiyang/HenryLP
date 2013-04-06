using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_ReportOrderAgent : System.Web.UI.Page
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

            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtDate2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            InitData();
        }
    }
    private void InitData()
    {
        Products2013.DAL.Products2013_Order dalOrder = new Products2013.DAL.Products2013_Order();
        string strWhere = "AgentId=" + Session["LoginId"].ToString();
        if (txtDate.Text.Trim() != "")
        {
            DateTime d = DateTime.Parse(txtDate.Text.Trim());
            DateTime d2 = DateTime.Parse(txtDate2.Text.Trim());
            if (strWhere != "")
                strWhere += " and ";
            strWhere = "OrderDate between '" + d.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd 23:5:59") + "'" ;
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

        DataSet dsData = dalOrder.GetList(strWhere);
        foreach (DataRow row in dsData.Tables[0].Rows)
        {
            //row["PriceSell"] = (decimal)row["PriceSell"] * 6.6m;
            //row["AmountFee"] = (decimal)row["AmountFee"] * 6.6m;
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
