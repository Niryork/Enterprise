using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Model;
using Enterprise.BLL;

using Enterprise.Common;

namespace Enterprise.Web.admin.api
{
    public partial class productApi : System.Web.UI.Page
    {
        BLLProduct bll = new BLLProduct();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request.Params["op"] ?? "";
            string json = "";
            switch (op)
            {
                case "getproduct":
                    Product user = GetProduct();
                    json = JSONConvert.Object2Json<Product>(user);
                    break;
                default:
                    break;
            }



            Response.Write(json);
        }


        private Product GetProduct()
        {
            string id = Request.Form["id"] ?? "0";

            Product user = bll.GetProductId(id, out msg);
            if (user == null)
            {
                user = new Product();
            }
            return user;
        }
    }
}