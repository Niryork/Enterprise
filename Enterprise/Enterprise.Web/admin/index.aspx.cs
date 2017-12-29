using Enterprise.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.Web.admin
{
    public partial class index : CommonWebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle("首页");
            lblName.Text = MD5.UrlDencode(Cookie.GetCookie(this.Page, "realname"));
        }
    }
}