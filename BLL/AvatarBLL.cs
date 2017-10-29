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
    public  class AvatarBLL:BaseBLL<Avatar>,IAvatar
    {
        IAvatar AvatarDAL = ActiveProductGeter.CreateProduct<IAvatar>();
        protected override IDAL.IBaseOperation<Avatar> ConcreteDAL
        {
            get { return AvatarDAL; }
        }
    }
}
