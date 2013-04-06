using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UploadFilesSalesFooter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpPostedFile file = Request.Files["FileData"];

            if (file != null)
            {
                string mypath = Server.MapPath("/PPic2013/SalesFooter/");
                if (!Directory.Exists(mypath))
                {
                    Directory.CreateDirectory(mypath);
                }
                
                string path = file.FileName;

                file.SaveAs(Server.MapPath("/PPic2013BIG/SalesFooter/" + path));
                HenryLP.DAL.Common.Imaginator.SaveThumbnail(file.InputStream, Server.MapPath("/PPic2013/SalesFooter/" + path), 150, 200);

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
