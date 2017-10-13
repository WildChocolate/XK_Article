using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    
    public interface IBaseOperation<T> where T:class
    {
        bool Insert(T instance);
        bool Delete(T instance);
        bool Update(T instance);
        List<T> GetAll(string WhereString);
        bool Convert(IList<T> Target,DataSet Source);
        T GetOneByID(int id);
    }
}
