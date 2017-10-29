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

    public class AvatarDAL:AbBase<Avatar>,IAvatar
    {
        protected override bool CheckExist(Avatar instance)
        {
            string commandString = Utility.GetOperationStringBy<Avatar>(ActionType.Select, instance, " where 1=1 and [UserID]=@UserID");
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID";
            param.Value = instance.UserID;
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
        public override int Insert(Avatar instance)
        {
            return base.Insert(instance);
        }
    }
}
