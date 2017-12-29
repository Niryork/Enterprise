using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Enterprise.Model;
using Enterprise.Common;
using System.Data.SqlClient;
namespace Enterprise.DAL
{

    public class DALNews
    {
        DALCommon dal = DALCommon.CreateIntance();
        public List<News> GetNewsList(int pageindex, int pagesize, string strWh, out int count, out string msg)
        {
            DataTable dt = dal.ExecutePageProc(pageindex, pagesize, "News", "NewsId", strWh, "NewsId desc", out count, out msg);
            return dal.DataTable2List<News>(dt, out msg).ToList();

        }

        public News GetNewsId(string id, out string msg)
        {
            string sql = string.Format("select * from News where newsid = {0}", id);
            DataTable dt = dal.ExecuteAdapter(sql, out msg);
            List<News> list = dal.DataTable2List<News>(dt, out msg).ToList();

            if (list != null)
            {
                return list.FirstOrDefault();
            }

            return null;

        }




        public List<News> GetNewsList(News news, out string msg)
        {
            string orderby = "NewsId desc";
            string sql = dal.MakeSelectSql<News>(news, null, orderby);

            DataTable dt = dal.ExecuteAdapter(sql, out msg);
            return dal.DataTable2List<News>(dt, out msg).ToList();
        }

        public int DeleteNews(string newid, out string msg)
        {
            string sql = string.Format("delete from News where newsid ='{0}'", newid);

            return dal.ExecuteNonquery(sql, out msg);
        }

        #region New Function
        /// <summary>
        /// 获取新闻集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<News> GetList(string where, string orderBy = "", string fields = "*")
        {
            string msg = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select {0} from News", fields);

            if (!string.IsNullOrWhiteSpace(where))
            {
                sb.AppendFormat(" where {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                sb.AppendFormat(" order by {0}", orderBy);
            }

            DataTable dt = dal.ExecuteAdapter(sb.ToString(), out msg);
            return dal.DataTable2List<News>(dt, out msg).ToList();
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
            DataTable dt = dal.ExecutePageProcedure(pageIndex, pageSize, "News", orderBy, out recordCount, where, fields);

            string msg = "";
            return dal.DataTable2List<News>(dt, out msg).ToList();
        }

        #endregion

    }
}
