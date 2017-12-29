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
    public partial class UserList : CommonWebPage
    {
        BLLUserInfo bll = new BLLUserInfo();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle("用户管理");
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Useredit.aspx");
        }

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            string id = e.CommandArgument.ToString();
            if (command == "Edit")
            {
                Response.Redirect("Useredit.aspx?userid=" + id);
            }
            else if (command == "Delete")
            {
                if (!bll.DeleteUser(id, out msg))
                {
                    PageScript.Alert(this.Page, "删除失败");
                    return;
                }
                PageScript.Alert(this.Page, "删除成功");
                BindData();
            }
        }

        protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void BindData()
        {
            UserInfo user = new UserInfo();

            List<UserInfo> list = bll.GetUserList(user, out msg);
            if (!string.IsNullOrEmpty(msg))
            {
                PageScript.Alert(this.Page, msg);
                return;
            }

            foreach (UserInfo item in list)
            {
                item.StatusName = item.Status == 1 ? "启用" : "禁用";
            }

            gvUser.DataSource = list;
            gvUser.DataBind();

        }


    }
}