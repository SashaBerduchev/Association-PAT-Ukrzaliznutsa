using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Association_PAT_Ukrzaliznutsa.UkrzaliznytsaServerServise
{
    class NaselenuyPunkt
    {
        private UkrzaliznutsaDBEntities ukrzaliznutsa;
        public void setNaselenuyPunkt(string namepunkt)
        {
            ukrzaliznutsa = new UkrzaliznutsaDBEntities();
            NaselennuyPunktSet naselennuyPunkt = new NaselennuyPunktSet
            {
                NamePunkt = namepunkt
            };
            ukrzaliznutsa.NaselennuyPunktSet.Add(naselennuyPunkt);
            ukrzaliznutsa.SaveChanges();
            Trace.Write(this);
        }

        public byte[] getNaselenuyPunkt()
        {
            ukrzaliznutsa = new UkrzaliznutsaDBEntities();
            List<NaselennuyPunktSet> naselennuyPunkts;
            naselennuyPunkts = ukrzaliznutsa.NaselennuyPunktSet.ToList();
            byte[] array = new byte[naselennuyPunkts.Count];
            for (int i = 0; i < naselennuyPunkts.Count; i++)
            {
                array = Encoding.Default.GetBytes(naselennuyPunkts[i].ToString());
            }
            Trace.Write(this);
            return array;
        }
    }
}
