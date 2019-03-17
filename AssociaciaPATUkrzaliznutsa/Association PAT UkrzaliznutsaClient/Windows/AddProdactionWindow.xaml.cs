using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddProdactionWindow.xaml
    /// </summary>
    public partial class AddProdactionWindow : Window
    {
        IContract contract;
        public AddProdactionWindow()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            InitializeComponent();

            Type type = typeof(AddProdactionWindow);
            Trace.WriteLine(type.Name);
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            contract.setProdact(ProdactionName.Text, ProdactionCount.Text, ProdactionCost.Text);
        }
    }
}
