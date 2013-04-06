using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ReportOutEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null || Session["UserType"] == null || Session["LoginId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            txtAmount.Text = "0";

            int oId = int.Parse(Request["id"].ToString());
            HenryLP.DAL.ReportOut bllOut = new HenryLP.DAL.ReportOut();
            HenryLP.Model.ReportOut model = bllOut.GetModel(oId);
            lblName.Text = model.ProductName;
            txtAmount.Text = model.AmountOut.ToString();
            txtPriceSell.Text = model.PriceSell.ToString();
            txtRemark.Text = model.Remark;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int oId = int.Parse(Request["id"].ToString());

            HenryLP.DAL.ReportOut bllOut = new HenryLP.DAL.ReportOut();
            HenryLP.Model.ReportOut reportOut = bllOut.GetModel(oId);
            if (reportOut == null)
                return;

            reportOut.AmountOut = int.Parse(txtAmount.Text);
            reportOut.PriceSell = decimal.Parse(txtPriceSell.Text.Trim());
            reportOut.AmountFee = reportOut.PriceSell * reportOut.AmountOut;
            reportOut.Remark = txtRemark.Text;
            bllOut.Update(reportOut);

            Response.Write("操作成功");
            Response.Write("<script>alert('操作成功');window.close();</script>");
        }
        catch (Exception ex)
        {
            Response.Write("出错了，" + ex.Message + "！");
        }
    }
}
