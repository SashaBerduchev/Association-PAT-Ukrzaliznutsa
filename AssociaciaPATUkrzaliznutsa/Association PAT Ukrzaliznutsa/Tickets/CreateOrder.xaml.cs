using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Association_PAT_Ukrzaliznutsa.Tickets
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {

        private List<UsersSet> users;
        private List<MarshrutesSet> marshrutes;
        private List<KlientsSet> klients;
        private List<TrainsInfoSet> trains;
        private List<ProdactionSet> prodactions;
        private byte[] photoload;
        private byte[] orderphoto;
        private byte[] arrayread;

        
        public CreateOrder()
        {
            InitializeComponent();

            List<UsersSet> users;
            List<MarshrutesSet> marshrutes;
            List<KlientsSet> klients;
            List<TrainsInfoSet> trains;
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            users = ukrzaliznutsaDBEntities.UsersSet.ToList();
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            klients = ukrzaliznutsaDBEntities.KlientsSet.ToList();
            trains = ukrzaliznutsaDBEntities.TrainsInfoSet.ToList();
            User.ItemsSource = users.AsParallel().Select(x => x.Name).ToArray();
            Number.ItemsSource = marshrutes.AsParallel().Select(x => x.NumberTrain).ToArray();
            ContragentFrom.ItemsSource = klients.AsParallel().Select(x => x.NameKlient).ToArray();
            ContragentTo.ItemsSource = klients.AsParallel().Select(x => x.NameKlient).ToArray();
            PointStart.ItemsSource = marshrutes.AsParallel().Select(x => x.PointStart).ToArray();
            PointEnd.ItemsSource = marshrutes.AsParallel().Select(x => x.PointEnd).ToArray();
            TypeVadon.ItemsSource = trains.AsParallel().Select(x => x.TypeVagon).ToArray();
            Marshrute.ItemsSource = marshrutes.Select(x => new { x.NumberTrain, x.PointStart, x.PointEnd, x.TypeVagon }).ToArray();
            prodactions = ukrzaliznutsaDBEntities.ProdactionSet.ToList();
            Prodaction.ItemsSource = prodactions.AsParallel().Select(x => x.ProdactionName).ToArray();
        }



        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var picture = openFileDialog.FileName;
            try
            {
                FileStream fileStream = new FileStream(picture, FileMode.Open, FileAccess.Read);
                photoload = new byte[fileStream.Length];
                using (var reader = new BinaryReader(fileStream))
                {
                    photoload = reader.ReadBytes((int)fileStream.Length);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OrderPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var picture = openFileDialog.FileName;
            try
            {
                FileStream fileStream = new FileStream(picture, FileMode.Open, FileAccess.Read);
                orderphoto = new byte[fileStream.Length];
                using (var reader = new BinaryReader(fileStream))
                {
                    orderphoto = reader.ReadBytes((int)fileStream.Length);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InformatioOfOrder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var pdffile = openFileDialog.FileName;
            try
            {
                StreamReader sr = new StreamReader(pdffile);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    arrayread = Encoding.Default.GetBytes(line);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Prodaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prodactiontext.Text = Prodaction.SelectedItem.ToString();
        }

        private void Btn_Set_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            OrderSet order = new OrderSet
            {
                User = User.SelectedItem.ToString(),
                Number = Number.SelectedItem.ToString(),
                ContragentFrom = ContragentFrom.SelectedItem.ToString(),
                ContragentTo = ContragentTo.SelectedItem.ToString(),
                TypeVagon = TypeVadon.SelectedItem.ToString(),
                PointStart = PointStart.SelectedItem.ToString(),
                PointEnd = PointEnd.SelectedItem.ToString(),
                PriceOfOrder = PriceOfOrder.Text,
                Photo = photoload,
                OrderPhoto = orderphoto,
                InformationOfOrder = arrayread,
                Marshrute = Marshrute.SelectedItem.ToString(),
                AllInformation = Informationoforder.Text,
                ProdactionInformation = Prodaction.Text
            };
            ukrzaliznutsaDBEntities.OrderSet.Add(order);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        
    }
}
