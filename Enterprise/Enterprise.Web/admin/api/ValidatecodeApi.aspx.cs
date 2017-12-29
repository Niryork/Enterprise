using Captchas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.Web.admin.api
{
    public partial class ValidatecodeApi : System.Web.UI.Page
    {
        string checkcode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int codelength = 4;
            Captcha cap = new Captcha();
            byte[] buffercode = cap.GetImage(codelength, out checkcode);
            Session["CheckCode"] = checkcode;
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(buffercode);
        }
    }
}