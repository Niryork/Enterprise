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
    public partial class Useredit : CommonWebPage
    {
        BLLUserInfo bll = new BLLUserInfo();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle("用户添加");
            string id = Request.QueryString["UserId"];
            if (!string.IsNullOrEmpty(id))
            {
                SetTitle("用户编辑");
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string id = Request.QueryString["UserId"] ?? "0";
            UserInfo model = new UserInfo() { };
            UserInfo user = null;
            if (id != "0")
            {
                model.UserId = Convert.ToInt32(id);
            }

            user = bll.GetUserInfo(model, out msg);

            if (user == null)
            {
                user = default(UserInfo);
                return;
            }
            UserId.Value = user.UserId.ToString();
            Username.Value = user.Username;
            RealName.Value = user.RealName;
            Phone.Value = user.Phone;

            if (user.UserType == 1)
            {
                rdoSuper.Checked = true;
            }
            else if (user.UserType == 2)
            {
                rdoNet.Checked = true;
            }

            if (user.Status == 0)
            {
                rdoNo.Checked = true;
            }
            else
            {
                rdoYes.Checked = true;
            }
        }

        /// <summary>
        /// Submit changes to Server
        /// </summary>
        private void PostToUserInfo()
        {
            UserInfo user = new UserInfo()
            {
                Username = Username.Value,
                RealName = RealName.Value,
                Phone = Phone.Value
            };
            user.Password = "123456";
            user.Status = 1;
            if (rdoNo.Checked)
            {
                user.Status = 0;
            }

            user.UserType = 1;
            if (rdoNet.Checked)
            {
                user.UserType = 2;
            }
            #region 判断添加或者修改
            string result = "修改";
            if (!string.IsNullOrEmpty(UserId.Value))
            {
                user.UserId = Convert.ToInt32(UserId.Value);
            }
            else
            {
                user.UserId = 0;
                result = "添加";
            }
            bool isOk = bll.UptUser(user, out msg);
            if (!string.IsNullOrEmpty(msg))
            {
                PageScript.Alert(this.Page, msg);
                return;
            }
            #endregion

            if (isOk)
            {
                PageScript.Alert(this.Page, result + "成功");
            }
            else
            {
                PageScript.Alert(this.Page, result + "失败");
            }

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            PostToUserInfo();
            string url = "/admin/UserList.aspx";
            PageScript.BackTo(this.Page, url);
        }
    }
}