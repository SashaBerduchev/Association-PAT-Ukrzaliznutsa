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

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для MailInfoWindow.xaml
    /// </summary>
    public partial class MailInfoWindow : Window
    {
        public MailInfoWindow()
        {
            InitializeComponent();

            Type type = typeof(MailInfoWindow);
            Trace.WriteLine(type.Name);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMailWindow addMail = new AddMailWindow();
            addMail.Show();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            List<MailSet> mails;
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            mails = ukrzaliznutsaDBEntities.MailSet.ToList();
            dataagrid.ItemsSource = mails.Select(x => new { x.MailName });
        }
    }
}
