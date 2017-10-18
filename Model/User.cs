using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:tblBase
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public int RoleID { get; set; } 
    }
}
