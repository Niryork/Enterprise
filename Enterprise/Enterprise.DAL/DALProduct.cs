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
    public class DALProduct
    {
        DALCommon dal = DALCommon.CreateIntance();
        public List<V_Product> GetProductlist(int pageindex, int pagesize, string strWh, out int count, out string msg)
        {
            DataTable dt = dal.ExecutePageProc(pageindex, pagesize, "V_Product", "ProductId", strWh, "SortIndex desc", out count, out msg);
            return dal.DataTable2List<V_Product>(dt, out msg).ToList();

        }


        public List<V_Product> GetProductlist(V_Product pro, out string msg)
        {
            string sql = dal.MakeSelectSql<V_Product>(pro, null);
            DataTable dt = dal.ExecuteAdapter(sql, out msg);

            return dal.DataTable2List<V_Product>(dt, out msg).ToList();
        }
        /// <summary>
        /// 通过ID获取产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Product GetProductById(string id, out string msg)
        {
            string sql = string.Format("select * from Product where productid = {0}", id);
            DataTable dt = dal.ExecuteAdapter(sql, out msg);
            List<Product> list = dal.DataTable2List<Product>(dt, out msg).ToList();

            if (list != null)
            {
                return list.FirstOrDefault();
            }

            return null;

        }


        public bool DeleteProduct(string productid, out string msg)
        {
            string sql = string.Format("delete from Product where productid ='{0}'", productid);

            return dal.ExecuteNonquery(sql, out msg) > 0;
        }

        public int Post2Product(PostOp op, Product user, string[] uptArray, out string msg, Product whPro = null, string[] whArray = null)
        {
            string sql = "";
            SqlParameter sqcontent = new SqlParameter("@content", user.Content);
            SqlParameter[] sqlist = { sqcontent };
            switch (op)
            {
                case PostOp.Add:
                    sql = dal.MakeInsertSql<Product>(user, out sqlist, uptArray, false);
                    break;
                case PostOp.Edit:
                    sql = dal.MakeUpdateSql<Product, Product>(user, whPro, uptArray, whArray, out sqlist);
                    break;
                case PostOp.Delete:
                    sql = dal.MakeDeleteSql<Product>(user, uptArray);
                    break;
                default:
                    break;
            }

            return dal.ExecuteNonquery(sql, out msg, sqlist);
        }

        /// <summary>
        /// 获取产品集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<Product> GetList(string where, string orderBy = "", string fields = "*")
        {
            string msg = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select {0} from Product", fields);

            if (!string.IsNullOrWhiteSpace(where))
            {
                sb.AppendFormat(" where {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                sb.AppendFormat(" order by {0}", orderBy);
            }

            DataTable dt = dal.ExecuteAdapter(sb.ToString(), out msg);
            return dal.DataTable2List<Product>(dt, out msg).ToList();
        }
    }
}
