using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public class ConfigDAL:AbBase<Config>,IConfig
    {
        protected override bool CheckExist(Config instance)
        {
            throw new NotImplementedException();
        }
    }
}
