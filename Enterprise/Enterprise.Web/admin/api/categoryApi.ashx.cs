using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Enterprise.BLL;
using Enterprise.Common;
using Enterprise.Model;

namespace Enterprise.Web.admin.api
{
    /// <summary>
    /// categoryApi 的摘要说明
    /// </summary>
    public class categoryApi : IHttpHandler
    {
        BLLCategory bll = new BLLCategory();
        string msg;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            List<Category> list = bll.GetProductCategoryTree(out msg);

            string json = "";
            if (list != null)
            {
                 json = JSONConvert.Object2Json<List<Category>>(list);
            }

            context.Response.Write(json);



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