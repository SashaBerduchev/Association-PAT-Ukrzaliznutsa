using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.Login
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Type type = typeof(LoginWindow);
            Trace.WriteLine(type.Name);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                UsersSet users = new UsersSet
                {
                    Name = Name.Text,
                    Password = Pass.Password
                };
                ukrzaliznutsaDBEntities.UsersSet.Add(users);
                ukrzaliznutsaDBEntities.SaveChanges();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                new LoginWindow().Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
