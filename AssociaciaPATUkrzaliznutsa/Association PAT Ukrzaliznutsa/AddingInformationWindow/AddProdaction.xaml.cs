using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для AddProdaction.xaml
    /// </summary>
    public partial class AddProdaction : Window
    {
        public AddProdaction()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Save);
            thread.Start();
        }

        private void Save()
        {
            Dispatcher.Invoke(() =>
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                ProdactionSet prodactionSet = new ProdactionSet
                {
                    ProdactionName = ProdactionName.Text,
                    ProdactionCount = ProdactionCount.Text,
                    ProdactionCost = ProdactionCost.Text
                };
                ukrzaliznutsaDBEntities.ProdactionSet.Add(prodactionSet);
                ukrzaliznutsaDBEntities.SaveChanges();
            });
        }
    }
}
