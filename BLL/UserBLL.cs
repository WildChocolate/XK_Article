using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Model;
using IDAL;

namespace BLL
{
    public class UserBLL
    {
        IUser AdministartorDAL = AdministatorFactory.Create();
        public List<User> GetAll(string WhereString)
        {
            return AdministartorDAL.GetAll( WhereString);
        }
        public User Login(string LoginName,string Password) {
            return AdministartorDAL.Login(LoginName, Password);
        }
        public bool Update(User instance)
        {
            return AdministartorDAL.Update(instance);
        }
    }
}
