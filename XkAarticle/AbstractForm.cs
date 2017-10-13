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
        public abstract User LoginUser
        {
            get;
            set;
        }
    }
}