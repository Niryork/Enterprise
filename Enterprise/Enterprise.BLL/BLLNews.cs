using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model;
using Enterprise.DAL;

namespace Enterprise.BLL
{
    public class BLLNews
    {

        DALNews dal = new DALNews();

        /// <summary>
        /// 获取新闻集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="fields">待查询的字段</param>
        /// <returns></returns>
        public List<News> GetList(string where, string orderBy = "", string fields = "*")
        {
            return dal.GetList(where, orderBy, fields);
        }

        /// <summary>
        /// 获取新闻分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="recordCount"></param>
        /// <param name="where"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<News> GetPageList(int pageIndex, int pageSize, string orderBy, out int recordCount, string where = "", string fields = "*")
        {
            return dal.GetPageList(pageIndex, pageSize, orderBy, out recordCount, where, fields);
        }
        #region GetNews
        public List<News> GetNewsList(News news, out string msg)
        {
            return dal.GetNewsList(news, out msg);
        }

        public News GetNewsId(string id, out string msg)
        {
            return dal.GetNewsId(id, out msg);
        }


        #endregion

        #region Delete News
        /// <summary>
        /// delete news by id 
        /// </summary>
        /// <param name="newid"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteNews(string newid, out string msg)
        {
            return dal.DeleteNews(newid, out msg) > 0;
        }
        #endregion
    }
}
