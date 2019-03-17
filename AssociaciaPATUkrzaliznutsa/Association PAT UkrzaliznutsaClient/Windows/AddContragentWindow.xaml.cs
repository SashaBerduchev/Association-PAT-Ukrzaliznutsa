using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows;

namespace Association_PAT_UkrzaliznutsaClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddContragentWindow.xaml
    /// </summary>
    public partial class AddContragentWindow : Window
    {
        IContract contract;
        public AddContragentWindow()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            InitializeComponent();

            VagonType.ItemsSource = contract.getTypeVagon();
            Prodaction.ItemsSource = contract.getProdaction();
            User.ItemsSource = contract.getUser();
            Type type = typeof(AddContragentWindow);
            Trace.WriteLine(type.Name);
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            contract.setContragent(NameKlient.Text, Prodaction.SelectedItem.ToString(), VagonType.SelectedItem.ToString(), User.SelectedItem.ToString());
        }
    }
}
