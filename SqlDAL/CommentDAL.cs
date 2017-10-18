using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public class NoticeDAL : AbBase<Notice>, INotice
    {

        protected override bool CheckExist(Notice instance)
        {
            throw new NotImplementedException();
        }

        
    }
}
