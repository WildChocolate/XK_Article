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
    public partial class Main : AbstractForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindColumnList();
            BindArticleList();
            CheckRole();
        }

        private void CheckRole()
        {
            var roleBLL = new RoleBLL();
            var role= roleBLL.GetOneByID(new Role(),LoginUser.RoleID);
            if (!role.Name.Contains("Admin"))
            {
                string script = @"(function(){ 
                                             
                                              var manager= document.getElementById('Manager');
                                              manager.style.display='none';
                                            })();";
                RunScript(script);
            }
        }
        void BindArticleList() {
            var bll = new ArticleBLL();
            var list = bll.GetAll(new Article(), "enabled=1 and Author="+LoginUser.ID);
            ArticleReapter.DataSource = list;
            ArticleReapter.DataBind();
        }
        void BindColumnList()
        {
            var bll = new ColumnBLL();
            var list = bll.GetAll(new Column(),"");
            ColumnList.DataSource = list;
            ColumnList.DataBind();
        }
    }
}