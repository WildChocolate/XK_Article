using SqlDAL;
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
    public partial class ArticleContent : AbstractForm
    {
        
        ActionType? ActionsType
        {
            get { return ViewState["ActionType"] as ActionType?; }
            set { ViewState["ActionType"] = value; }
        }
        Article CurrentArticle
        {
            get { return ViewState["CurrentArticle"] as Article; }
            set { ViewState["CurrentArticle"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ColumnsBind();
                string ArticleID = Request["ArticleID"] + "";
                hidArticleID.Value = ArticleID;
                if (ArticleID.Length > 0)
                {
                    ActionsType = ActionType.Update;
                    ArticleBLL articleBLL = new ArticleBLL();
                    CurrentArticle=new Article ();
                    CurrentArticle=articleBLL.GetOneByID(CurrentArticle, int.Parse(ArticleID));
                    txtTitle.Text = CurrentArticle.Title;
                    TxtContent.Text = CurrentArticle.Body;
                }
                else{
                    ActionsType = ActionType.Insert;
                    CurrentArticle = new Article();
                    txtTitle.Text = "";
                    TxtContent.Text = "";
                }
            }
        }
        void ColumnsBind()
        {
            ColumnBLL columnBLL = new ColumnBLL();
            string command = "select ID,Title from XK_Column where 1=1 ";
            var Columns= columnBLL.GetDataByCommandString(command,string.Empty);
            ddlColumns.DataValueField = "ID";
            ddlColumns.DataTextField = "Title";
            ddlColumns.DataSource = Columns;
            ddlColumns.DataBind();
        }
        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            ArticleBLL articleBLL = new ArticleBLL();
            if (ActionsType == ActionType.Insert)
            {
                CurrentArticle.Author = LoginUser.ID;
                CurrentArticle.Body = TxtContent.Text;
                CurrentArticle.PublishTime = null;
                CurrentArticle.IsPic = 0;
                CurrentArticle.Enabled = true ;
                CurrentArticle.PostDate = DateTime.Now;
                CurrentArticle.Title = txtTitle.Text;
                CurrentArticle.ColumnID = Convert.ToInt32(ddlColumns.SelectedValue);
                var result=articleBLL.Insert(CurrentArticle);
                if (result>0)
                {
                    lbTips.Text = "发布成功！！！";
                }
                else if (result == -1)
                {
                    lbTips.Text = "出现错误，发布失败";
                }
                else if (result == -2)
                {
                    lbTips.Text = "已存在的文章";
                }
            }
            else
            {
                CurrentArticle.Body = TxtContent.Text;
                CurrentArticle.Title = txtTitle.Text;
                CurrentArticle.ColumnID = int.Parse(ddlColumns.SelectedValue);
                CurrentArticle.PublishTime = DateTime.Now;
                var result= articleBLL.Update(CurrentArticle,"ID="+CurrentArticle.ID);
                if (result)
                {
                    lbTips.Text = "更新成功";
                }
                else
                {
                    lbTips.Text = "更新失败";
                }
            }
        }
    }
}