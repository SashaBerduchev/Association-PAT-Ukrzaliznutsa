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
    /// Логика взаимодействия для NaselennuyPunktInfo.xaml
    /// </summary>
    public partial class NaselennuyPunktInfo : Window
    {
        IContract contract;
        public NaselennuyPunktInfo()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();

            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNaselennuyPunktWindow addNaselennuyPunkt = new AddNaselennuyPunktWindow();
            addNaselennuyPunkt.Show();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytes = contract.LoadNaselenPunkt();
            dataagrid.ItemsSource = Encoding.Default.GetString(bytes);
        }
    }
}
