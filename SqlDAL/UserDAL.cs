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
    public class UserDAL:IUser
    {
        private void ConvertToList(List<User> tablist,DataSet ds)
        {
            var table1 = ds.Tables[0];
            foreach (DataRow row in table1.Rows)
            {
                User admin = new User();
                Type t = admin.GetType();
                object val = null;
                foreach (var prop in t.GetProperties())
                {
                    val = row[prop.Name];
                    prop.SetValue(admin, val);
                }
                tablist.Add(admin);
            }
        }





        public User Login(string LoginName, string Password)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                var ds = SqlHelper.ExecuteDataset(conn, System.Data.CommandType.Text, string.Format("select * from XK_User where 1=1 and Name='{0}' and Pass='{1}'",LoginName,Password));
                var tablist = new List<User>();
                ConvertToList(tablist, ds);
                return tablist.Count > 0 ? tablist[0] : null;
            }
        }

        public bool Insert(User instance)
        {
            string commandString = Utility.GetOperationStringBy<User>(Action.Update, instance);
            SqlParameter[] parameters = Utility.GetParameterArray<User>(Action.Update, instance);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
            return result > 0;
        }

        public bool Delete(User instance)
        {
            string commandString=Utility.GetOperationStringBy<User>(Action.Delete,instance);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, new SqlParameter {SqlDbType=SqlDbType.Int, Value=instance.ID });
            return result > 0;
        }

        public bool Update(User instance)
        {
            string commandString = Utility.GetOperationStringBy<User>(Action.Update, instance);
            SqlParameter[] parameters = Utility.GetParameterArray<User>(Action.Update, instance);
            var result = SqlHelper.ExecuteNonQuery(Utility.SqlServerConnectionString, CommandType.Text, commandString, parameters);
            return result > 0;
        }

        public List<User> GetAll(string WhereString)
        {
            using (SqlConnection conn = new SqlConnection(Utility.SqlServerConnectionString))
            {
                conn.Open();
                var ds = SqlHelper.ExecuteDataset(conn, System.Data.CommandType.Text, "select * from XK_User where 1=1 and "+WhereString);
                var tablist = new List<User>();
                ConvertToList(tablist, ds);
                return tablist;
            }
        }

        public bool Convert(IList<User> Target, DataSet Source)
        {
            var table1 = Source.Tables[0];
            foreach (DataRow row in table1.Rows)
            {
                User admin = new User();
                Type t = admin.GetType();
                object val = null;
                foreach (var prop in t.GetProperties())
                {
                    val = row[prop.Name];
                    prop.SetValue(admin, val);
                }
                Target.Add(admin);
            }
            return Target.Count==Source.Tables[0].Rows.Count;
        }


        public User GetOneByID(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
