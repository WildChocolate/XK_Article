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
    public class ColumnBLL:BaseBLL<Column>,IColumn
    {
        IColumn ColumnDAL = ActiveProductGeter.CreateProduct<IColumn>();
        protected override IDAL.IBaseOperation<Column> ConcreteDAL
        {
            get { return ColumnDAL; }
        }
        public override List<Column> GetAll(Column instance, string WhereString)
        {
            return base.GetAll(instance, WhereString).Take(8).ToList();
        }
        public List<Column> GetDataByCommandString(string command ,string WhereString)
        {
            return ColumnDAL.GetDataByCommandString(command,WhereString);
        }
    }
}
