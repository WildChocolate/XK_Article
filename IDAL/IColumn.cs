﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    [ImplementFlag("ColumnDAL")]
    public interface IColumn:IBaseOperation<Column>
    {
    }
}
