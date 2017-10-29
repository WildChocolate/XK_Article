using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class FriendlyLink:tblBase
    {
        
        public string Title { get; set; }
        public int IsPic { get; set; }
        public string PicUrl { get; set; }
        public string SiteUrl { get; set; }
        public int Sort { get; set; }   

    }
}
