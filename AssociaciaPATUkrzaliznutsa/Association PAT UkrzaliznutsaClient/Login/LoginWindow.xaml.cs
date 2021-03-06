﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Association_PAT_UkrzaliznutsaClient.Login
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IContract contract;
        public LoginWindow()
        {
            InitializeComponent();
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            try
            {
                User.ItemsSource = contract.Users();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Type type = typeof(LoginWindow);
            Trace.WriteLine(type.Name);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract.Login(Pass.Password);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Не верный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream(@"Connection.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);
                }
                fileStreamLog.Close();

                new LoginWindow().Show();
                this.Close();
            }
        }

        private void Pass_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                contract.Login(Pass.Password);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Не верный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream(@"Connection.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);
                }
                fileStreamLog.Close();

                new LoginWindow().Show();
                this.Close();
            }
        
        }
    }
}
