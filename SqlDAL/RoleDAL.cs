using IDAL;
using Model;
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
    /// 角色表的具体产品
    /// </summary>
    public class RoleDAL:AbBase<Role>,IRole
    {
        public int Insert(Role instance)
        {
            string commandString = Utility.GetOperationStringBy<Role>(ActionType.Insert, instance);
            SqlParameter[] parameters = Utility.GetParameterArray<Role>(ActionType.Insert, instance);
            try
            {
                if (CheckExist(instance)) return -2;
                var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
                return result;
            }
            catch
            {
                return -1;
            }
        }
        private bool CheckExist(Role instance)
        {
            string commandString = Utility.GetOperationStringBy<Role>(ActionType.Select, instance) + " where 1=1 and [Name]=@Name";
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Name";
            param.Value = instance.Name;
            try
            {
                var result = (int)SqlHelper.ExecuteScalar(Utility.SqlServerConnectionString, CommandType.Text, commandString, param);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Role instance,string WhereString)
        {
            string commandString = Utility.GetOperationStringBy<Role>(ActionType.Delete, instance,WhereString);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, new SqlParameter { SqlDbType = SqlDbType.Int, Value = instance.ID });
            return result > 0;
        }

        public bool Update(Role instance,string WhereString)
        {
            string commandString = Utility.GetOperationStringBy<Role>(ActionType.Update, instance,WhereString);
            SqlParameter[] parameters = Utility.GetParameterArray<Role>(ActionType.Update, instance);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
            return result > 0;
        }

        public List<Role> GetAll(Role instance,string WhereString)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                string commandString = Utility.GetOperationStringBy<Role>(ActionType.Select, instance,WhereString);
                var ds = SqlHelper.ExecuteDataset(conn, System.Data.CommandType.Text, commandString);
                var tablist = ConvertToList(ds);
                return tablist;
            }
        }
    }
}
