using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Enterprise.Model;

namespace Enterprise.DAL
{
    public class DALCategory
    {
        DALCommon dal = DALCommon.CreateIntance();

        /// <summary>
        /// 获取所有的分类
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<Category> GetAllCategory(out string msg)
        {
            string sql = "select * from Category order by SortIndex desc";
            DataTable dt = dal.ExecuteAdapter(sql, out msg);

            return dal.DataTable2List<Category>(dt, out msg).ToList();
        }


        /// <summary>
        /// 获取分类集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<Category> GetList(string where, string orderBy = "", string fields = "*")
        {
            string msg = "";
            //string与StringBuilder的区别？

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select {0} from Category", fields);

            if (!string.IsNullOrWhiteSpace(where))
            {
                sb.AppendFormat(" where {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                sb.AppendFormat(" order by {0}", orderBy);
            }

            DataTable dt = dal.ExecuteAdapter(sb.ToString(), out msg);
            return dal.DataTable2List<Category>(dt, out msg).ToList();
        }

        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Category GetModel(string where, string orderBy = "", string fields = "*")
        {
            string msg = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select top 1 {0} from Category", fields);

            if (!string.IsNullOrWhiteSpace(where))
            {
                sb.AppendFormat(" where {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                sb.AppendFormat(" order by {0}", orderBy);
            }

            DataTable dt = dal.ExecuteAdapter(sb.ToString(), out msg);
            List<Category> list = dal.DataTable2List<Category>(dt, out msg).ToList();

            return list == null || list.Count <= 0
                ? null
                : list[0];
        }


    }
}
