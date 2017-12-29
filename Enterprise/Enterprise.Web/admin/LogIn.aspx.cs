using Enterprise.BLL;
using Enterprise.Common;
using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.Web.admin
{
    public partial class LogIn : System.Web.UI.Page
    {
        BLLUserInfo bll = new BLLUserInfo();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string origincode = Convert.ToString(Session["CheckCode"]);
            TextBox CheckCode = login.FindControl("CheckCode") as TextBox;
            if (CheckCode.Text.Trim().ToLower() == origincode.ToLower())
            {
                e.Authenticated = true;
                BindLogin(login.UserName, login.Password);
            }
            else
            {
                e.Authenticated = false;
            }
        }

        private void BindLogin(string account, string pwd)
        {
            UserInfo user = new UserInfo()
            {
                Username = account,
                Password = MD5.Encryption(pwd)
            };

            UserInfo userinfo = bll.GetUserInfo(user, out msg);
            if (!string.IsNullOrEmpty(msg))
            {
                PageScript.Alert(this.Page, msg);
                return;
            }

            if (userinfo != null)
            {
                Cookie.AddCookie(this.Page, "userid", userinfo.UserId.ToString());
                Cookie.AddCookie(this.Page, "realname", MD5.UrlEncode(userinfo.RealName));
                Session["realname"] = MD5.UrlEncode(userinfo.RealName);
                PageScript.Alert(this.Page, "登录成功");
                Response.Redirect("~/admin/Index.aspx");
            }
            else
            {
                PageScript.Alert(this.Page, "登录失败");
            }
        }


        protected void login_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            string origincode = Convert.ToString(Session["CheckCode"]);
            TextBox CheckCode = login.FindControl("CheckCode") as TextBox;
            if (CheckCode.Text.Trim().ToLower() == origincode.ToLower())
            {
                e.Cancel = false;
                BindLogin(login.UserName, login.Password);
            }
            else
            {
                e.Cancel = true;
            }
        }

        protected void login_LoggedIn(object sender, EventArgs e)
        {
            BindLogin(login.UserName, login.Password);
        }

        protected void login_LoginError(object sender, EventArgs e)
        {
            Response.Write("<script>alert('验证失败')</script>");
        }



    }
}