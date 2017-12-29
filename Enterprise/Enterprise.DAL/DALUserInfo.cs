using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model;
using System.Data;
using System.Data.SqlClient;
using Enterprise.Common;

namespace Enterprise.DAL
{
    public class DALUserInfo
    {
        DALCommon dal = DALCommon.CreateIntance();

        /// <summary>
        /// Get all user informations
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserList(UserInfo user, out string msg)
        {
            string sql = string.Format("select [UserId], [Username], [RealName], [Phone], [UserType], [Status], [CreateDate] from UserInfo");
            SqlParameter sqsno = new SqlParameter("@userid", user.UserId);
            SqlParameter[] sqlist = { sqsno };
            DataTable dt = dal.ExecuteAdapter(sql, out msg, sqlist);

            return dal.DataTable2List<UserInfo>(dt, out msg).ToList();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public UserInfo GetUser(UserInfo user, out string msg)
        {
            string sql = string.Format("select [UserId], [Username], [RealName], [Phone], [UserType], [Status], [CreateDate] from UserInfo where Username = '{0}' and Password = '{1}'", user.Username, user.Password);
            DataTable dt = dal.ExecuteAdapter(sql, out msg);

            List<UserInfo> list = dal.DataTable2List<UserInfo>(dt, out msg).ToList();
            if (list != null)
            {
                UserInfo us = list.FirstOrDefault();
                return us;
            }
            return null;
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public UserInfo UserLogin(UserInfo user, out string msg)
        {
            string sql = string.Format("select * from UserInfo where 1=1 ");
            SqlParameter squsername = new SqlParameter("@username", user.Username);
            SqlParameter sqpwd = new SqlParameter("@password", user.Password);
            SqlParameter[] sqlist = { squsername, sqpwd };
            DataTable dt = dal.ExecuteAdapter(sql, out msg, sqlist);
            List<UserInfo> list = dal.DataTable2List<UserInfo>(dt, out msg).ToList();
            if (list != null)
            {
                return list.FirstOrDefault();
            }

            return null;

        }

        public int PostToUser(PostOp op, UserInfo user, string[] uptArray, out string msg, UserInfo whUsr = null, string[] whArray = null)
        {
            string sql = "";
            switch (op)
            {
                case PostOp.Add:
                    sql = dal.MakeInsertSql<UserInfo>(user, uptArray, false);
                    break;
                case PostOp.Edit:
                    sql = dal.MakeUpdateSql<UserInfo, UserInfo>(user, whUsr, uptArray, whArray);
                    break;
                case PostOp.Delete:
                    sql = dal.MakeDeleteSql<UserInfo>(user, uptArray);
                    break;
                default:
                    break;
            }

            return dal.ExecuteNonquery(sql, out msg);

        }
    }
}
