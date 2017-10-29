using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    /// <summary>
    /// 定义了其它实体类（实体产品）均有的一些公共方法，如转换，所有的实体产品都继承此类，以获得通用方法。
    /// </summary>
    /// <typeparam name="T">具体的模型类，定义自model</typeparam>
    public abstract class AbBase<T> where T:tblBase,new ()
    {
        protected List<T> ConvertToList( DataSet ds)
        {
            var table1 = ds.Tables[0];
            List<T> tablist = new List<T>();
            var ColumnNames=new List<string>();
            foreach (DataColumn i in table1.Columns)
            {
                ColumnNames.Add(i.ColumnName);
            }
            foreach (DataRow row in table1.Rows)
            {
                T admin = new T();
                Type t = admin.GetType();
                object val = null;
                    foreach (var Name in ColumnNames)
                    {
                            var prop = t.GetProperty(Name);
                            val = row[prop.Name];
                            prop.SetValue(admin, ConvertTypeToValue(prop,val));
                    }
                tablist.Add(admin);
            }
            return tablist;
        }
        protected T ConvertToInstance(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    T instance = new T();
                    Type t = instance.GetType();
                    object val = null;
                    foreach (var prop in t.GetProperties())
                    {
                        val = reader[prop.Name];
                        prop.SetValue(instance, ConvertTypeToValue(prop, val));
                    }
                    return instance;
                }
                reader.Dispose();
                reader.Close();
            }
            return null;
        }
        object ConvertTypeToValue(PropertyInfo prop,object val)
        {
            var TypeName = prop.PropertyType.Name;
            //对是否泛型nullable 进行判断
            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (val == DBNull.Value)
                        return null;
                //获取 此nullable的根类型
                var nullableType= prop.PropertyType.GetGenericArguments()[0];
                //如果为nullable类型且为 datetime， 根据传入值进行转换
                if (nullableType.Name.Contains("Date"))
                {
                        return Convert.ToDateTime(val);
                }
                else
                    return Convert.ToString(val);
            }
            else if (TypeName.Contains("Int"))
            {
                return Convert.ToInt32(val);
            }
            else if (TypeName.Contains("Date")) {
                if (DBNull.Value == val) return null;
                return Convert.ToDateTime(val);
            }
            else if (TypeName.Equals("Boolean"))
            {
                return Convert.ToBoolean(val);
            }
            else return Convert.ToString(val);
        }
       
        public T GetOneByID(T instance,int id)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                string commandString = Utility.GetOperationStringBy<T>(ActionType.Select, instance, " ID=@ID");
                var param=new SqlParameter();
                param.ParameterName="@ID";
                param.Value=id;
                param.SqlDbType=SqlDbType.Int;
                var dr = SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text,commandString,param);
                T obj = ConvertToInstance(dr);
                return obj;
            }
        }
        protected abstract bool CheckExist(T instance);
        
        public virtual int Insert(T instance)
        {
            string commandString = Utility.GetOperationStringBy<T>(ActionType.Insert, instance);
            SqlParameter[] parameters = Utility.GetParameterArray<T>(ActionType.Insert, instance);
            try
            {
                if (CheckExist(instance)) return -2;
                var result = SqlHelper.ExecuteScalar(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
                return Convert.ToInt32(result);
            }
            catch
            {
                return -1;
            }
        }
        public bool Delete(T instance, string WhereString)
        {
            string commandString = Utility.GetOperationStringBy<T>(ActionType.Delete, instance, WhereString);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, new SqlParameter { SqlDbType = SqlDbType.Int, Value = instance.ID });
            return result > 0;
        }
        public bool Update(T instance, string WhereString)
        {
            string commandString = Utility.GetOperationStringBy<T>(ActionType.Update, instance, WhereString);
            SqlParameter[] parameters = Utility.GetParameterArray<T>(ActionType.Update, instance);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
            return result > 0;
        }
        public List<T> GetAll(T instance, string WhereString)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                string commandString = Utility.GetOperationStringBy<T>(ActionType.Select, instance, WhereString);
                var ds = SqlHelper.ExecuteDataset(conn, System.Data.CommandType.Text, commandString);
                var tablist = ConvertToList(ds);
                return tablist;
            }
        }
        public T GetOneByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                var dr = SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text, "select top 1 * from XK_User where ID=@ID ");
                T instance = ConvertToInstance(dr);
                return instance;
            }
        }
        public  List<T> GetDataByCommandString(string Command,string WhereString )
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                if (WhereString != "")
                {
                    CultureInfo ci = new CultureInfo("zh-cn");
                    WhereString = (WhereString.Trim().StartsWith("and", true,ci))?WhereString:" and "+WhereString ;
                }
                string commandString = Command + WhereString;
                var ds = SqlHelper.ExecuteDataset(conn, System.Data.CommandType.Text, commandString);
                var tablist = ConvertToList(ds);
                return tablist;
            }
        }
        public int UpdateByCommandString(string Command, string WhereString)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                if (WhereString != "")
                {
                    CultureInfo ci = new CultureInfo("zh-cn");
                    WhereString = (WhereString.Trim().StartsWith("and", true, ci)) ? WhereString : " and " + WhereString;
                }
                string commandString = Command + WhereString;
                var result = SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, commandString);
                return result;
            }
        }
    }
}
