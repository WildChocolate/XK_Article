using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public class CommentDAL : AbBase<Comment>, IComment
    {
        protected override bool CheckExist(Comment instance)
        {
            throw new NotImplementedException();
        }
    }
}
