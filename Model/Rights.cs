﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Rights : tblBase
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
    }
}
