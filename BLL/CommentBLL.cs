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
    public class CommentBLL:BaseBLL<Comment>
    {
        IComment CommentDAL = ActiveProductGeter.CreateProduct<IComment>();
        protected override IDAL.IBaseOperation<Comment> ConcreteDAL
        {
            get { return CommentDAL; }
        }
    }
}
