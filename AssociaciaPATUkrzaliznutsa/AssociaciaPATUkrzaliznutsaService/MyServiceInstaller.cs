using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace AssociaciaPATUkrzaliznutsaService
{
    [RunInstaller(true)]
    public partial class MyServiceInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;
        public MyServiceInstaller()
        {
            //initializeComponent();
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.NetworkService;
            service = new ServiceInstaller();
            service.ServiceName = "AssociaciaPATUkrzaliznutsaService";
            service.DisplayName = "AssociaciaPATUkrzaliznutsaService";
            service.Description = "WCF Service Hosted by Windows NT Service";
            service.StartType = ServiceStartMode.Automatic;
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
