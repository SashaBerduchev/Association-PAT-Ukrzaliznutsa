﻿using System;
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
    /// Логика взаимодействия для AddLocomotiveType.xaml
    /// </summary>
    public partial class AddLocomotiveType : Window
    {
        IContract contract;
        public AddLocomotiveType()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();

            InitializeComponent();
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            contract.setLocomotiveType(name.Text);
        }
    }
}
