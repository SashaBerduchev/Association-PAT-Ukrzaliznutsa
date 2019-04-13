using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddProdactionWindow.xaml
    /// </summary>
    public partial class AddProdactionWindow : Window
    {
        public AddProdactionWindow()
        {
            InitializeComponent();
            Type type = typeof(AddProdactionWindow);
            Trace.WriteLine(type.Name);
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Save);
            thread.Start();
            this.Close();
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
