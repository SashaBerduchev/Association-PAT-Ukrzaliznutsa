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
    /// Логика взаимодействия для CreateTicket.xaml
    /// </summary>
    public partial class CreateTicket : Window
    {
        private List<UsersSet> users;
        private List<MarshrutesSet> marshrutes;
        private List<TrainsInfoSet> trains;
        private byte[] photoload;
        private byte[] arrayread;
        public CreateTicket()
        {
            InitializeComponent();

            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            users = ukrzaliznutsaDBEntities.UsersSet.ToList();
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            trains = ukrzaliznutsaDBEntities.TrainsInfoSet.ToList();
            user.ItemsSource = users.Select(x => x.Name).ToArray();
            number.ItemsSource = marshrutes.Select(x => x.NumberTrain).ToArray();
            pointstart.ItemsSource = marshrutes.Select(x => x.PointStart).ToArray();
            pointend.ItemsSource = marshrutes.Select(x => x.PointEnd).ToArray();
            typevagon.ItemsSource = trains.Select(x => x.TypeVagon).ToArray();
            Marshrute.ItemsSource = marshrutes.Select(x => new { x.NumberTrain, x.PointStart, x.PointEnd, x.TypeTrain, x.TypeVagon });
        }

        
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
            }catch(Exception exp)
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
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_Set_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                TicketSet ticket = new TicketSet
                {
                    User = user.SelectedItem.ToString(),
                    Number = number.SelectedItem.ToString(),
                    PointStart = pointstart.SelectedItem.ToString(),
                    PointEnd = pointend.SelectedItem.ToString(),
                    TypeVagon = typevagon.SelectedItem.ToString(),
                    Price = price.Text,
                    Photo = photoload,
                    Information = arrayread,
                    Marshrute = Marshrute.SelectedItem.ToString()
                };
                ukrzaliznutsaDBEntities.TicketSet.Add(ticket);
                ukrzaliznutsaDBEntities.SaveChanges();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
