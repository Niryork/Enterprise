using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Model;
using Enterprise.DAL;
using Enterprise.Common;



namespace Enterprise.BLL
{
    public class BLLProduct
    {

        DALProduct dal = new DALProduct();

        #region Get Product list
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<V_Product> GetProductList(V_Product pro, out string msg)
        {
            return dal.GetProductlist(pro, out msg);
        }

        /// <summary>
        /// 获取产品列表，并进行分页
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="strWh"></param>
        /// <param name="count"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<V_Product> GetProductList(int pageindex, int pagesize, string strWh, out int count, out string msg)
        {
            return dal.GetProductlist(pageindex, pagesize, strWh, out count, out msg);
        } 
        #endregion



        /// <summary>
        /// 获取产品ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Product GetProductId(string id, out string msg)
        {
            return dal.GetProductById(id, out msg);
        }

        /// <summary>
        /// 更新产品信息
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UptProduct(Product pro, out string msg)
        {
            string[] uptArray = { "Name", "ImgUrl", "ThumbUrl", "CategoryId", "Status", "Content" };
            Product whPro = new Product()
            {
                ProductId = pro.ProductId
            };

            string[] whArray = { "ProductId" };

            return dal.Post2Product(PostOp.Edit, pro, uptArray, out msg, whPro, whArray) > 0;
        }
        /// <summary>
        /// 通过产品ID删除产品
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DeleteProduct(string productid, out string msg)
        {
            return dal.DeleteProduct(productid, out msg);
        }
        /// <summary>
        /// 获取产品集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="fields">待查询的字段</param>
        /// <returns></returns>
        public List<Product> GetList(string where, string orderBy = "", string fields = "*")
        {
            return dal.GetList(where, orderBy, fields);
        }

    }
}
