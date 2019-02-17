using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Association_PAT_Ukrzaliznutsa
{
    public partial class LokomotiveSet
    {
        public override string ToString()
        {
            return $"{Name}, {Type}, {Velocity}, {PowerEngin}";
        }
    }
}
