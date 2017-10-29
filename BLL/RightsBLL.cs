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
    public class RightsBLL:BaseBLL<Rights>
    {
        IRights RightsDAL = ActiveProductGeter.CreateProduct<IRights>();
        protected override IDAL.IBaseOperation<Rights> ConcreteDAL
        {
            get { return RightsDAL; }
        }
    }
}
