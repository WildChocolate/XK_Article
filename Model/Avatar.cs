using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Avatar:tblBase
    {
        public int UserID { get; set; }
        public string AvatarUrl
        {
            get;
            set;
        }
    }
}
