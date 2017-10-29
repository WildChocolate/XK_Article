using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace XkAarticle
{
    public abstract class AbstractForm:Page
    {
        public virtual User LoginUser
        {
            get { return Session["User"] as User; }
            set
            {
                Session["User"] = value; 
                Session.Timeout = 20; 
            }
        }
        protected override void OnInit(EventArgs e)
        {
            var type = this.GetType();
            if (!type.Name.ToUpper().Contains("LOGIN"))
            {
                if (LoginCheck()) GotoPage("Login.aspx");
            }
            base.OnInit(e);
        }
        protected bool LoginCheck()
        {
            return LoginUser==null;
        }
        protected virtual void GotoPage(string Page)
        {
            Response.Redirect(Page,true);
        }
        protected virtual void RunScript(string script,string key="myscript")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), null, "<script>"+script+"</script>",false);
        }
    }
}