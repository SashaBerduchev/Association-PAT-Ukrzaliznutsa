using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Association_PAT_UkrzaliznutsaClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddContragent.xaml
    /// </summary>
    public partial class AddContragent : Window
    {
        IContract contract;
        public AddContragent()
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
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            contract.setContragent(NameKlient.Text, Prodaction.SelectedItem.ToString(), VagonType.SelectedItem.ToString(), User.SelectedItem.ToString());
        }
    }
}
