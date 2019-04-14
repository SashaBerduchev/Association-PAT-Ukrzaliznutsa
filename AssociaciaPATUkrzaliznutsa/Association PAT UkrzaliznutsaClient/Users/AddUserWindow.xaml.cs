using Association_PAT_UkrzaliznutsaClient;
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

namespace Association_PAT_Ukrzaliznutsa.Users
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        IContract contract;
        public AddUserWindow()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            InitializeComponent();

            Type type = typeof(AddUserWindow);
            Trace.WriteLine(type.Name);
        }

        private void TextUser_Click(object sender, RoutedEventArgs e)
        {
            contract.setUserLogin(User.Text, Password.Password);
            this.Close();
        }
    }
}
