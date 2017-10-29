using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Notice:tblBase
    {
        
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string Body { get; set; }
    }
}
