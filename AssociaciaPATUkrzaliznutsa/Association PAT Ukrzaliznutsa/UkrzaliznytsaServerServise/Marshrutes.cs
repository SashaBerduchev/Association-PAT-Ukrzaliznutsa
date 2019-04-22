using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Association_PAT_Ukrzaliznutsa.UkrzaliznytsaServerServise
{
    class Marshrutes
    {
        private List<MarshrutesSet> marshrutes;
        private List<string> marshdata;
        private UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities;
        public Marshrutes()
        {
            ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            Trace.WriteLine(this);
        }
        
        public List<string> getMarshrutes()
        {
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            marshdata = marshrutes.AsParallel().Select(x => x.NumberTrain + " " + x.Locomotive + " " + x.PointStart + " " + x.PointEnd + " " + x.TypeLocomotive + " " + x.TypeTrain + " " + x.TypeVagon).ToList();
            //marshdata = marshdata.Take(10).ToList();
            return marshdata;
        }
    }
}
