using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Role:tblBase
    {
        
        public string Name { get; set; }
        public string AdminSetting { get; set; }
        public string Setting { get; set; }

    }
}
