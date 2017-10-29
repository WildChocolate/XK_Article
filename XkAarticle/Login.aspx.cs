using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace XkAarticle
{
    public partial class Login : AbstractForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_ServerClick(object sender, EventArgs e)
        {
            string LoginName = logname.Value;
            string Password = logpass.Value;
            UserBLL userBLL = new UserBLL();
            var user = userBLL.Login(LoginName,Password);
            LoginUser = user;
            if (user != null) GotoPage("Main.aspx");
            else { TipsLabel.Text = "帐号或密码错误！！！"; }
        }

        protected void Register_ServerClick(object sender, EventArgs e)
        {
            GotoPage("Register.aspx");
        }
    }
}