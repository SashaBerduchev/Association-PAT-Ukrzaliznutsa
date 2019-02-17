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
    /// Логика взаимодействия для AddTypeLocomotive.xaml
    /// </summary>
    public partial class AddTypeLocomotive : Window
    {
        public AddTypeLocomotive()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            TypeLocomotiveSet typeLocomotive = new TypeLocomotiveSet
            {
                Type = name.Text
            };
            ukrzaliznutsaDBEntities.TypeLocomotiveSet.Add(typeLocomotive);
            ukrzaliznutsaDBEntities.SaveChanges();
        }
    }
}
