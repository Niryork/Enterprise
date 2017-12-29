using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Enterprise.Common;
using Enterprise.Model;
using Enterprise.BLL;

namespace Enterprise.Web.admin
{
    public class CommonWebPage : System.Web.UI.Page
    {
        /// <summary>
        /// 检查是否登录
        /// </summary>
        /// <returns></returns>
        public bool CheckLogin()
        {
            if (Cookie.GetCookie(this.Page, "userid") != null)
            {
                int userid = Convert.ToInt32(Cookie.GetCookie(this.Page, "userid"));
                if (userid > 0)
                {
                    return true;
                }
            }

            return false;

        }


        public void SetTitle(string title)
        {
            //给模板页中的属性赋值
            this.Master.GetType().GetProperty("mtitle").SetValue(this.Master, title, null);
        }



    }
}