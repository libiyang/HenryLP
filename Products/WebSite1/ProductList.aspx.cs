using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Wuqi.Webdiyer;

public partial class ProductList : System.Web.UI.Page
{
    public decimal TotalFee = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null || Session["UserType"] == null || Session["UserType"].ToString() == "2")
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
            if (Request["leibei"] != null)
            {
                ddlLeibei.Text = Request["leibei"];
            }
            InitData(1);
        }
    }
    private void InitData(int pageIndex)
    {
        HenryLP.DAL.Products dalProducts = new HenryLP.DAL.Products();
        string strWhere = "";
        if (txtHuoHao.Text.Trim() != "")
        { 
            strWhere = "huohao like '%" + txtHuoHao.Text.Trim() + "%'";
        }
        if (txtName.Text.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere = " ProductName like '%" + txtName.Text.Trim() + "%'";
        }
        if (ddlLeibei.SelectedValue.Trim() != "")
        {
            if (strWhere != "")
                strWhere += " and ";
            strWhere = " leibei ='" + ddlLeibei.SelectedValue.Trim() + "'";
        }

        DataSet dsData = dalProducts.GetList(strWhere);

        foreach (DataRow row in dsData.Tables[0].Rows)
        {
            TotalFee += (decimal)row["PriceFactory"] * (int)row["AmountOut"];
        }

        int total = dsData.Tables[0].Rows.Count;
        int pageSize = 50;

        System.Web.UI.WebControls.PagedDataSource ps = new PagedDataSource();//实例化分页数据源
        ps.DataSource = dsData.Tables[0].DefaultView;//将要绑定在datalist上的datatable给分页数据源
        ps.AllowPaging = true;
        ps.PageSize = pageSize;//每页显示几条记录
        ps.CurrentPageIndex = pageIndex - 1;//设置当前页的索引(当前页码减1就是)

        rpData.DataSource = ps;
        rpData.DataBind();

        AspNetPager1.PageSize = pageSize;
        AspNetPager1.RecordCount = total;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        InitData(1);
    }
    protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
    {
        InitData(e.NewPageIndex);
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
