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
    public class ColumnBLL:BaseBLL<Column>
    {
        IColumn CommentDAL = ActiveProductGeter.CreateProduct<IColumn>();
        protected override IDAL.IBaseOperation<Column> ConcreteDAL
        {
            get { return CommentDAL; }
        }
    }
}
