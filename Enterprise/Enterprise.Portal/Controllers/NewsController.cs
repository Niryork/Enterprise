using Enterprise.BLL;
using Enterprise.Common;
using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise.Portal.Controllers
{
    public class NewsController : Controller
    {
        /// <summary>
        /// 新闻详细页
        /// </summary>
        /// <param name="newsId">新闻ID</param>
        /// <returns></returns>
        public ActionResult Detail(int newsId)
        {
            return new EmptyResult();
        }

        public ActionResult List(int pi = 1)
        {
            #region 测试 存储过程
            //int recordCount = 0;
            //List<News> list = new BLLNews().GetPageList(1, 10, "UpdateDate desc", out recordCount, "Status=1", "NewsId,title");

            //return new EmptyResult(); 
            #endregion

            #region done
            int pageIndex = pi < 1 ? 1 : pi;//页码
            int pageSize = 3;//页大小 写在配置文件
            int recordCount = 0;//总记录数

            //根据用户请求的url，查询CategoryId
            string rawUrl = Request.Url.AbsolutePath;//绝对路径  不包含 http:// 域名 IP 端口
            //return Content(rawUrl);
            Category newsCate = new BLLCategory().GetModel("url='" + rawUrl + "'", fields: "categoryId");//查询新闻分类
            //newsCate.CategoryId
            if (newsCate == null)
            {
                ViewBag.NewsList = new List<News>();//新闻列表
                ViewBag.PageBar = "";//分页栏

                return View();
            }

            //根据新闻分类ID，分页查询新闻
            //select NewsId,Title,UpdateDate
            //from News
            //where CategoryId=10 and Status=1

            //如果用户访问的是 新闻动态，那么查询所有可显示的新闻
            //【已完成...点击新闻动态是要在页面上显示所有新闻】

            string where = newsCate.CategoryId == 8 ? string.Format("Status={1}",
                newsCate.CategoryId,
                (int)EnabledOrNotEnum.Enabled) : string.Format("CategoryId={0} and Status={1}",
                newsCate.CategoryId,
                (int)EnabledOrNotEnum.Enabled);
            List<News> newsList = new BLLNews().GetPageList(pageIndex, pageSize, "UpdateDate desc", out recordCount, where, "NewsId,Title,UpdateDate");//分页查询
            ViewBag.NewsList = newsList;//新闻列表
            ViewBag.PageBar = WebHelper.CreatePageBar(pageIndex, pageSize, recordCount, rawUrl);//分页栏
            #endregion
            return View();
        }
        /// <summary>
        /// 左中 最新资讯
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Left_Center_New()
        {
            return PartialView();
        }

        /// <summary>
        /// 左上 新闻分类菜单
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Left_Top_News()
        {
            //从配置文件读取新闻动态的分类ID
            string strNewsCategoryId = ConfigurationManager.AppSettings["NewsCategoryId"];

            //select CategoryId,Name,Url
            //from Category
            //where ParentId=8 and Status=1
            //order by SortIndex asc

            //获取新闻分类
            string where = string.Format("ParentId={0} and Status={1}",
                strNewsCategoryId,
                (int)EnabledOrNotEnum.Enabled);
            List<Category> list = new BLLCategory().GetList(where, "SortIndex asc", "CategoryId,Name,Url");

            return PartialView(list);
        }

    }
}
