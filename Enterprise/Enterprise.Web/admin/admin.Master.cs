using Enterprise.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.Web.admin
{
    public partial class product : System.Web.UI.MasterPage
    {
        public string mtitle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblname.Text = MD5.UrlDencode(Cookie.GetCookie(this.Page, "realname"));
            if (Session["realname"] == null)
            {
                Response.Write("<script>alert('您未登录,即将跳转至登录页面！');window.location.href ='/admin/LogIn.aspx'</script>");
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Cookie.RemoveCookie(this.Page);

            Response.Redirect("~/admin/LogIn.aspx");
            
        }
    }
}