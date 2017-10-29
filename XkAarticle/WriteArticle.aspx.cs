using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace XkAarticle
{
    public partial class WriteArticle : AbstractForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindArticle();
        }
        void BindArticle()
        {
            var ArticleBLL = new ArticleBLL();
            var list = ArticleBLL.GetAll(new Article(), "Enabled=0 and Author="+LoginUser.ID);
            ArticleReapter.DataSource = list;
            ArticleReapter.DataBind();
        }
    }
}