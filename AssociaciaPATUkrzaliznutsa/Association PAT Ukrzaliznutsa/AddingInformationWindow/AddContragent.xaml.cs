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
    /// Логика взаимодействия для AddContragent.xaml
    /// </summary>
    public partial class AddContragent : Window
    {
        public AddContragent()
        {
            InitializeComponent();

            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<ProdactionSet> prodactions;
            List<VagonTypeSet> vagons;
            List<UsersSet> users;
            prodactions = ukrzaliznutsaDBEntities.ProdactionSet.ToList();
            vagons = ukrzaliznutsaDBEntities.VagonTypeSet.ToList();
            users = ukrzaliznutsaDBEntities.UsersSet.ToList();
            Prodaction.ItemsSource = prodactions.AsParallel().Select(x => x.ProdactionName).ToArray();
            VagonType.ItemsSource = vagons.AsParallel().Select(x => x.Type).ToArray();
            user.ItemsSource = users.AsParallel().Select(x => x.Name).ToArray();
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
                try
                {
                    UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                    KlientsSet klients = new KlientsSet
                    {
                        NameKlient = NameKlient.Text,
                        Prodaction = Prodaction.SelectedItem.ToString(),
                        VagonType = VagonType.SelectedItem.ToString(),
                        User = user.SelectedItem.ToString()
                    };
                    ukrzaliznutsaDBEntities.KlientsSet.Add(klients);
                    ukrzaliznutsaDBEntities.SaveChanges();
                }catch(Exception exp)
                { 
                    MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
