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
    ///     根据传入的T类型动态生成相应的实体产品
    ///     在本程序中ActiveProductGeter相当于一个 抽象工厂，配置文件中指定具体工厂，把判断生成具体工厂的逻辑转移至配置文件中。。。
    ///
    ///     再通过反射生成具体工厂，具体工厂在本例中 应该相当于是 SqlDAL（也可以是AccessDAL,MySqlDAL,如果有的话！） 整个程序集。。。
    /// 并非 一般例子中的直接创建并返回 那些与工厂相关产品的类  eg : AbstractFactory factorysubA = new AbstractFactoryA();为什么？？？
    ///     因为生成产品的方法为一个 泛型方法，生成的产品根据传入的 抽象产品 T（接口)确定，而 T 又通过特性 ImplementFlagAttribute 标记了
    /// 相应的实现类(具体产品), So, 就不用针对每个产品都写一个返回 具体产品的方法。。。
    ///     由于判断实体工厂的逻辑在配置文件中，判断具体产品的逻辑在接口特性中，所以本例没有实体工厂类。。。
    /// 
    /// 以上，备忘....
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
