using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public class FriendlyLinkDAL : AbBase<FriendlyLink>, IFriendlyLink
    {
        protected override bool CheckExist(FriendlyLink instance)
        {
            throw new NotImplementedException();
        }
    }
}
