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
            set { Session["User"] = value; }
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
    }
}