using System;
using System.Collections.Generic;
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

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddMail.xaml
    /// </summary>
    public partial class AddMail : Window
    {
        public AddMail()
        {
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            MailSet mail = new MailSet
            {
                MailName = mailname.Text
            };
            ukrzaliznutsaDBEntities.MailSet.Add(mail);
            ukrzaliznutsaDBEntities.SaveChanges();
        }
    }
}
