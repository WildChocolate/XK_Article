using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IUser:IBaseOperation<User>
    {
        User Login(string LoginName,string Password);
    }
}
