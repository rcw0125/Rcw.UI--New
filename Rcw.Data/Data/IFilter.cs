using System.Collections.Generic;

namespace Rcw.Data
{
   public interface IFilter
    {
        void Filter(Dictionary<string, string> para);
    }
}
