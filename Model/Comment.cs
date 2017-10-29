using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Comment:tblBase
    {
        public string ArticleID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string Body { get; set; }
    }
}
