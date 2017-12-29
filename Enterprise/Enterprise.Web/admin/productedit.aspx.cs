using Enterprise.BLL;
using Enterprise.Common;
using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.Web.admin
{
    public partial class productedit : CommonWebPage
    {
        BLLProduct pbll = new BLLProduct();
        BLLCategory cbll = new BLLCategory();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {

            SetTitle("产品添加");
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                SetTitle("产品编辑");
            }
            if (!IsPostBack)
            {
                BindCategory();
                BindProduct();

            }
        }
        private void BindCategory()
        {
            List<Category> list = cbll.GetNewsCategoryTree(out msg);
            ddlCategory.DataSource = list;
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataBind();
        }


        private void BindProduct()
        {
            string id = Request.QueryString["id"] ?? "0";

            Product pro = pbll.GetProductId(id, out msg);
            if (pro == null)
            {
                pro = default(Product);
                return;
            }
            ProductId.Value = pro.ProductId.ToString();
            Name.Value = pro.Name;
            ProImg.ImageUrl = pro.ImgUrl;
            ImgUrl.Value = pro.ImgUrl;
            ThumbUrl.Value = pro.ThumbUrl;
            if (pro.Status == 0)
            {
                rdoNo.Checked = true;
            }
            else
            {
                rdoYes.Checked = true;
            }
            hdContent.Value = pro.Content;
            ddlCategory.SelectedValue = pro.CategoryId.ToString();

        }

        /// <summary>
        /// 提交变化
        /// </summary>
        private void Post2Product()
        {
            Product pro = new Product()
            {
                Name = Name.Value,
                Content = hdContent.Value.ToString()
            };
            string imgurl = "";
            string thumbUrl = "";
            if (postImg.HasFile)
            {
                //上传图片
                string extension = Path.GetExtension(postImg.FileName);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                string path = Server.MapPath("/admin/images/uploadImg/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string thumbpath = path;
                path += filename;
                postImg.SaveAs(path);
                if (File.Exists(path))
                {

                    imgurl = "/admin/images/uploadImg/" + filename;
                }

                //生成缩略图
                int newWidth = 100;
                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                string ThumbFileName = "Thumb-" + filename;
                int newHeight = newWidth * img.Height / img.Width;
                ImageOp.SaveToImg(img, newWidth, newHeight, ThumbFileName, thumbpath, true);


                thumbpath += ThumbFileName;
                if (File.Exists(thumbpath))
                {

                    thumbUrl = "/admin/images/uploadImg/" + ThumbFileName;
                }

            }
            else
            {
                imgurl = ImgUrl.Value;
                thumbUrl = ThumbUrl.Value;
            }

            pro.ImgUrl = imgurl;
            pro.ThumbUrl = thumbUrl;

            pro.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);

            int status = 1;
            if (rdoNo.Checked)
            {
                status = 0;
            }

            pro.Status = status;

            #region 判断添加或者修改
            string result = "修改";
            if (!string.IsNullOrEmpty(ProductId.Value))
            {
                pro.ProductId = Convert.ToInt32(ProductId.Value);
            }
            else
            {
                pro.ProductId = 0;
                result = "添加";
            }
            bool isOk = pbll.UptProduct(pro, out msg);
            #endregion

            #region Debug
            if (!string.IsNullOrEmpty(msg))
            {
                PageScript.Alert(this.Page, msg);
                return;
            }

            #endregion     


            if (isOk)
            {
                ProImg.ImageUrl = imgurl;
                ImgUrl.Value = imgurl;
                ThumbUrl.Value = imgurl;
                PageScript.Alert(this.Page, result + "成功");
                return;
            }
            else
            {
                PageScript.Alert(this.Page, result + "失败");
                return;
            }

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Post2Product();
            string url = "/admin/productlist.aspx";
            PageScript.BackTo(this.Page, url);
        }

    }
}