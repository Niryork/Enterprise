using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Enterprise.Web.admin.api
{
    /// <summary>
    /// uploadImgApi 的摘要说明
    /// </summary>
    public class uploadImgApi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "UTF-8";

            var files = context.Request.Files;

            if (files.Count <= 0)
            {
                return;
            }
            HttpPostedFile file = files["UploadImg"];
            if (file == null)
            {
                context.Response.Write("error or file is full");
                return;
            }
            else
            {
 
                string path = context.Server.MapPath("/admin/images/uploadImg/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //get original file name
                string originfilename = file.FileName;
                //get extension name
                string fileExtension = Path.GetExtension(originfilename);
                //change filename by random number
                string currentFileName = (new Random()).Next() + fileExtension;

                //physical path in local machine
                string imgpath = path + currentFileName;
                //save image to local machine 
                file.SaveAs(imgpath);
                //write back url for browser
 
                string imgurl = "/admin/images/uploadImg/" + currentFileName;

                context.Response.Write(imgurl);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}