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
       
        protected override bool CheckExist(Role instance)
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
        
    }
}
