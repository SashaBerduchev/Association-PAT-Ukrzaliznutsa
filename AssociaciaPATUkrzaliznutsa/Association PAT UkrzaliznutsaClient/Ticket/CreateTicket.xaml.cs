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
    /// Логика взаимодействия для CreateTicket.xaml
    /// </summary>
    public partial class CreateTicket : Window
    {
        IContract contract;
        public CreateTicket()
        {
            InitializeComponent();

            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();


            user.ItemsSource = contract.getUser();
            number.ItemsSource = contract.getNumber();
            pointstart.ItemsSource = contract.getPointStart();
            pointend.ItemsSource = contract.getPointEnd();
            typevagon.ItemsSource = contract.getTypeVagon();
            
        }

        private byte[] photoload, arrayread;
        private void Btn_photo_Click(object sender, RoutedEventArgs e)
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

        private void Btn_info_Click(object sender, RoutedEventArgs e)
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

        private void Btn_Set_Click(object sender, RoutedEventArgs e)
        {
            contract.setTicket(user.SelectedItem.ToString(), number.SelectedItem.ToString(), pointstart.SelectedItem.ToString(), pointend.SelectedItem.ToString(), typevagon.SelectedItem.ToString(), price.Text, photoload, arrayread, marshrute.SelectedItem.ToString());
        }
    }
}
