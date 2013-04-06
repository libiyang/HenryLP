using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UploadFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            HttpPostedFile file = Request.Files["FileData"];

            if (file != null)
            {
                string mypath = Server.MapPath("/PPic/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/");
                if (!Directory.Exists(mypath))
                {
                    Directory.CreateDirectory(mypath);
                }
                string mypath2 = Server.MapPath("/PPicBIG/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/");
                if (!Directory.Exists(mypath2))
                {
                    Directory.CreateDirectory(mypath2);
                }
                string path = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));

                file.SaveAs(Server.MapPath("/PPicBIG/" + path)); 
                
                HenryLP.DAL.Common.Imaginator.SaveThumbnail(file.InputStream, Server.MapPath("/PPic/" + path), 150, 200);
                //Dragon.Common.Imaginator.MergerImg(Server.MapPath("/HousePicThum/" + path), Server.MapPath("/images/shuiyin.png"));

                Response.Write(path);
            }
            else
            {
                Response.Write("0");
            }
        }
        catch (Exception ex)
        {
            Response.Write("");
        }
    }
}
