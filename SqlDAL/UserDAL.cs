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
    /// user表的具体产品
    /// </summary>
    public class UserDAL:AbBase<User>,IUser
    {
        public User Login(string LoginName, string Password)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                var ds = SqlHelper.ExecuteDataset(conn, System.Data.CommandType.Text, string.Format("select * from XK_User where 1=1 and Name='{0}' and Pass='{1}'",LoginName,Password));
                var tablist = ConvertToList( ds);
                return tablist.Count > 0 ? tablist[0] : null;
            }
        }
        private bool CheckExist(User instance)
        {
            string commandString = Utility.GetOperationStringBy<User>(ActionType.Select, instance," where 1=1 and [Name]=@Name")  ;
            SqlParameter param = new SqlParameter( );
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
        public int Insert(User instance)
        {
            string commandString = Utility.GetOperationStringBy<User>(ActionType.Insert, instance);
            SqlParameter[] parameters = Utility.GetParameterArray<User>(ActionType.Insert, instance);
            try
            {
                if (CheckExist(instance)) return -2;
                var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
                return result ;
            }
            catch
            {
                return -1;
            }
        }

        public bool Delete(User instance,string WhereString)
        {
            string commandString=Utility.GetOperationStringBy<User>(ActionType.Delete,instance,WhereString);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, new SqlParameter {SqlDbType=SqlDbType.Int, Value=instance.ID });
            return result > 0;
        }

        public bool Update(User instance,string WhereString)
        {
            string commandString = Utility.GetOperationStringBy<User>(ActionType.Update, instance,WhereString);
            SqlParameter[] parameters = Utility.GetParameterArray<User>(ActionType.Update, instance);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
            return result > 0;
        }

        public List<User> GetAll(User instance,string WhereString)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                string commandString = Utility.GetOperationStringBy<User>(ActionType.Select, instance, WhereString);
                var ds = SqlHelper.ExecuteDataset(conn, System.Data.CommandType.Text, commandString);
                var tablist = ConvertToList(ds);
                return tablist;
            }
        }
        
        public User GetOneByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                var dr = SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text, "select top 1 * from XK_User where ID=@ID " );
                User user = ConvertToInstance(dr);
                return user;
            }
        }


        
    }
}
