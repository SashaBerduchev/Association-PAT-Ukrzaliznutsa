using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Association_PAT_Ukrzaliznutsa
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        void AddNaselenPunkt(string namepunkt);
        [OperationContract]
        byte[] LoadNaselenPunkt();
        [OperationContract]
        void setLocomotiveinfo(string Name, string Type, string Velocity, string PowerEngin, string information, byte[] pdf, byte[] photo);
        [OperationContract]
        byte[] getTypeLocomotive();
        [OperationContract]
        void setLocomotiveType(string type);
        [OperationContract]
        List<string> getMarshruteData();
        [OperationContract]
        void setUserLogin(string login, string pass);
        [OperationContract]
        string[] getMailAddress();
        [OperationContract]
        string[] getUser();
        [OperationContract]
        string[] getNumber();
        [OperationContract]
        string[] getPointStart();
        [OperationContract]
        string[] getPointEnd();
        [OperationContract]
        string[] getTypeVagon();
        [OperationContract]
        void setProdact(string prodactionname, string prodactioncount, string prodactioncost);
        [OperationContract]
        string[] getProdaction();
        [OperationContract]
        void setContragent(string namecontragent, string prodaction, string vagon, string user);
        [OperationContract]
        List<string> getContragent();
        [OperationContract]
        void setOrder(string user, string number, string contragentfrom, string pointstart, string contragentto, string pointent, string typevagon, string pricoeoforder, byte[] photo, byte[] orderphoto, byte[] informationorder, string marshrute, string locomotive, string allinfo, string prodinfo);
        [OperationContract]
        List<string> getOrder();
      
        [OperationContract]
        void setTicket(string user, string number, string pointstart, string pointend, string typevagon, string price, byte[] photoload, byte[] arrayread, string marshrute);
        [OperationContract]
        List<string> getTickets();
        [OperationContract]
        string[] getLocomotive();
        [OperationContract]
        List<string> getMarshruteWheelMove();
    };
}
