using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XkAarticle.Test;

namespace XkAarticle.Administrate.Verify
{
    public partial class FrmQueryArticle:AbstractForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var articleBLL = new ArticleBLL();
                var list = articleBLL.GetAll(new Article(), "enabled=1");
                ArticleGridView.DataSource = list;
                ArticleGridView.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string wherestring = "";
            for (int i = 0; i < ArticleGridView.Rows.Count-1; i++)
            {
                CheckBox cbox =(CheckBox) ArticleGridView.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked)
                {
                    wherestring += ArticleGridView.DataKeys[i].Value+",";
                }
            }
            if (wherestring.Length > 0)
            {
                wherestring = wherestring.TrimEnd(',');
                wherestring = "ID in(" + wherestring + ")";
                ArticleBLL articleBLL = new ArticleBLL();
                var result=  articleBLL.Delete(new Article(), wherestring);
                if (result)
                {
                    Label1.Text = "删除成功";
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string wherestring = "";
            for (int i = 0; i < ArticleGridView.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)ArticleGridView.Rows[i].FindControl("ChkItem");
                if (cbox.Checked)
                {
                    wherestring += ArticleGridView.DataKeys[i].Value + ",";
                }
            }
            if (wherestring.Length > 0)
            {
                wherestring = wherestring.TrimEnd(',');
                wherestring = "and ID in(" + wherestring + ")";
                ArticleBLL articleBLL = new ArticleBLL();
                var result = articleBLL.UpdateByCommandString("update XK_Article set Enabled=1 where 1=1 ",wherestring );
                if (result>0)
                {
                    Label1.Text = "审核成功";
                }
            }
        }
    }
}