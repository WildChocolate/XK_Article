﻿using Factory;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public abstract class BaseBLL
    { 
        
    }
    /// !!!注意
    /// ------------------------------------------------------------------------------
    /// <summary>
    /// 所有 BLL类的基类，实现最基本的bll操作，IBaseOperation<T> 为所有产品的基类
    /// </summary>
    /// <typeparam name="T">与数据类相关的模型类</typeparam>
    public abstract class BaseBLL<T>
        where T   :Model.tblBase
    {
        protected abstract IBaseOperation<T> ConcreteDAL { get; }
        public virtual List<T> GetAll(T instance, string WhereString)
        {
            return ConcreteDAL.GetAll(instance, WhereString);
        }
        public virtual bool Update(T instance, string WhereString)
        {
            return ConcreteDAL.Update(instance, WhereString);
        }
        public virtual int Insert(T instance)
        {
            return ConcreteDAL.Insert(instance);
        }
        public bool Delete(T instance, string WhereString)
        {
            return ConcreteDAL.Delete(instance, WhereString);
        }
        public T GetOneByID(T instance, int id)
        {
            return ConcreteDAL.GetOneByID(instance, id);
        }
    }
}
