using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 用于标记相信接口（抽象产品）的实现类，用于反射生成对象
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface,AllowMultiple=false,Inherited=true)]
    public class ImplementFlagAttribute:Attribute
    {
        public ImplementFlagAttribute(string Flag)
        {
            this.flag = Flag;
        }
        private string flag;
        public string Flag {
            get { return flag; }
        }
    }
}
