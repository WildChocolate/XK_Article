using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article:tblBase
    {
        public int ColumnID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public int IsPic { get; set; }
        public string PicUrl { get; set; }
        public string Body { get; set; }
    }
}
