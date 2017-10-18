using Factory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticleBLL:BaseBLL<Article>
    {
        IArticle ArticleDAL = ActiveProductGeter.CreateProduct<IArticle>();
        protected override IDAL.IBaseOperation<Article> ConcreteDAL
        {
            get { return ArticleDAL; }
        }
    }
}
