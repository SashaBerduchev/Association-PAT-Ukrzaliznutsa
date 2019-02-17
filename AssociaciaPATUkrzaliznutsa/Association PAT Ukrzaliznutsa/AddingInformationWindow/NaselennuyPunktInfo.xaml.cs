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
            AddNaselennuyPunkt addNaselennuyPunkt = new AddNaselennuyPunkt();
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
