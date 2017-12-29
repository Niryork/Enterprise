using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.DAL
{
    using Enterprise.Common;
    using Enterprise.Model;
    using System.Data;
    public class DALConfiguration
    {
        DALCommon dal = DALCommon.CreateIntance();
        /// <summary>
        /// 获取配置表的所有信息
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <param name="field">要查询的字段</param>
        /// <returns></returns>
        public Config GetConfig(string field="*")
        {
            string msg = "";
            Config config = new Config();
            string sql = string.Format("select {0} from Config",field);
            DataTable dt =  dal.ExecuteAdapter(sql,out msg);
            return dal.DataTable2List<Config>(dt, out msg).FirstOrDefault();
            //return config;
        }
    }
}
