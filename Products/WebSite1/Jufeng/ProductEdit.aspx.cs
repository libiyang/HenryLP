using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_ProductEdit : System.Web.UI.Page
{
    public int id = 0;
    public string strImageHtml = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginName"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        id = int.Parse(Request["id"].ToString());
        if (!IsPostBack)
        {
            Products2013.DAL.Products2013_Leibei bllLeibei = new Products2013.DAL.Products2013_Leibei();
            DataSet dsLeibei = bllLeibei.GetList("");
            foreach (DataRow row in dsLeibei.Tables[0].Rows)
            {
                ddlLeibei.Items.Add(new ListItem(row["leibeiName"].ToString(), row["leibeiName"].ToString()));
            }
            if (id > 0)
            {
                Products2013.DAL.Products2013_Products dalProduct = new Products2013.DAL.Products2013_Products();
                Products2013.Model.Products2013_Products model = dalProduct.GetModel(id);

                txtHuoHao.Text = model.HuoHao;
                ddlLeibei.Text = model.LeiBei;
                txtProductName.Text = model.ProductName;
                txtPriceFactory.Text = model.PriceFactory.ToString();
                txtPriceSell.Text = model.PriceSell.ToString();
                txtSize.Text = model.Size;

                string strPic = model.pic;
                string[] Pics = strPic.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < Pics.Length; i++)
                {
                    string pic = Pics[i];
                    string Image1 = "<img id='imgpic" + i + "' width='216px' src='/PPic2013/" + pic + "'/>";
                    string Delete1 = "<a href='javascript:void(0);' onclick=\"javascript:removeDiv('pic" + i + "')\">刪除</a>";
                    string Div1 = "<div id='divpic" + i + "' style='margin-top:5px;text-align:center;width:130px;'>" + Delete1 + "<input type='hidden' name='himage1' value='" + pic + "'/></div>";
                    strImageHtml += "<br>" + Image1 + Div1;
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Products2013.DAL.Products2013_Products dalProduct = new Products2013.DAL.Products2013_Products();
            Products2013.Model.Products2013_Products product = new Products2013.Model.Products2013_Products();
            product.Id = id;

            product.LeiBei = ddlLeibei.SelectedValue;
            product.HuoHao = txtHuoHao.Text;
            product.ProductName = txtProductName.Text;
            product.Size = txtSize.Text.Trim();

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

            string himage1 = Request["himage1"];
            if (himage1 != null)
            {
                product.pic = himage1;
            }
            product.UpdateOn = DateTime.Now;
            dalProduct.Update(product);
            Response.Write("<script>alert('操作成功');window.location='ProductList.aspx';</script>");
        }
        catch (Exception ex)
        {
            Response.Write("错误：" + ex.Message);
            Response.Write("<script language='javascript'>window.alert('" + ex.Message + "');</script>");
        }
    }
}
