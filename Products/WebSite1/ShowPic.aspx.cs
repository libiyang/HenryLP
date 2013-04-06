using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowPic : System.Web.UI.Page
{
    public string strImageHtml = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HenryLP.DAL.Products dalProducts = new HenryLP.DAL.Products();

            HenryLP.Model.Products model = dalProducts.GetModel(int.Parse(Request["id"].ToString()));
            if (!string.IsNullOrEmpty(model.pic))
            {
                string strPic = model.pic;
                string[] Pics = strPic.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < Pics.Length; i++)
                {
                    string pic = Pics[i];
                    string Image1 = "<img id='imgpic" + i + "' src='/PPic/" + pic + "'/>";
                    strImageHtml += "<br>" + Image1;
                }
            }
        }
        catch (Exception ex)
        { 
        }
    }
}
