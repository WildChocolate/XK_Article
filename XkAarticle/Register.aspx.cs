using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data.SqlClient;
using SqlDAL;

namespace XkAarticle
{
    public partial class Register : System.Web.UI.Page,ICallbackEventHandler
    {
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetRandom是方法名, 不需要括号()
            string reference = Page.ClientScript.GetCallbackEventReference(this, "arg", "GetRandom", "content");
            string myScript = @"function UseCallBack(arg,content)" + "{" + reference + ";" + "}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", myScript, true);
            
        }
        protected virtual void GotoPage(string Page)
        {
            Response.Redirect(Page, true);
        }
        protected virtual void RunScript(string script, string key = "myscript")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), key, "<script>" + script + "</script>", false);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (password.Value != confirm.Value)
            { 
                lbTip.Text = "两次输入的密码须相同！！！";
                return;
            }
            UserBLL userBll = new UserBLL();
            User user = new User();
            user.Name = account.Value;
            user.Pass = password.Value;
            user.RoleID = 3;
            var result=userBll.Insert(user);
            if (result>0)
            {
                lbTip.Text = "注册成功,用户ID="+result;
                AvatarBLL avatarBLL = new AvatarBLL();
                Avatar instance = new Avatar();
                instance.UserID = result;
                instance.AvatarUrl = UpImg();
                var isUp=  avatarBLL.Insert(instance);
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "Jump", "IntervalJumptoLogin();",true);
            }
            else if( result ==-1)
            {
                lbTip.Text = "注册失败！！！";
            }
            else
            {
                lbTip.Text = "此用户名已存在！！！";
            }
        }

        private string _callbackResult = null;
        public string GetCallbackResult()
        {
            return "返回值";
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }
         private string UpImg()
         {
             string constr = Utility.SqlServerConnectionString;
             con = new SqlConnection(constr);
             var path = Server.MapPath("~/Img/") + this.FileUpload1.FileName;
             if (this.FileUpload1.HasFile)
             {
                 if (this.FileUpload1.PostedFile.ContentLength < 10485760)
                 {
                     try
                     {

                         //上传文件并指定上传目录的路径     
                         this.FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Img/")
                             + this.FileUpload1.FileName);
                         /*注意->这里为什么不是:FileUpLoad1.PostedFile.FileName   
                         * 而是:FileUpLoad1.FileName?   
                         * 前者是获得客户端完整限定(客户端完整路径)名称   
                         * 后者FileUpLoad1.FileName只获得文件名.   
                         */

                         //当然上传语句也可以这样写(貌似废话):     
                         //FileUpLoad1.SaveAs(@"D:\"+FileUpLoad1.FileName);     

                         this.lbTip.Text = "上传成功!";
                         //string sql = string.Format("insert into Avatar values('{0}','{1}')");
                         //SqlCommand cmd = con.CreateCommand();
                         //cmd.CommandText = sql;
                         //con.Open();
                         //SqlTransaction tran = con.BeginTransaction();
                         //cmd.Transaction = tran;
                         //int i = 0;
                         try
                         {
                             //i = cmd.ExecuteNonQuery();
                             //tran.Commit();
                             this.Image1.ImageUrl = "Img/"+FileUpload1.FileName;
                         }
                         catch (Exception ex)
                         {
                             //tran.Rollback();
                             path = "";
                         }
                         finally
                         {
                             con.Close();
                         }
                         
                     }
                     catch (Exception ex)
                     {
                         this.lbTip.Text = "出现异常,无法上传!" + ex.Message;
                         //lblMessage.Text += ex.Message;
                         path = "";
                     }
                 }
                 else
                 {
                     this.lbTip.Text = "上传文件不能大于10MB!";
                     path = "";
                 }
             }
             else
             {
                 this.lbTip.Text = "尚未选择文件!";
                 path = "";
             }
             return path;
         }
    }
}