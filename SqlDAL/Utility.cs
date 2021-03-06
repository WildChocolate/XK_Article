﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public enum ActionType
    {
        Select,
        Update,
        Delete,
        Insert
    }
    public class Utility
    {
        /// <summary>
        /// ConnectionInfo 的摘要说明。
        /// </summary>
       
            //public static string GetSqlServerConnectionString()
            //{
            //    return ConfigurationManager.AppSettings["SqlServerConnection"];
            //}
            public static string SqlServerConnectionString
            {
                get
                {
                    return ConfigurationManager.ConnectionStrings["ServerConnection"].ToString();
                }
            }
            public static string GetOperationStringBy<T>(ActionType action, T instance,string WhereString="1=1") {
                var type = instance.GetType();
                string tableName = type.Name;
                string s = "";
                switch (action)
                {
                    case ActionType.Delete:
                        s = string.Format("delete from XK_{0} where 1=1 ", tableName );
                        break;
                    case ActionType.Insert:
                        var items=GetInsertString(type);
                        s = string.Format("insert into XK_{0} ({1}) values({2}) ",tableName,items.Item1,items.Item2);
                        break;
                    case ActionType.Update:
                        s = string.Format("update XK_{0} set {1} where 1=1 ", tableName, GetUpdateString(type) );
                        break;
                    case ActionType.Select:
                        s = string.Format("select * from XK_{0} where 1=1 ", tableName );
                        break;
                }
                if (WhereString.Length > 0 && action!=ActionType.Insert)
                {
                    s += " and " + WhereString;
                }
                else if (action==ActionType.Insert){
                    s += ";select @@identity";
                }
                return s;
            }
            static Tuple<string,string> GetInsertString(Type type)
            {
                string s1 = "",s2="";
                foreach (PropertyInfo t in type.GetProperties())
                {
                    if (t.Name == "ID") continue;
                    s1 += t.Name + ",";
                    s2 += "@" + t.Name + ",";
                }
                return Tuple.Create<string, string>(s1.TrimEnd(','), s2.TrimEnd(','));
            }
            static string GetUpdateString(Type type)
            {
                string s = "";
                foreach (PropertyInfo info in type.GetProperties())
                {
                    if(info.Name!="ID")
                    s += info.Name + "=@" + info.Name + ",";
                }
                s=s.TrimEnd(',');
                //s += " where ID=@ID";
                return s;
            }
            public static SqlParameter[] GetParameterArray<T>(ActionType action,T instance)
            {
                Type type = instance.GetType();
                List<SqlParameter> listParameter = new List<SqlParameter>();
                SqlParameter idParameter=new SqlParameter();
                foreach (PropertyInfo info in type.GetProperties())
                {
                    if(info.Name!="ID")
                        listParameter.Add(new SqlParameter() {ParameterName="@"+info.Name, Value = info.GetValue(instance) });
                    else
                    {
                        idParameter.Value=info.GetValue(instance);
                        idParameter.ParameterName="@"+info.Name;
                    }
                }
                if (action == ActionType.Update)
                {
                    listParameter.Add(idParameter);
                }
                return listParameter.ToArray();
            }
    }
}