using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model;
using Enterprise.DAL;

namespace Enterprise.BLL
{
    public class BLLCategory
    {

        DALCategory dal = new DALCategory();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type">分类类型 1链接 2内容页 3新闻列表 4产品列表</param>
        /// <returns></returns>
        public List<Category> GetShowCategory(out string msg, int type = 0)
        {
            List<Category> list = dal.GetAllCategory(out msg);

            if (list != null)
            {
                //返回启用的类别
                //获取全部
                list = list.Where(item => item.Status == 1).ToList();

                if (type > 0)
                {
                    //根据类型获取类别列表
                    list = list.Where(item => item.Type == type).ToList();
                }

                return list;
            }

            return null;
        }

        public List<Category> GetNewsCategoryTree(out string msg)
        {
            List<Category> list = GetShowCategory(out msg, 3);
            if (list != null)
            {
                //获取根目录列表
                List<Category> rootList = list.Where(item => item.ParentId == 0).ToList();
                List<Category> reslist = new List<Category>();
                GetTreeNode(list, rootList, ref reslist);

                return reslist;
            }

            return null;
        }


        public List<Category> GetProductCategoryTree(out string msg)
        {
            List<Category> list = GetShowCategory(out msg, 4);
            if (list != null)
            {
                //获取根目录列表
                List<Category> rootList = list.Where(item => item.ParentId == 0).ToList();
                List<Category> reslist = new List<Category>();
                GetTreeNode(list, rootList, ref reslist);

                return reslist;
            }

            return null;
        }



        string heng = "----";
        int index = 1;
        /// <summary>
        /// 获取树的子节点
        /// </summary>
        /// <param name="alllist"></param>
        /// <param name="rootList"></param>
        /// <param name="reslist"></param>
        public void GetTreeNode(List<Category> alllist, List<Category> rootList, ref List<Category> reslist)
        {
            string newheng = "";
            for (int k = 0; k < index; k++)
            {
                newheng += heng;
            }
            List<Category> rootNodeList = new List<Category>();
            for (int i = 0; i < rootList.Count; i++)
            {
                Category root = rootList[i];
                if (index > 1)
                {
                    root.Name = newheng + root.Name;
                }
                reslist.Add(root);
                for (int j = 0; j < alllist.Count; j++)
                {
                    Category node = alllist[j];
                    if (root.CategoryId == node.ParentId)
                    {

                        node.Name = newheng + node.Name;
                        reslist.Add(node);

                        //先判断有没有下一级
                        rootNodeList = alllist.Where(item => item.ParentId == node.CategoryId).ToList();
                        if (rootNodeList != null && rootNodeList.Count > 0)
                        {
                            index++;
                            GetTreeNode(alllist, rootNodeList, ref reslist);
                        }


                        //将子节点保存到二级根节点中
                        // rootNodeList.Add(node);
                    }
                }
            }

            index--;


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
            return dal.GetModel(where, orderBy, fields);
        }


        /// <summary>
        /// 获取分类集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="fields">待查询的字段</param>
        /// <returns></returns>
        public List<Category> GetList(string where, string orderBy = "", string fields = "*")
        {
            return dal.GetList(where, orderBy, fields);
        }

    }
}
