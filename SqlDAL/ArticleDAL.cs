using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public class ArticleDAL:AbBase<Article>,IArticle
    {

        protected override bool CheckExist(Article instance)
        {
            throw new NotImplementedException();
        }
    }
}
