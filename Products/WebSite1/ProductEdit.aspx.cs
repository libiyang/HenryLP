using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HenryLP;
using System.Data;

public partial class ProductEdit : System.Web.UI.Page
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
            HenryLP.DAL.Leibei bllLeibei = new HenryLP.DAL.Leibei();
            DataSet dsLeibei = bllLeibei.GetList("");
            foreach (DataRow row in dsLeibei.Tables[0].Rows)
            {
                ddlLeibei.Items.Add(new ListItem(row["leibeiName"].ToString(), row["leibeiName"].ToString()));
            }
            if (id > 0)
            {
                HenryLP.DAL.Products dalProduct = new HenryLP.DAL.Products();
                HenryLP.Model.Products model = dalProduct.GetModel(id);
                txtAmountKc.Text = model.AmountKc.ToString();

                txtAmountOut.Text = "0";// model.AmountOut.ToString();
                txtHuoHao.Text = model.HuoHao;
                //txtLeibei.Text = model.LeiBei;
                ddlLeibei.Text = model.LeiBei;
                txtProductName.Text = model.ProductName;
                txtPriceFactory.Text = model.PriceFactory.ToString();
                txtPriceSell.Text = model.PriceSell.ToString();
                txtRemark.Text = model.Remark;
                txtSize.Text = model.Size;
                txtWeight.Text = model.Weight.ToString();
                txtAmountXM.Text = model.AmountXM.ToString();
                txtAmountHZ.Text = model.AmountHZ.ToString();

                HenryLP.DAL.Users dal = new HenryLP.DAL.Users();
                DataSet ds = dal.GetList("UserType=2");
                foreach (DataRow row in ds.Tables[0].Rows)
                {//txtAgent.Text = model.Agent;
                    ListItem item = new ListItem(row["UserName"].ToString(), row["Id"].ToString());
                    if (("," + model.AgentIds + ",").IndexOf("," + row["Id"].ToString() + ",") > -1)
                        item.Selected = true;
                    cbAgent.Items.Add(item);
                }

                string strPic = model.pic;
                string[] Pics = strPic.Split(new string[]{","},StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < Pics.Length; i++)
                {
                    string pic = Pics[i];
                    string Image1 = "<img id='imgpic" + i + "' width='216px' src='/PPic/" + pic + "'/>";
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
            HenryLP.DAL.Products dalProduct = new HenryLP.DAL.Products();
            HenryLP.Model.Products product = new HenryLP.Model.Products();
            product.Id = id;

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
            if(product.Agent.Length>1)
                product.Agent = product.Agent.Substring(1);
            if (product.AgentIds.Length > 1)
                product.AgentIds = product.AgentIds.Substring(1);
            try
            {
                product.PriceSell = decimal.Parse(txtPriceSell.Text.Trim());
            }
            catch
            { }
            try
            {
                product.PriceFactory = decimal.Parse(txtPriceFactory.Text.Trim());
            }
            catch
            { }
            try
            {
                product.Weight = decimal.Parse(txtWeight.Text.Trim());
            }
            catch
            { }
            product.LeiBei = ddlLeibei.SelectedValue;

            product.HuoHao = txtHuoHao.Text;
            product.ProductName = txtProductName.Text;
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
            {
                product.AmountXM = int.Parse(txtAmountXM.Text);
            }
            catch
            { }
            try
            {
                int AmountXM_In = int.Parse(txtAmountXM_In.Text);
                if (AmountXM_In > 0)
                { //厦门入库
                    product.AmountXM += AmountXM_In;
                    //添加到入库记录表
                    HenryLP.Model.ReportIn mdlReportIn = new HenryLP.Model.ReportIn();
                    mdlReportIn.AgentId = 5;
                    mdlReportIn.AgentName = "英冠";
                    mdlReportIn.AmountIn = AmountXM_In;
                    mdlReportIn.HuoHao = product.HuoHao;
                    mdlReportIn.LeiBei = product.LeiBei;
                    mdlReportIn.ProductId = product.Id;
                    mdlReportIn.ProductName = product.ProductName;
                    mdlReportIn.Remark = "";
                    mdlReportIn.ReportDate = DateTime.Today;

                    HenryLP.DAL.ReportIn bllReportIn = new HenryLP.DAL.ReportIn();
                    bllReportIn.Add(mdlReportIn);
                }
            }
            catch
            { }
            try
            {
                product.AmountHZ = int.Parse(txtAmountHZ.Text);
            }
            catch
            { }
            try
            {
                int AmountHZ_In = int.Parse(txtAmountHZ_In.Text);
                if (AmountHZ_In > 0)
                { //黄总入库
                    product.AmountHZ += AmountHZ_In;
                    //添加到入库记录表
                    HenryLP.Model.ReportIn mdlReportIn = new HenryLP.Model.ReportIn();
                    mdlReportIn.AgentId = 2;
                    mdlReportIn.AgentName = "欣迪";
                    mdlReportIn.AmountIn = AmountHZ_In;
                    mdlReportIn.HuoHao = product.HuoHao;
                    mdlReportIn.LeiBei = product.LeiBei;
                    mdlReportIn.ProductId = product.Id;
                    mdlReportIn.ProductName = product.ProductName;
                    mdlReportIn.Remark = "";
                    mdlReportIn.ReportDate = DateTime.Today;

                    HenryLP.DAL.ReportIn bllReportIn = new HenryLP.DAL.ReportIn();
                    bllReportIn.Add(mdlReportIn);
                }
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
