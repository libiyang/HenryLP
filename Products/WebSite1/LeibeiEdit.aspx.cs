using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeibeiEdit : System.Web.UI.Page
{
    int Id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            Id = int.Parse(Request["id"].ToString());
        }
        if (!IsPostBack)
        {
            if (Id > 0)
            {
                HenryLP.DAL.Leibei dal = new HenryLP.DAL.Leibei();
                //判断是否删除操作
                if (Request["del"] != null)
                {
                    dal.Delete(Id);
                    Response.Write("<script>alert('操作成功');window.location='LeibeiList.aspx';</script>");
                    return;
                }

                HenryLP.Model.Leibei model = dal.GetModel(Id);
                txtName.Text = model.LeibeiName;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            HenryLP.DAL.Leibei dal = new HenryLP.DAL.Leibei();
            HenryLP.Model.Leibei model = new HenryLP.Model.Leibei();

            model.LeibeiName = txtName.Text;
            model.Id = Id;

            if (Id == 0)
            {
                dal.Add(model);
            }
            else
            {
                dal.Update(model);
            }

            Response.Write("操作成功");
            Response.Write("<script>alert('操作成功');window.location='LeibeiList.aspx';</script>");
        }
        catch (Exception ex)
        {
            Response.Write("出错了，" + ex.Message + "！");
        }
    }
}
