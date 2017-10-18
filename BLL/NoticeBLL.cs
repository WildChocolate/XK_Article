using Factory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NoticeBLL:BaseBLL<Notice>
    {
        INotice NoticeDAL = ActiveProductGeter.CreateProduct<INotice>();
        protected override IDAL.IBaseOperation<Notice> ConcreteDAL
        {
            get { return NoticeDAL; }
        }
    }
}
