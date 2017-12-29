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
    public partial class newslist : CommonWebPage
    {
        string msg;
        BLLNews bll = new BLLNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle("新闻管理");
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            string id = e.CommandArgument.ToString();
            if (command == "Edit")
            {
                Response.Redirect("newsedit.aspx?newsid=" + id);
            }
            else if (command == "Delete")
            {
                if (!bll.DeleteNews(id, out msg))
                {
                    PageScript.Alert(this.Page, "删除失败");
                    return;
                }
                PageScript.Alert(this.Page, "删除成功");
                BindData();
            }
        }

        private void BindData()
        {
            News model = new News();

            List<News> list = bll.GetNewsList(model, out msg);
            if (!string.IsNullOrEmpty(msg))
            {
                PageScript.Alert(this.Page, msg);
                return;
            }
            foreach (News item in list)
            {
                item.StatusName = item.Status == 1 ? "显示" : "隐藏";
                item.CategoryName = item.CategoryId == 9 ? "公司新闻" : "行业新闻";
                item.CreateUser = item.CreateUserId == 1 ? "admin" : "";
                item.UpdateUser = item.UpdateUserId == 1 ? "admin" : "";
            }
            gvNews.DataSource = list;
            gvNews.DataBind();

        }

        protected void gvNew_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("newsedit.aspx");
        }


    }
}