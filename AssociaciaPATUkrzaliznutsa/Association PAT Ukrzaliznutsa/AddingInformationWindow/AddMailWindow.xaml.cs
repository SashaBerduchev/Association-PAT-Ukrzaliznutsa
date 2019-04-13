using System;
using System.Diagnostics;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddMailWindow.xaml
    /// </summary>
    public partial class AddMailWindow : Window
    {
        public AddMailWindow()
        {
            InitializeComponent();

            Type type = typeof(AddMailWindow);
            Trace.WriteLine(type.Name);
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

            this.Close();
        }
    }
}
