using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public class ColumnDAL:AbBase<Column>,IColumn
    {

        protected override bool CheckExist(Column instance)
        {
            throw new NotImplementedException();
        }
    }
}
