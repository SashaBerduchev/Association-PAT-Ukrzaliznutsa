using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Association_PAT_Ukrzaliznutsa
{
    public partial class OrderSet
    {
        public override string ToString()
        {
            return $"{User}, {Number}, {ContragentFrom}, {PointStart}, {ContragentTo},  {PointEnd}, {TypeVagon}, {PriceOfOrder}, {Photo}, {OrderPhoto}, {InformationOfOrder}, {Marshrute}";
        }
    }
}
