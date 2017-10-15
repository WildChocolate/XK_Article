using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 关于user表的抽象产品,增加了关于user表的一些特定操作，如登录。。。
    /// </summary>
    [ImplementFlag("UserDAL")]
    public interface IUser:IBaseOperation<User>
    {
        User Login(string LoginName,string Password);
    }
}
