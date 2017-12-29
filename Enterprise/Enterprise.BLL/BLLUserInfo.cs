using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model;
using Enterprise.DAL;
using Enterprise.Common;

namespace Enterprise.BLL
{
    public class BLLUserInfo
    {
        DALUserInfo dal = new DALUserInfo();
        public UserInfo GetUserInfo(UserInfo user, out string msg)
        {
            return dal.GetUser(user, out msg);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserList(UserInfo user, out string msg)
        {
            return dal.GetUserList(user, out msg);
        }

        public bool DeleteUser(string id, out string msg)
        {
            UserInfo user = new UserInfo()
            {
                UserId = Convert.ToInt32(id)
            };
            string[] whcol = { "userid" };
            return dal.PostToUser(PostOp.Delete, user, whcol, out msg) > 0;
        }

        public bool UptUser(UserInfo user, out string msg)
        {
            //要更新的列
            string[] uptstr = { "Username", "RealName", "Phone", "UserType", "Status", "CreateDate" };
            if (user.UserId != 0)
            {
                //条件列
                UserInfo whusr = new UserInfo()
                {
                    UserId = user.UserId
                };
                string[] whArry = { "UserId" };

                return dal.PostToUser(PostOp.Edit, user, uptstr, out msg, whusr, whArry) > 0;
            }
            else
            {
                return dal.PostToUser(PostOp.Add, user, uptstr, out msg) > 0;
            }

        }
    }
}
