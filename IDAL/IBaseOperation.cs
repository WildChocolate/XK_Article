using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// IBaseOperation<T>接口的基接口，用在  Factory的ActiveProductGeter，对传入的类型类型进行泛型约束，本身不实现任何方法
    /// </summary>
    public interface IBase
    {

    }
    /// <summary>
    /// 所有抽象产品的的基接口，定义关于各个抽象产品的公共且最基础的操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseOperation<T>:IBase
        where T:class
    {
        int Insert(T instance);
        bool Delete(T instance, string WhereString);
        bool Update(T instance, string WhereString);
        List<T> GetAll(T instance,string WhereString);
        T GetOneByID(T instance,int id);
        List<T> GetDataByCommandString(string command, string WhereString);
        int UpdateByCommandString(string command, string WhereString);
    }
}
