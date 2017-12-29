using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;



namespace Enterprise.Common
{
    public class MD5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string Encryption(string pwd)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5");
        }



        /// <summary>
        /// UrlEncode加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string UrlEncode(string content, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            string encode = HttpUtility.UrlEncode(content, encoding).ToUpper();
            return encode;
        }

        /// <summary>
        /// UrlDencode解密
        /// </summary>
        /// <param name="encode"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string UrlDencode(string encode, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            string content = HttpUtility.UrlDecode(encode, encoding);
            return content;
        }
    }
}
