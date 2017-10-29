using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Column:tblBase
    {
        
        public string Title { get; set; }
        public string Code { get; set; }
        public string ParentColumn { get; set; }
    }
}
