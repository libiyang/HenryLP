using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_ToOrder : System.Web.UI.Page
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

            int pId = int.Parse(Request["id"].ToString());
            Products2013.DAL.Products2013_Products dalProducts = new Products2013.DAL.Products2013_Products();
            Products2013.Model.Products2013_Products product = dalProducts.GetModel(pId);
            txtPriceSell.Text = product.PriceSell.ToString();
            lblName.Text = product.ProductName;
            lblHuoHao.Text = product.HuoHao;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pId = int.Parse(Request["id"].ToString());
            Products2013.DAL.Products2013_Products dalProducts = new Products2013.DAL.Products2013_Products();
            Products2013.Model.Products2013_Products product = dalProducts.GetModel(pId);
            if (product == null)
            {
                Response.Write("出错了，该产品不存在！");
                return;
            }

            Products2013.DAL.Products2013_Order dalOrder = new Products2013.DAL.Products2013_Order();
            Products2013.Model.Products2013_Order reportOut = new Products2013.Model.Products2013_Order();
            DateTime OrderDate = DateTime.Now;

            reportOut.OrderAmount = int.Parse(txtAmount.Text);
            reportOut.PriceSell = decimal.Parse(txtPriceSell.Text.Trim());
            reportOut.AmountFee = reportOut.PriceSell * reportOut.OrderAmount;
            reportOut.HuoHao = product.HuoHao;
            reportOut.ProductName = product.ProductName;
            reportOut.LeiBei = product.LeiBei;
            reportOut.pic = product.pic;
            reportOut.ProductId = pId;
            reportOut.OrderDate = OrderDate;
            reportOut.remark = txtRemark.Text;
            reportOut.AgentId = int.Parse(Session["LoginId"].ToString());
            reportOut.AgentName = (string)Session["UserName"];
            dalOrder.Add(reportOut);

            Response.Write("操作成功");
            Response.Write("<script>alert('操作成功');window.close();</script>");
        }
        catch (Exception ex)
        {
            Response.Write("出错了，" + ex.Message + "！");
        }
    }
}
