﻿using System;
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

public partial class ReportOut2 : System.Web.UI.Page
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
            HenryLP.DAL.Products dalProducts = new HenryLP.DAL.Products();
            HenryLP.Model.Products product = dalProducts.GetModel(pId);
            txtPriceSell.Text = product.PriceSell.ToString();
            lblName.Text = product.ProductName;
            lblHuoHao.Text = product.HuoHao;
            
            HenryLP.DAL.Users dal = new HenryLP.DAL.Users();
            DataSet ds = dal.GetList("Id =" + Session["LoginId"].ToString() + "");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(row["UserName"].ToString(), row["Id"].ToString());
                item.Selected = true;
                cbAgent.Items.Add(item);
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pId = int.Parse(Request["id"].ToString());
            HenryLP.DAL.Products dalProducts = new HenryLP.DAL.Products();
            HenryLP.Model.Products product = dalProducts.GetModel(pId);
            if (product == null)
            {
                Response.Write("出错了，该产品不存在！");
                return;
            }
            HenryLP.DAL.ReportOut dalReportOut = new HenryLP.DAL.ReportOut();
            DateTime ReportDate = DateTime.Now; 

            HenryLP.Model.ReportOut reportOut = new HenryLP.Model.ReportOut();
            
            reportOut.AmountOut = int.Parse(txtAmount.Text);
            reportOut.PriceSell = decimal.Parse(txtPriceSell.Text.Trim());
            reportOut.AmountFee = reportOut.PriceSell * reportOut.AmountOut;
            reportOut.HuoHao = product.HuoHao;
            reportOut.ProductName = product.ProductName;
            reportOut.LeiBei = product.LeiBei;
            reportOut.ProductId = pId;
            reportOut.ReportDate = ReportDate;
            reportOut.Remark = txtRemark.Text;

            foreach (ListItem item in cbAgent.Items)
            {
                if (item.Selected)
                {
                    reportOut.AgentId = int.Parse(item.Value);
                    reportOut.AgentName = item.Text;

                    dalReportOut.Add(reportOut);
                    if (reportOut.AgentId == 2)
                    { //黄总出库
                        product.AmountHZ -= reportOut.AmountOut;
                        dalProducts.UpdateAmountHZ(product);
                    }
                    else if (reportOut.AgentId == 4 || reportOut.AgentId == 5)
                    {//英冠出库
                        product.AmountXM -= reportOut.AmountOut;
                        dalProducts.UpdateAmountXM(product);
                    }
                }
            }

            //dalProducts.UpdateAmountOut(product);

            Response.Write("操作成功");
            Response.Write("<script>alert('操作成功');window.close();</script>");
        }
        catch (Exception ex)
        {
            Response.Write("出错了，" + ex.Message + "！");
        }
    }
}
