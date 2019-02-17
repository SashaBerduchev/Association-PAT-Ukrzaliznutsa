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
    /// Логика взаимодействия для AddVagonType.xaml
    /// </summary>
    public partial class AddVagonType : Window
    {
        public AddVagonType()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            VagonTypeSet vagonType = new VagonTypeSet
            {
                Type = name.Text
            };
            ukrzaliznutsaDBEntities.VagonTypeSet.Add(vagonType);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        private void Name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                VagonTypeSet vagonType = new VagonTypeSet
                {
                    Type = name.Text
                };
                ukrzaliznutsaDBEntities.VagonTypeSet.Add(vagonType);
                ukrzaliznutsaDBEntities.SaveChanges();
            }
        }
    }
}
