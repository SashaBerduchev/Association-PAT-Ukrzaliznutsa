using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Association_PAT_Ukrzaliznutsa
{
    public partial class MarshrutesSet
    {
        public override string ToString()
        {
            return $"{NumberTrain}, {PointStart}, {PointEnd}, {TypeTrain}, {TypeLocomotive}, {Locomotive}, {Photo}, {PDF}";
        }
    }
}
