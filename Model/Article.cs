using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Article:tblBase
    {
        public int ColumnID { get; set; }
        public string Title { get; set; }
        public int Author { get; set; }
        public DateTime PostDate { get; set; }
        public int IsPic { get; set; }
        public string PicUrl { get; set; }
        public string Body { get; set; }
        public bool Enabled
        {
            get;
            set;
        }
        public DateTime? PublishTime
        {
            get;
            set;
        }
    }
}
