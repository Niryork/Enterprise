using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.BLL;
using Enterprise.Model;
using Enterprise.Common;
namespace Enterprise.Web.admin
{
    public partial class newsedit : CommonWebPage
    {
        BLLNews nbll = new BLLNews();
        BLLCategory cbll = new BLLCategory();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle("新闻添加");
            string id = Request.QueryString["newsid"];
            if (!string.IsNullOrEmpty(id))
            {
                SetTitle("新闻修改");
            }
            if (!IsPostBack)
            {
                BindCategory();
                BindNews();
            }
        }
        private void BindCategory()
        {
            List<Category> list = cbll.GetNewsCategoryTree(out msg);
            ddlCategoryName.DataSource = list;
            ddlCategoryName.DataValueField = "CategoryId";
            ddlCategoryName.DataTextField = "Name";
            ddlCategoryName.DataBind();

        }

        public void BindNews()
        {
            string id = Request.QueryString["newsid"] ?? "0";

            News news = nbll.GetNewsId(id, out msg);


            if (news == null)
            {
                news = default(News);
                return;
            }
            NewsId.Value = news.NewsId.ToString();
            Newstitle.Value = news.Title;
            hdUpdateUser.Value = news.UpdateUserId == 1 ? "admin" : "";
            if (news.Status == 0)
            {
                rdoNo.Checked = true;
            }
            else
            {
                rdoYes.Checked = true;
            }


            hdContent.Value = news.Content;
            int categoryId = news.CategoryId;
            ddlCategoryName.SelectedValue = "公司新闻";
            if (categoryId != 9)
            {
                ddlCategoryName.SelectedValue = "行业新闻";
            }
            
        }


        public void PostToNews()
        {
            int id = Convert.ToInt32(Request.QueryString["newsid"] ?? "0");
            News model = new News()
            {
                Title = Newstitle.Value
            };
            model.CategoryId = Convert.ToInt32(ddlCategoryName.SelectedValue);
            model.UpdateUserId = id;
            int status = 1;
            if (rdoNo.Checked)
            {
                status = 0;
            }
            model.Status = status;

            if (true)
            {

            }

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            PostToNews();
            string url = "/admin/newslist.aspx";
            PageScript.BackTo(this.Page, url);
        }
    }
}