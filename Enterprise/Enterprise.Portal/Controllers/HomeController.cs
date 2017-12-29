using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;


namespace Enterprise.Portal.Controllers
{
    using Enterprise.BLL;
    using Enterprise.Common;
    using Enterprise.Model;
    using System.Configuration;

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        #region 首页导航栏
        public ActionResult Nav()
        {
            string where = string.Format("Status={0}", (int)EnabledOrNotEnum.Enabled);
            List<Category> list = new BLLCategory().GetList(where);

            //排序
            //select *
            //from category
            //order by ParentId,SortIndex
            list = list.OrderBy(o => o.ParentId).ThenBy(o => o.SortIndex).ToList();



            StringBuilder sb = new StringBuilder();
            //<li class='CurrentLi'>
            //    <a href='/'>网站首页</a>
            //</li>
            //<li>
            //    <a href='/About/intro' onmouseover=mopen('m2') onmouseout='mclosetime()'>关于公司</a>
            //    <div id='m2' onmouseover='mcancelclosetime()' onmouseout='mclosetime()'>
            //        <a href='/About/intro'>公司介绍</a>
            //        <a href='/About/Group'>组织机构</a>
            //        <a href='/About/Culture'>企业文化</a>
            //        <a href='/About/Enviro'>公司环境</a>
            //        <a href='/About/Business'>业务介绍</a>
            //    </div>
            //</li>
            List<Category> topList = list.FindAll(o => o.ParentId == 0);


            for (int i = 0; i < topList.Count; i++)
            {
                bool hasChildren = Convert.ToBoolean(topList[i].HasChildren);
                sb.AppendFormat("<li {0}>", i != 0 ? "" : "class = 'CurrentLi'");

                sb.AppendFormat("<a href='{0}' {2}>{1}</a>",
                    topList[i].Url,
                    topList[i].Name,
                    hasChildren ?
                    "onmouseover=mopen('m" + (i + 1) + "') onmouseout='mclosetime()'"
                    : ""
                    );
                if (!hasChildren)
                {
                    sb.Append("</li>");
                    continue;
                }
                sb.AppendFormat("<div id='m{0}' onmouseover='mcancelclosetime()' onmouseout='mclosetime()'>", i + 1);
                //找出当前一级分类的子分类
                //topList[i]
                //list

                List<Category> children = list.FindAll(o => o.ParentId == topList[i].CategoryId);
                foreach (Category child in children)
                {
                    sb.AppendFormat("<a href='{0}'>{1}</a>", child.Url, child.Name);
                }
                sb.Append("</div>");

                sb.Append("</li>");

            }
            ViewBag.Nav = sb.ToString();
            return PartialView();
        }

        #endregion


        #region 产品栏
        public ActionResult ProductList()
        {
            StringBuilder sb = new StringBuilder();

            //<li><a href='Product/DigitalPlayer'>数码播放器</a></li>
            //<li class='hover1'><a href='Product/Mobile'>智能手机</a></li>

            string strProductCategoryID = ConfigurationManager.AppSettings["ProductCategoryId"];
            string where = string.Format("Type = {0} And Status = {1}"
                , (int)CategoryTypeEnum.ProductList,
                (int)EnabledOrNotEnum.Enabled);
            List<Category> allList = new BLLCategory().GetList(where, "sortindex asc");
            List<Category> topList = allList.FindAll(o => o.ParentId == int.Parse(strProductCategoryID));
            if (topList.Count <= 0)
            {
                ViewBag.Menu = sb.ToString();
                ViewBag.List = CreateProductList(allList, topList);
                return PartialView();
            }

            for (int i = 0; i < topList.Count; i++)
            {
                sb.AppendFormat("<li {2}><a href='{0}'>{1}</a></li>"
                    , topList[i].Url,
                    topList[i].Name,
                    i == 1 ? "class='hover1'" : "");
            }




            ViewBag.Menu = sb.ToString();
            ViewBag.List = CreateProductList(allList, topList);
            return PartialView();
        }

        private string CreateProductList(List<Category> allList, List<Category> topList)
        {
            //<div class='hjone'>
            //    <div class='albumblock'>
            //        <div class='inner'>
            //            <a href='/Product/9854172030.html' target='_blank' title='艾诺 高清大屏MP4触摸+按键'>
            //                <img src='/images/up_images/20111210171953.jpg' width='166' height='166' />
            //                <div class='albumtitle'>艾诺 高清大屏MP4触摸+按</div>
            //            </a>
            //        </div>
            //    </div>
            //      ...
            //</div>

            StringBuilder sb = new StringBuilder();

            //1.0 遍历所有的一级产品分类
            if (topList.Count <= 0)//没有产品
            {
                return "";
            }

            for (int i = 0; i < topList.Count; i++)
            {
                sb.AppendFormat("<div class='hjone' style='display: {0};'>",
                    i == 1 ? "block" : "none");

                //2.0 查询当前一级产品分类下所有的产品（包含2级、3级）  IdPath

                /*查询指定分类下产品*/
                /*2.1 根据父级分类ID查询IdPath*/
                //select top 1 idpath from Category where CategoryId=12
                Category topCate = allList.SingleOrDefault(o => o.CategoryId == topList[i].CategoryId);
                if (topCate == null)
                {
                    sb.Append("</div>");
                    continue;
                }
                //topCate.IdPath;//查询当前一级产品分类的IdPath

                /*2.2 根据IdPath查询所有的子分类（包含2级、3级、4级...）*/
                //select *
                //from Category
                //where IdPath like ',11,12,%'
                List<Category> proCates = allList.FindAll(o => o.IdPath.StartsWith(topCate.IdPath));

                /*2.3 根据分类ID查询这些分类下的产品*/
                //select *
                //from Product
                //where CategoryId in(12,13,14)
                List<int> cateIds = proCates.Select(o => o.CategoryId).ToList();//只需要CategoryId
                string ids = string.Join(",", cateIds);//以逗号拼接id
                string where = string.Format("CategoryId in({0})", ids);
                List<Product> products = new BLLProduct().GetList(where, "sortindex asc", "ProductId,Name,thumburl");//根据分类ID查询产品
                if (products == null || products.Count <= 0)
                {
                    sb.Append("</div>");
                    continue;
                }

                //遍历产品
                foreach (Product pro in products)
                {
                    //    <div class='albumblock'>
                    //        <div class='inner'>
                    //            <a href='/Product/9854172030.html' target='_blank' title='艾诺 高清大屏MP4触摸+按键'>
                    //                <img src='/images/up_images/20111210171953.jpg' width='166' height='166' />
                    //                <div class='albumtitle'>艾诺 高清大屏MP4触摸+按</div>
                    //            </a>
                    //        </div>
                    //    </div>

                    sb.Append("<div class='albumblock'>");
                    sb.Append("<div class='inner'>");

                    //【未完成 套数据.....】
                    sb.AppendFormat("<a href='/Product/9854172030.html' target='_blank' title='艾诺 高清大屏MP4触摸+按键'>");
                    sb.AppendFormat("<img src='/images/up_images/20111210171953.jpg' width='166' height='166' />");
                    sb.AppendFormat("<div class='albumtitle'>艾诺 高清大屏MP4触摸+按</div>");
                    sb.Append("</a>");

                    sb.Append("</div>");
                    sb.Append("</div>");
                }

                sb.Append("</div>");
            }

            return sb.ToString();
        }
        #endregion


        #region 内容页导航栏
        /// <summary>
        /// 内容页导航栏
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Position()
        {
            //根据用户请求的url，生成导航

            return PartialView();
        }
        #endregion

        #region 关于公司
        public ActionResult About()
        {
            string fields = "ConfigId,AboutIntro,AboutUrl";
            Config config = new BLLConfiguration().GetConfig(fields);
            //<p>...<a href="/About">详细>> </a></p>
            return PartialView(config);
        }
        #endregion

        #region Contact
        public ActionResult Contact()
        {
            Config config = new BLLConfiguration().GetConfig();
            return PartialView(config);
        }
        #endregion
    }
}
