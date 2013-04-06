using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Jufeng_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Request["logout"] != null)
        {
            Session["LoginName"] = null;
            Session["LoginId"] = null;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Products2013.DAL.Products2013_Users dalUsers = new Products2013.DAL.Products2013_Users();
            DataSet ds = dalUsers.GetList("LoginName='" + txtLoginName.Text.Replace("'", "") + "' and [Password]='" + txtPassword.Text.Replace("'", "") + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //FormsAuthentication.SetAuthCookie(txtLoginName.Text, true);
                Session["LoginName"] = txtLoginName.Text;
                Session["LoginId"] = ds.Tables[0].Rows[0]["Id"].ToString();
                Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();

                dalUsers.UpdateLastLoginDate(int.Parse(ds.Tables[0].Rows[0]["Id"].ToString()));
                if (Session["UserType"].ToString() == "2")
                    Response.Redirect("Default.aspx");
                else
                    Response.Redirect("ProductList.aspx");
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误。');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("出错了：" + ex.Message);
        }
    }
}
