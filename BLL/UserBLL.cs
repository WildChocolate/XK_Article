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
        IUser UserDAL = ActiveProductGeter.CreateProduct<IUser>();
        public List<User> GetAll(User instance,string WhereString)
        {
            return UserDAL.GetAll(instance, WhereString);
        }
        public User Login(string LoginName,string Password) {
            return UserDAL.Login(LoginName, Password);
        }
        public bool Update(User instance,string WhereString)
        {
            return UserDAL.Update(instance, WhereString);
        }
        public int Insert(User instance)
        {
            return UserDAL.Insert(instance);
        }
        public bool Delete(User instance,string WhereString)
        {
            return UserDAL.Delete(instance,WhereString);
        }
        public User GetOneByID(User instance,int id)
        {
            return UserDAL.GetOneByID(instance,id);
        }
    }
}
