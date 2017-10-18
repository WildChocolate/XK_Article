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
    public class FriendlyLinkBLL:BaseBLL<FriendlyLink>
    {
        IFriendlyLink FriendlyLinkDAL = ActiveProductGeter.CreateProduct<IFriendlyLink>();
        protected override IDAL.IBaseOperation<FriendlyLink> ConcreteDAL
        {
            get { return FriendlyLinkDAL; }
        }
    }
}
