using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Common
{
    /// <summary>
    /// 分类类型枚举
    /// </summary>
    public enum CategoryTypeEnum
    {
        //分类类型 1链接 2内容页 3新闻列表 4产品列表

        /// <summary>
        /// 链接
        /// </summary>
        Link = 1,

        /// <summary>
        /// 内容页
        /// </summary>
        ContentPage = 2,

        /// <summary>
        /// 新闻列表
        /// </summary>
        NewsList = 3,

        /// <summary>
        /// 产品列表
        /// </summary>
        ProductList = 4,

    }
}
