using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Association_PAT_Ukrzaliznutsa
{
    public partial class TrainsInfoSet
    {
        public override string ToString()
        {
            return $"{Number}, {Locomotive}, {TypeLocomotive}, {TypeVagon}, {Length}, {LocomotivePowerEngine}";
        }
    }
}
