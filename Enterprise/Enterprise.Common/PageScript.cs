using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Enterprise.Common
{
    public class PageScript
    {
        public static void Alert(Page page, string content)
        {
            page.Response.Write("<script>alert('" + content + "')</script>");
        }

        public static void BackTo(Page page, string url) {
            page.Response.Write("<script>window.location.href = '" + url + "'</script>");
        }
    }
}
