using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Association_PAT_Ukrzaliznutsa
{
    public partial class ProdactionSet
    {
        public override string ToString()
        {
            return $"{ProdactionName}, {ProdactionCount}, {ProdactionCost}";
        }
    }
}
