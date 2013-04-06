using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_ProductAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            Products2013.DAL.Products2013_Leibei bllLeibei = new Products2013.DAL.Products2013_Leibei();
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
            Products2013.DAL.Products2013_Products dalProduct = new Products2013.DAL.Products2013_Products();
            Products2013.Model.Products2013_Products product = new Products2013.Model.Products2013_Products();

            if (dalProduct.Exists(txtHuoHao.Text.Trim()))
            {
                Response.Write("<script>alert('该货号已经存在！');</script>");
                return;
            }
            product.Size = txtSize.Text.Trim();
            
            product.ProductName = txtProductName.Text;

            
            try
            {
                product.PriceFactory = decimal.Parse(txtPriceFactory.Text.Trim());
            }
            catch
            { }
            try
            {
                product.PriceSell = product.PriceFactory * 6.6m * 1.2m * 3.5m;
            }
            catch
            { }
            product.LeiBei = ddlLeibei.SelectedValue;

            product.HuoHao = txtHuoHao.Text;
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
