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
    public class ArticleDAL:AbBase<Article>,IArticle
    {

        protected override bool CheckExist(Article instance)
        {
            string commandString = Utility.GetOperationStringBy<Article>(ActionType.Select, instance, " where 1=1 and [Title]=@Title and ColumnID=@ColumnID");
            
            SqlParameter[] paramList = new SqlParameter[]{
                new SqlParameter("@Title",instance.Title),
                new SqlParameter("@ColumnID",instance.ColumnID) 
            };
            try
            {
                var result = (int)SqlHelper.ExecuteScalar(Utility.SqlServerConnectionString, CommandType.Text, commandString, paramList);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
