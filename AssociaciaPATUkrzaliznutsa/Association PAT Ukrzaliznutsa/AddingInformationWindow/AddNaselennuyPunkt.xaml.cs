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
    /// Логика взаимодействия для AddNaselennuyPunkt.xaml
    /// </summary>
    public partial class AddNaselennuyPunkt : Window
    {
        public AddNaselennuyPunkt()
        {
            InitializeComponent();
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
            if(e.Key == Key.Enter )
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
