using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Factory
{
    /// <summary>
    /// 根据传入的T类型动态生成相应的实体产品
    /// </summary>
    public static class ActiveProductGeter
    {
        /// <summary>
        /// assembly获取在配置文件中指定实际使用的工厂名称（程序集）
        /// </summary>
        static string assembly = System.Configuration.ConfigurationManager.AppSettings["ConcreteFactory"].ToString();

        /// <summary>
        /// 用于获取动态产品的方法
        /// </summary>
        /// <typeparam name="T">返回的产品</typeparam>
        /// <returns></returns>
        public static T CreateProduct<T>() where T:IBase
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<ImplementFlagAttribute>();
            var ImplementClassName = attribute.Flag;
            string className = assembly +"." +ImplementClassName;
            dynamic o = System.Reflection.Assembly.Load(assembly).CreateInstance(className, false);
            var result = Activator.CreateInstance(assembly,className).Unwrap(); 
            // 用配置文件指定的类组合
            return (T)result;
        }
    }
}
