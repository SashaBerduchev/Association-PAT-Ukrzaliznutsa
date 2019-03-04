using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AssociaciaPATUkrzaliznutsaService
{
    public partial class AssociaciaPATUkrzaliznutsaService : ServiceBase
    {
        private ServiceHost service_host = null;
        public AssociaciaPATUkrzaliznutsaService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (service_host != null) service_host.Close();

            string address_HTTP = "http://localhost:20000/AssociaciaPATUkrzaliznytsaServer";
            string address_TCP = "net.tcp://localhost:20000/AssociaciaPATUkrzaliznytsaServer";

            Uri[] address_base = { new Uri(address_HTTP), new Uri(address_TCP) };
            service_host = new ServiceHost(typeof(AssociaciaPATUkrzakiznutsaLibrery.AssociaciaPATUkrzaliznytsaServer), address_base);

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            service_host.Description.Behaviors.Add(behavior);

            BasicHttpBinding binding_http = new BasicHttpBinding();
            service_host.AddServiceEndpoint(typeof(AssociaciaPATUkrzakiznutsaLibrery.IContract), binding_http, address_HTTP);
            service_host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            NetTcpBinding binding_tcp = new NetTcpBinding();
            binding_tcp.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding_tcp.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            service_host.AddServiceEndpoint(typeof(AssociaciaPATUkrzakiznutsaLibrery.IContract), binding_tcp, address_TCP);
            service_host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            service_host.Open();
        }

        protected override void OnStop()
        {
            if (service_host != null)
            {
                service_host.Close();
                service_host = null;
            }
        }
    }
}
