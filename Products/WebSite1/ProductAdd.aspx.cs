using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProductAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            HenryLP.DAL.Users dal = new HenryLP.DAL.Users();
            DataSet ds = dal.GetList("UserType=2");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                cbAgent.Items.Add(new ListItem(row["UserName"].ToString(), row["Id"].ToString()));
            }
            HenryLP.DAL.Leibei bllLeibei = new HenryLP.DAL.Leibei();
            DataSet dsLeibei = bllLeibei.GetList("");
            foreach (DataRow row in dsLeibei.Tables[0].Rows)
            {
                ddlLeibei.Items.Add(new ListItem(row["leibeiName"].ToString(), row["leibeiName"].ToString()));
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            HenryLP.DAL.Products dalProduct = new HenryLP.DAL.Products();
            HenryLP.Model.Products product = new HenryLP.Model.Products();

            if (dalProduct.Exists(txtHuoHao.Text.Trim()))
            {
                Response.Write("<script>alert('该货号已经存在！');</script>");
                return;
            }
            product.Size = txtSize.Text.Trim();
            product.Remark = txtRemark.Text;

            foreach (ListItem item in cbAgent.Items)
            {
                if (item.Selected)
                {
                    product.Agent += "," + item.Text;
                    product.AgentIds += "," + item.Value;
                }
            }
            if (product.Agent.Length > 1)
                product.Agent = product.Agent.Substring(1);
            if (product.AgentIds.Length > 1)
                product.AgentIds = product.AgentIds.Substring(1);

            product.ProductName = txtProductName.Text;

            try
            {
                product.PriceSell = decimal.Parse(txtPriceSell.Text.Trim());
            }
            catch
            { }
            try
            {
                product.Weight = decimal.Parse(txtWeight.Text.Trim());
            }
            catch
            { }
            try
            {
                product.PriceFactory = decimal.Parse(txtPriceFactory.Text.Trim());
            }
            catch
            { }
            product.LeiBei = ddlLeibei.SelectedValue;

            product.HuoHao = txtHuoHao.Text;
            try
            {
                product.AmountKc = int.Parse(txtAmountKc.Text);
            }
            catch
            { }
            try
            {
                product.AmountOut = int.Parse(txtAmountOut.Text);
            }
            catch
            { }
            if (product.AmountOut > 0)
            {//这里"出库数量"每次默认都是0，当填写数字时，那么库存数，每次都是自动减去"出库数量"
                product.AmountKc -= product.AmountOut;
            }
            try
            {//英冠库存
                product.AmountXM = int.Parse(txtAmountXM.Text);
            }
            catch
            { }
            try
            {//黄总库存
                product.AmountHZ = int.Parse(txtAmountHZ.Text);
            }
            catch
            { }
            string himage1 = Request["himage1"];
            if (himage1 != null)
            {
                product.pic = himage1;
            }
            product.UpdateOn = DateTime.Now;
            dalProduct.Add(product);
            Response.Write("<script>alert('操作成功');window.location='ProductList.aspx';</script>");
        }
        catch (Exception ex)
        {
            Response.Write("错误：" + ex.Message);
            Response.Write("<script language='javascript'>window.alert('" + ex.Message + "');</script>");
        }
    }
}
