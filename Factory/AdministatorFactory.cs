using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Factory
{
    public static class AdministatorFactory
    {
        public static IUser Create()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["ConcreteFactory"].ToString();
            string className = path + ".UserDAL";
            dynamic o = System.Reflection.Assembly.Load(path).CreateInstance(className, false);
            
            var result = Activator.CreateInstance(path,className).Unwrap(); 
            // 用配置文件指定的类组合
            return (IDAL.IUser)result;
        }
    }
}
