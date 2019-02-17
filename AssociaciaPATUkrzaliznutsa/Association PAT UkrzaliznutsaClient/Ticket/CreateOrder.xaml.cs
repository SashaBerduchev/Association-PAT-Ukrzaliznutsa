using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
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

namespace Association_PAT_UkrzaliznutsaClient.Ticket
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        IContract contract;
        public CreateOrder()
        {

            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            InitializeComponent();

            User.ItemsSource = contract.getUser();
            Number.ItemsSource = contract.getNumber();
            PointStart.ItemsSource = contract.getPointStart();
            PointEnd.ItemsSource = contract.getPointEnd();
            TypeVadon.ItemsSource = contract.getTypeVagon();
            ContragentFrom.ItemsSource = contract.getContragent();
            ContragentTo.ItemsSource = contract.getContragent();
            
            Prodaction.ItemsSource = contract.getProdaction();
            Locomotive.ItemsSource = contract.getLocomotive();
        }


        private byte[] photoload;
        private byte[] orderphoto;
        private byte[] arrayread;
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
            contract.setOrder(User.SelectedItem.ToString(), Number.SelectedItem.ToString(), ContragentFrom.SelectedItem.ToString(), PointStart.SelectedItem.ToString(), ContragentTo.SelectedItem.ToString(), PointEnd.SelectedItem.ToString(), TypeVadon.SelectedItem.ToString(), PriceOfOrder.Text, photoload, orderphoto, arrayread, Marshrute.SelectedItem.ToString(), Locomotive.SelectedItem.ToString(), Informationoforder.Text, prodactiontext.Text);
        }

        
    }
}
