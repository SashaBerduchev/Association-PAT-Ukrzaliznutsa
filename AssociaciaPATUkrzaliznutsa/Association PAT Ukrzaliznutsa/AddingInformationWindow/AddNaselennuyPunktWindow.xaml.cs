using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddNaselennuyPunktWindow.xaml
    /// </summary>
    public partial class AddNaselennuyPunktWindow : Window
    {
        public AddNaselennuyPunktWindow()
        {
            InitializeComponent();

            Type type = typeof(AddNaselennuyPunktWindow);
            Trace.WriteLine(type);
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            NaselennuyPunktSet naselennuyPunkt = new NaselennuyPunktSet
            {
                NamePunkt = punktname.Text
            };
            ukrzaliznutsaDBEntities.NaselennuyPunktSet.Add(naselennuyPunkt);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        private void Punktname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                NaselennuyPunktSet naselennuyPunkt = new NaselennuyPunktSet
                {
                    NamePunkt = punktname.Text
                };
                ukrzaliznutsaDBEntities.NaselennuyPunktSet.Add(naselennuyPunkt);
                ukrzaliznutsaDBEntities.SaveChanges();
            }
        }
    }
}
