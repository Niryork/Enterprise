using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.BLL
{
    using Enterprise.Model;
    using Enterprise.DAL;



    public class BLLConfiguration
    {
        public Config GetConfig(string field = "*")
        {
            Config config = new DALConfiguration().GetConfig(field);
            return config;
        }
    }
}
