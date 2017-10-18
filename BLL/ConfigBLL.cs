using Factory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConfigBLL:BaseBLL<Config>
    {
        IConfig ConfigDAL = ActiveProductGeter.CreateProduct<IConfig>();
        protected override IDAL.IBaseOperation<Config> ConcreteDAL
        {
            get { return ConfigDAL; }
        }
    }
}
