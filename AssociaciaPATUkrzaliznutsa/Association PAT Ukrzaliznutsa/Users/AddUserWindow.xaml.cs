using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public AddUserWindow()
        {
            InitializeComponent();

            Type type = typeof(AddUserWindow);
            Trace.WriteLine(type.Name);
        }

        private void TextUser_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            UsersSet usersSet = new UsersSet
            {
                Name = User.Text,
                Password = Password.Password
            };
            ukrzaliznutsaDBEntities.UsersSet.Add(usersSet);
            ukrzaliznutsaDBEntities.SaveChanges();
            this.Close();
        }
    }
}
