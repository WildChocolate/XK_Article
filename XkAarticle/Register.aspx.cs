using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace XkAarticle
{
    public partial class Register : System.Web.UI.Page,ICallbackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetRandom是方法名, 不需要括号()
            string reference = Page.ClientScript.GetCallbackEventReference(this, "arg", "GetRandom", "content");
            string myScript = @"function UseCallBack(arg,content)" + "{" + reference + ";" + "}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", myScript, true);
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
                lbTip.Text = "注册成功";
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
            return _callbackResult;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            Random random = new Random();
            _callbackResult = random.Next().ToString();
        }
    }
}