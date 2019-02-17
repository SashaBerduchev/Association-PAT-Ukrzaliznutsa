using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.MarshruteInfoWindow
{
    /// <summary>
    /// Логика взаимодействия для CreateMarshrute.xaml
    /// </summary>
    public partial class CreateMarshrute : Window
    {
        public CreateMarshrute()
        {
            InitializeComponent();
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<NaselennuyPunktSet> naselennuyPunkts;
            List<TrainsInfoSet> trains;
            List<TypeLocomotiveSet> typeLocomotives;
            List<LokomotiveSet> lokomotives;
            naselennuyPunkts = ukrzaliznutsaDBEntities.NaselennuyPunktSet.ToList();
            PointStart.ItemsSource = naselennuyPunkts.Select(x => new { x.NamePunkt });
            PointEnd.ItemsSource = naselennuyPunkts.Select(x => new { x.NamePunkt });
            trains = ukrzaliznutsaDBEntities.TrainsInfoSet.ToList();
            TypeTrain.ItemsSource = trains.Select(x => new { x.Number, x.Locomotive, x.Length, x.TypeVagon });
            typeLocomotives = ukrzaliznutsaDBEntities.TypeLocomotiveSet.ToList();
            TypeLocomotive.ItemsSource = typeLocomotives.Select(x => new { x.Type });
            lokomotives = ukrzaliznutsaDBEntities.LokomotiveSet.ToList();
            Locomotive.ItemsSource = lokomotives.Select(x => new { x.Name, x.Type, x.Velocity, x.PowerEngin });
            NumberTrain.ItemsSource = trains.AsParallel().Select(x => new { x.Number });
            TypeVagon.ItemsSource = trains.AsParallel().Select(x => x.TypeVagon).ToArray();

        }
        byte[] photoload;
        byte[] arrayread;
        private void ImageLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var picture = openFileDialog.FileName;
            try
            {
                FileStream fs = new FileStream(picture, FileMode.Open, FileAccess.Read);
                photoload = new byte[fs.Length];
                using (var reader = new BinaryReader(fs))
                {
                    photoload = reader.ReadBytes((int)fs.Length);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void FileLoad_Click(object sender, RoutedEventArgs e)
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

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(setMarshrute);
            thread.Start();
        }

        private void setMarshrute()
        {
            Dispatcher.Invoke(() =>
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                MarshrutesSet marshrutes = new MarshrutesSet
                {
                    NumberTrain = NumberTrain.Text,
                    PointStart = PointStart.SelectedItem.ToString(),
                    PointEnd = PointEnd.SelectedItem.ToString(),
                    Locomotive = Locomotive.SelectedItem.ToString(),
                    TypeLocomotive = TypeLocomotive.SelectedItem.ToString(),
                    TypeTrain = TypeTrain.SelectedItem.ToString(),
                    TypeVagon = TypeVagon.SelectedItem.ToString(),
                    Photo = photoload,
                    PDF = arrayread
                };
                ukrzaliznutsaDBEntities.MarshrutesSet.Add(marshrutes);
                ukrzaliznutsaDBEntities.SaveChanges();
            });
        }


    }
}
