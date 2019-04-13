using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows;

namespace Association_PAT_UkrzaliznutsaClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddLocomotiveWindow.xaml
    /// </summary>
    public partial class AddLocomotiveWindow : Window
    {
        IContract contract;
        public AddLocomotiveWindow()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();

            InitializeComponent();

            Type type = typeof(AddLocomotiveWindow);
            Trace.WriteLine(type.Name);
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            contract.setLocomotiveType(name.Text);
            this.Close();
        }
    }
}
