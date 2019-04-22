using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Association_PAT_Ukrzaliznutsa.UkrzaliznytsaServerServise
{
    class Locomotive
    {
        private UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities;
        public Locomotive()
        {
            ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            Trace.WriteLine(this);
        }

        public void setLocomotive(string Name, string Type, string Velocity, string PowerEngin, string information, byte[] pdf, byte[] photo)
        {
            LokomotiveSet lokomotive = new LokomotiveSet
            {
                Name = Name,
                Type = Type,
                Velocity = Velocity,
                PowerEngin = PowerEngin,
                Information = information,
                PDF = pdf,
                Photo = photo
            };
            ukrzaliznutsaDBEntities.LokomotiveSet.Add(lokomotive);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        public byte[] getLocomotive()
        {
            List<TypeLocomotiveSet> lokomotives;
            lokomotives = ukrzaliznutsaDBEntities.TypeLocomotiveSet.ToList();
            byte[] array = new byte[lokomotives.Count];
            for (int i = 0; i < lokomotives.Count; i++)
            {
                array = Encoding.Default.GetBytes(lokomotives[i].ToString());
            }

            return array;
        }

        public void setLocomotiveType(string type)
        {
            TypeLocomotiveSet typeLocomotive = new TypeLocomotiveSet
            {
                Type = type
            };
            ukrzaliznutsaDBEntities.TypeLocomotiveSet.Add(typeLocomotive);
            ukrzaliznutsaDBEntities.SaveChanges();
        }
    }
}
