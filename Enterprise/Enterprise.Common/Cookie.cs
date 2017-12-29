using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.UI;

namespace Enterprise.Common
{
    public class Cookie
    {

        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="ticks"></param>
        public static void AddCookie(Page page,string name, string value, long? ticks = null)
        {
            HttpCookie cookie = new HttpCookie(name, value);
            if (ticks != null)
            {
                TimeSpan ts = new TimeSpan(Convert.ToInt64(ticks));
                if (ts != null)
                {
                    cookie.Expires.Add(ts);
                }
            }
            //响应到客户端
            page.Response.Cookies.Add(cookie);
        }


        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="page"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetCookie(Page page, string name)
        {
            if (page.Request.Cookies[name] != null)
            {
                return page.Request.Cookies[name].Value;
            }

            return null;
        }


        public static void RemoveCookie(Page page) {
            page.Request.Cookies.Remove("userid");
            page.Request.Cookies.Remove("realname");
        }
    }
}
