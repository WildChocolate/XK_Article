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
    public class RoleBLL:BaseBLL<Role>
    {
        IRole RoleDAL = ActiveProductGeter.CreateProduct<IRole>();

        protected override IBaseOperation<Role> ConcreteDAL
        {
            get { return RoleDAL; }
        }
    }
}
