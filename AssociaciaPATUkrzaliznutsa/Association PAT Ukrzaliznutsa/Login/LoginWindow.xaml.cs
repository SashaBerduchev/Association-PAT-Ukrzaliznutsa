using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.Login
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<UsersSet> users;
        public LoginWindow()
        {
            InitializeComponent();
            string uriAddress = "net.tcp://localhost:4000/IContract";
            //Uri addres = new Uri("net.tcp://localhost:4000/IContract");
            Uri addres = new Uri(uriAddress);
            NetTcpBinding binding = new NetTcpBinding();
            binding.ListenBacklog = 2000;
            binding.MaxConnections = 2000;
            binding.TransferMode = TransferMode.Buffered;
            binding.MaxReceivedMessageSize = 104857600;
            Type type = typeof(IContract);
            ServiceHost serviceHost = new ServiceHost(typeof(UZService));
            serviceHost.AddServiceEndpoint(type, binding, uriAddress);
            serviceHost.Open();

            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            users = ukrzaliznutsaDBEntities.UsersSet.ToList();
            User.ItemsSource = users.Select(z=>z.Name);
            Type typer = typeof(LoginWindow);
            Trace.WriteLine(typer.Name);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                //UsersSet users = new UsersSet
                //{
                //    Name = User.SelectedItem.ToString(),
                //    Password = Pass.Password
                //};
                //ukrzaliznutsaDBEntities.UsersSet.Add(users);
                //ukrzaliznutsaDBEntities.SaveChanges();

                UsersSet user = ukrzaliznutsaDBEntities.UsersSet.Where(x => x.Password == Pass.Password).First();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Не верный пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream(@"Connection.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }
        }
        
    }
}
