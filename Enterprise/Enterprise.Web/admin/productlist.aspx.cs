using Enterprise.BLL;
using Enterprise.Common;
using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Enterprise.Web.admin
{
    public partial class productlist : CommonWebPage
    {
        BLLProduct bll = new BLLProduct();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle("产品管理");
            if (!IsPostBack)
            {
                BindData();
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        /// 
        private void BindData()
        {
            int count;
            string strWh = "";

            V_Product user = new V_Product();

            List<V_Product> list = bll.GetProductList(pageProduct.CurrentPageIndex, pageProduct.PageSize, strWh, out count, out msg);
            if (!string.IsNullOrEmpty(msg))
            {
                PageScript.Alert(this.Page, msg);
                return;
            }

            pageProduct.RecordCount = count;

            foreach (V_Product item in list)
            {
                item.StatusName = item.Status == 1 ? "显示" : "不显示";
                item.CreateUser = item.CreateUserId == 1 ? "admin" : "other";
                item.UpdateUser = item.UpdateUserId == 1 ? "admin" : "other";
            }


            gvUser.DataSource = list;
            gvUser.DataBind();

        }
        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            string id = e.CommandArgument.ToString();
            if (command == "Edit")
            {
                Response.Redirect("productedit.aspx?id=" + id);
            }
            else if (command == "Delete")
            {
                if (!bll.DeleteProduct(id, out msg))
                {
                    PageScript.Alert(this.Page, "删除失败");
                    return;
                }
                PageScript.Alert(this.Page, "删除成功");
                BindData();
            }
        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        /// <summary>
        /// 分页索引更改
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        /// 
        protected void pageProduct_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            pageProduct.CurrentPageIndex = e.NewPageIndex;

            BindData();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("productedit.aspx");
        }
    }
}