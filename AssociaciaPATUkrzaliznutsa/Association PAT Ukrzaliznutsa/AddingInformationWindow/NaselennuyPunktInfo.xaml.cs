using Association_PAT_Ukrzaliznutsa.AddingInformationWindow;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.Windows
{
    /// <summary>
    /// Логика взаимодействия для NaselennuyPunktInfo.xaml
    /// </summary>
    public partial class NaselennuyPunktInfo : Window
    {
        public NaselennuyPunktInfo()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNaselennuyPunktWindow addNaselennuyPunkt = new AddNaselennuyPunktWindow();
            addNaselennuyPunkt.Show();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            List<NaselennuyPunktSet> naselennuyPunkts;
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            naselennuyPunkts = ukrzaliznutsaDBEntities.NaselennuyPunktSet.ToList();
            dataagrid.ItemsSource = naselennuyPunkts.Select(x => new { x.NamePunkt });
        }
    }
}
