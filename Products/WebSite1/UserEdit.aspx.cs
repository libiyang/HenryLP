using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserEdit : System.Web.UI.Page
{
    int userId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            userId = int.Parse(Request["id"].ToString());
        }
        if (!IsPostBack)
        {
            if (userId > 0)
            {
                HenryLP.DAL.Users dal = new HenryLP.DAL.Users();
                //判断是否删除操作
                if (Request["del"] != null)
                {
                    dal.Delete(userId);
                    Response.Write("<script>alert('操作成功');window.location='UserList.aspx';</script>");
                    return;
                }

                HenryLP.Model.Users model = dal.GetModel(userId);
                txtLoginName.Text = model.LoginName;
                txtName.Text = model.UserName;
                txtPassword.Text = model.Password;
                rbUserType.SelectedValue = model.UserType.ToString();
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            HenryLP.DAL.Users dal = new HenryLP.DAL.Users();
            HenryLP.Model.Users model = new HenryLP.Model.Users();

            model.UserType = int.Parse(rbUserType.SelectedValue);
            model.UserName = txtName.Text;
            model.Password = txtPassword.Text;
            model.LoginName = txtLoginName.Text;
            model.LastLoginDate = DateTime.Now;
            model.Id = userId;

            if (userId == 0)
            {
                dal.Add(model);
            }
            else
            {
                dal.Update(model);
            }

            Response.Write("操作成功");
            Response.Write("<script>alert('操作成功');window.location='UserList.aspx';</script>");
        }
        catch (Exception ex)
        {
            Response.Write("出错了，" + ex.Message + "！");
        }
    }
}
