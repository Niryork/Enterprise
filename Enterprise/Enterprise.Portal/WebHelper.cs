using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Enterprise.Portal
{
    public class WebHelper
    {
        public static string CreatePageBar(int pageIndex, int pageSize, int recordCount, string url)
        {
            if (recordCount <= 0)
            {
                return "";//没有记录
            }

            int pageCount = (int)Math.Ceiling((double)recordCount / pageSize);//总页数
            url = url + "?pi=";

            StringBuilder sb = new StringBuilder();

            //<div class="t_page ColorLink">
            //    总数：23条&nbsp;&nbsp;当前页数：<span class="FontRed">1</span>/2
            //    <a href="index.html">首页</a>&nbsp;&nbsp;
            //    上一页&nbsp;&nbsp;
            //    <a href="index.html">1</a>
            //    <a href="list_2.html">2</a>
            //    <a href="list_2.html">下一页</a>
            //    <a href="list_2.html">尾页</a>
            //</div>

            sb.Append("<div class='t_page ColorLink'>");
            sb.AppendFormat("总数：{0}条&nbsp;&nbsp;当前页数：<span class='FontRed'>{1}</span>/{2}",
                recordCount,
                pageIndex,
                pageCount);

            //    /News/IndustryNews/

            sb.AppendFormat("<a href='{0}'>首页</a>&nbsp;&nbsp;", url + 1);

            if (pageIndex <= 1)//当前第一页
            {
                sb.Append("上一页&nbsp;&nbsp;");//不能点击
            }
            else
            {
                sb.AppendFormat("<a href='{0}'>上一页</a>&nbsp;&nbsp;", url + (pageIndex - 1));
            }

            //页码
            for (int i = 1; i <= pageCount; i++)
            {
                sb.AppendFormat("<a href='{0}' {2}>{1}</a>",
                    url + i,
                    i,
                    i == pageIndex ? "style='color:red;'" : "");
            }
            
            if (pageIndex >= pageCount)//当前最后一页
            {
                sb.Append("下一页&nbsp;&nbsp;");//不能点击
            }
            else
            {
                sb.AppendFormat("<a href='{0}'>下一页</a>&nbsp;&nbsp;", url + (pageIndex + 1));
            }

            sb.AppendFormat("<a href='{0}'>尾页</a>", url + pageCount);

            sb.Append("</div>");

            return sb.ToString();
        }


    }
}