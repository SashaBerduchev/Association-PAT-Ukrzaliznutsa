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
    /// Логика взаимодействия для LocomotiveInformation.xaml
    /// </summary>
    public partial class LocomotiveInformation : Window
    {
        public LocomotiveInformation()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddLocomotiveWindow addLocomotive = new AddLocomotiveWindow();
            addLocomotive.Show();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<LokomotiveSet> lokomotives;
            lokomotives = ukrzaliznutsaDBEntities.LokomotiveSet.ToList();
            dataagrid.ItemsSource = lokomotives.Select(x => new { x.Name, x.Type, x.Velocity, x.PowerEngin });
        }
    }
}
