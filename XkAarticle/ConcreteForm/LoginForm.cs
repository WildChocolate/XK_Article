using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XkAarticle.ConcreteForm
{
    public class LoginForm:AbstractForm
    {

        public override Model.User user
        {
            get
            {
                return Session["User"] as Model.User;
            }
            set
            {
                Session["User"] = value;
            }
        }
    }
}