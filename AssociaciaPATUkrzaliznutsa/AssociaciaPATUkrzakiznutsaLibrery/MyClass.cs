using Association_PAT_Ukrzaliznutsa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociaciaPATUkrzakiznutsaLibrery
{
    public class MyClass : IMyClass
    {
        UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
        List<ProdactionSet> prodactions;
        List<MarshrutesSet> marshrutes;
        List<OrderSet> orders;
        public void AddNaselenPunkt(string namepunkt)
        {
            NaselennuyPunktSet naselennuyPunkt = new NaselennuyPunktSet
            {
                NamePunkt = namepunkt
            };
            ukrzaliznutsaDBEntities.NaselennuyPunktSet.Add(naselennuyPunkt);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        public byte[] LoadNaselenPunkt()
        {
            List<NaselennuyPunktSet> naselennuyPunkts;
            naselennuyPunkts = ukrzaliznutsaDBEntities.NaselennuyPunktSet.ToList();
            byte[] array = new byte[naselennuyPunkts.Count];
            for (int i = 0; i < naselennuyPunkts.Count; i++)
            {
                array = Encoding.Default.GetBytes(naselennuyPunkts[i].ToString());
            }

            return array;
        }

        public void setLocomotiveinfo(string Name, string Type, string Velocity, string PowerEngin, string information, byte[] pdf, byte[] photo)
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

        public byte[] getTypeLocomotive()
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

        public List<string> getMarshruteData()
        {
            List<string> marshdata;
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            marshdata = marshrutes.AsParallel().Select(x => x.NumberTrain + " " + x.Locomotive + " " + x.PointStart + " " + x.PointEnd).ToList();
            return marshdata;
        }
        public void setUserLogin(string login, string pass)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            UsersSet users = new UsersSet
            {
                Name = login,
                Password = pass
            };
            ukrzaliznutsaDBEntities.UsersSet.Add(users);
            ukrzaliznutsaDBEntities.SaveChanges();
        }
        public string[] getMailAddress()
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<MailSet> mails;
            mails = ukrzaliznutsaDBEntities.MailSet.ToList();
            return mails.AsParallel().Select(x => x.MailName).ToArray();
        }




        public string[] getUser()
        {
            List<UsersSet> users;
            users = ukrzaliznutsaDBEntities.UsersSet.ToList();
            return users.AsParallel().Select(x => x.Name).ToArray();
        }

        public string[] getNumber()
        {
            List<MarshrutesSet> marshrutes;
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            return marshrutes.AsParallel().Select(x => x.NumberTrain).ToArray();
        }

        public string[] getPointStart()
        {
            List<MarshrutesSet> marshrutes;
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            return marshrutes.AsParallel().Select(x => x.PointStart).ToArray();
        }


        public string[] getPointEnd()
        {
            List<MarshrutesSet> marshrutes;
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            return marshrutes.AsParallel().Select(x => x.PointEnd).ToArray();
        }

        public string[] getTypeVagon()
        {
            List<TrainsInfoSet> trains;
            trains = ukrzaliznutsaDBEntities.TrainsInfoSet.ToList();
            return trains.AsParallel().Select(x => x.TypeVagon).ToArray();
        }

        public void setProdact(string prodactionname, string prodactioncount, string prodactioncost)
        {
            ProdactionSet prodaction = new ProdactionSet
            {
                ProdactionName = prodactionname,
                ProdactionCount = prodactioncount,
                ProdactionCost = prodactioncost
            };
            ukrzaliznutsaDBEntities.ProdactionSet.Add(prodaction);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        public string[] getProdaction()
        {
            string[] arraydata;
            prodactions = ukrzaliznutsaDBEntities.ProdactionSet.ToList();
            arraydata = prodactions.AsParallel().Select(x => x.ProdactionName).ToArray();
            return arraydata;
        }

        public void setContragent(string namecontragent, string prodaction, string vagon, string user)
        {
            KlientsSet klients = new KlientsSet
            {
                NameKlient = namecontragent,
                Prodaction = prodaction,
                VagonType = vagon,
                User = user
            };
            ukrzaliznutsaDBEntities.KlientsSet.Add(klients);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        public List<string> getContragent()
        {
            List<string> listklient;
            List<KlientsSet> klients;
            klients = ukrzaliznutsaDBEntities.KlientsSet.ToList();
            listklient = klients.AsParallel().Select(x => x.NameKlient + " " + x.Prodaction).ToList();
            return listklient;
        }

        public void setOrder(string user, string number, string contragentfrom, string pointstart, string contragentto, string pointent, string typevagon, string pricoeoforder, byte[] photo, byte[] orderphoto, byte[] informationorder, string marshrute, string locomotive, string allinfo, string prodinfo)
        {
            OrderSet orders = new OrderSet
            {
                User = user,
                Number = number,
                ContragentFrom = contragentfrom,
                PointStart = pointstart,
                ContragentTo = contragentto,
                PointEnd = pointent,
                TypeVagon = typevagon,
                PriceOfOrder = pricoeoforder,
                Photo = photo,
                OrderPhoto = orderphoto,
                InformationOfOrder = informationorder,
                Marshrute = marshrute,
                Locomotive = locomotive,
                AllInformation = allinfo,
                ProdactionInformation = prodinfo
            };
            ukrzaliznutsaDBEntities.OrderSet.Add(orders);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        public List<string> getOrder()
        {
            List<string> orderlist;
            orders = ukrzaliznutsaDBEntities.OrderSet.ToList();
            orderlist = orders.AsParallel().Select(x => x.User + " " + x.Locomotive + " " + x.Marshrute + " " + x.Number + " " + x.PointStart + " " + x.PointEnd + " " + x.ProdactionInformation + " " + x.PriceOfOrder + " " + x.TypeVagon).ToList();
            return orderlist;
        }


        public string[] getLocomotive()
        {
            List<LokomotiveSet> lokomotives;
            lokomotives = ukrzaliznutsaDBEntities.LokomotiveSet.ToList();
            return lokomotives.AsParallel().Select(x => x.Name).ToArray();
        }


        public void setTicket(string user, string number, string pointstart, string pointend, string typevagon, string price, byte[] photoload, byte[] arrayread, string marshrute)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            TicketSet ticket = new TicketSet
            {
                User = user,
                Number = number,
                PointStart = pointstart,
                PointEnd = pointend,
                TypeVagon = typevagon,
                Price = price,
                Photo = photoload,
                Information = arrayread,
                Marshrute = marshrute
            };
            ukrzaliznutsaDBEntities.TicketSet.Add(ticket);
            ukrzaliznutsaDBEntities.SaveChanges();
        }


        public List<string> getTickets()
        {
            List<string> listticket;
            List<TicketSet> tickets;
            tickets = ukrzaliznutsaDBEntities.TicketSet.ToList();
            listticket = tickets.AsParallel().Select(x => x.User + " " + x.Number + " " + x.PointStart + " " + x.PointEnd + " " + x.Marshrute + " " + x.TypeVagon + " " + x.Price).ToList();
            return listticket;
        }

        public List<string> getMarshruteWheelMove()
        {
            List<string> marshdata;
            marshdata = marshrutes.Select(x => x.NumberTrain + " " + x.Locomotive + " " + x.PointStart + " " + x.PointEnd + " " + x.TypeLocomotive + " " + x.TypeTrain + " " + x.TypeVagon).ToList();
            marshdata = marshdata.Skip(10).ToList();
            marshdata = marshdata.Take(10).ToList();
            return marshdata;
        }
    }
}
