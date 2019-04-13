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
    /// Логика взаимодействия для AddTypeLocomotiveWindow.xaml
    /// </summary>
    public partial class AddTypeLocomotiveWindow : Window
    {
        public AddTypeLocomotiveWindow()
        {
            InitializeComponent();

            Type type = typeof(AddTypeLocomotiveWindow);
            Trace.WriteLine(type.Name);
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
            this.Close();
        }
    }
}
