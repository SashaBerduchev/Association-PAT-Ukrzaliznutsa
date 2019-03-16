using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddContragentWindow.xaml
    /// </summary>
    public partial class AddContragentWindow : Window
    {
        public AddContragentWindow()
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

            Type type = typeof(AddContragentWindow);
            Trace.WriteLine(type);
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
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}

