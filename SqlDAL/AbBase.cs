using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    /// <summary>
    /// 定义了其它实体类（实体产品）均有的一些公共方法，如转换，所有的实体产品都继承此类，以获得通用方法。
    /// </summary>
    /// <typeparam name="T">具体的模型类，定义自model</typeparam>
    public abstract class AbBase<T> where T:class,new()
    {
        protected List<T> ConvertToList( DataSet ds)
        {
            var table1 = ds.Tables[0];
            List<T> tablist = new List<T>();
            foreach (DataRow row in table1.Rows)
            {
                T admin = new T();
                Type t = admin.GetType();
                object val = null;
                foreach (var prop in t.GetProperties())
                {
                    val = row[prop.Name];
                    prop.SetValue(admin, val);
                }
                tablist.Add(admin);
            }
            return tablist;
        }
        protected T ConvertToInstance( SqlDataReader reader)
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
                        prop.SetValue(instance, val);
                    }
                    return instance;
                }
                reader.Dispose();
                reader.Close();
            }
            return null;
        }
        public T GetOneByID(T instance,int id)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                string commandString = Utility.GetOperationStringBy<T>(ActionType.Select, instance, " where ID=@ID");
                var param=new SqlParameter();
                param.ParameterName="@ID";
                param.Value=id;
                param.SqlDbType=SqlDbType.Int;
                var dr = SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text,commandString,param);
                T obj = ConvertToInstance(dr);
                return obj;
            }
        }
    }
}
