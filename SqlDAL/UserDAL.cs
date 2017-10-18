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
        protected override bool CheckExist(User instance)
        {
            string commandString = Utility.GetOperationStringBy<User>(ActionType.Select, instance," where 1=1 and [Name]=@Name")  ;
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
        
    }
}
