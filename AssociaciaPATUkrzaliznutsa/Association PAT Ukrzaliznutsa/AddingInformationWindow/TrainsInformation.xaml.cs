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
    /// Логика взаимодействия для TrainsInformation.xaml
    /// </summary>
    public partial class TrainsInformation : Window
    {
        public TrainsInformation()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTrainsInfo addTrainsInfo = new AddTrainsInfo();
            addTrainsInfo.Show();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<TrainsInfoSet> trains;
            trains = ukrzaliznutsaDBEntities.TrainsInfoSet.ToList();
            dataagrid.ItemsSource = trains.Select(x => new { x.Number, x.Locomotive, x.TypeLocomotive, x.TypeVagon, x.Length, x.LocomotivePowerEngine });
        }
    }
}
