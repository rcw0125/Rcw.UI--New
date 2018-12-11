using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcw.Data
{
    interface ISetterValue
    {
        void SetValue(DbEntity item, int col);
    }
}
