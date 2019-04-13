using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для AddTrainsInfoWindow.xaml
    /// </summary>
    public partial class AddTrainsInfoWindow : Window
    {
        private byte[] photoload;
        private byte[] arrayread;
        private List<LokomotiveSet> lokomotives;
        private List<VagonTypeSet> vagonTypes;
        private List<TypeLocomotiveSet> typeLocomotives;
        public AddTrainsInfoWindow()
        {
            InitializeComponent();

            
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            lokomotives = ukrzaliznutsaDBEntities.LokomotiveSet.ToList();
            vagonTypes = ukrzaliznutsaDBEntities.VagonTypeSet.ToList();
            typeLocomotives = ukrzaliznutsaDBEntities.TypeLocomotiveSet.ToList();
            Locomotive.ItemsSource = lokomotives.Select(x => new { x.Name, x.Type, x.Velocity });
            TypeVagon.ItemsSource = vagonTypes.Select(x => new { x.Type });
            TypeLocomotive.ItemsSource = typeLocomotives.Select(x => new { x.Type });
            LocomotivePowerEngine.ItemsSource = lokomotives.Select(x => new { x.PowerEngin });

            Type type = typeof(AddTrainsInfoWindow);
            Trace.WriteLine(type.Name);
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
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
        private void LoadPhoto_Click(object sender, RoutedEventArgs e)
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

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(setTrainInfo);
            thread.Start();
            this.Close();
        }
        private void setTrainInfo()
        {
            Dispatcher.Invoke(() =>
            {
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                TrainsInfoSet trains = new TrainsInfoSet
                {
                    Length = Length.Text,
                    Locomotive = Locomotive.SelectedItem.ToString(),
                    LocomotivePowerEngine = LocomotivePowerEngine.SelectedItem.ToString(),
                    Number = Number.Text,
                    TypeLocomotive = TypeLocomotive.SelectedItem.ToString(),
                    TypeVagon = TypeVagon.SelectedItem.ToString(),
                    Photo = photoload,
                    PDF = arrayread
                };
                ukrzaliznutsaDBEntities.TrainsInfoSet.Add(trains);
                ukrzaliznutsaDBEntities.SaveChanges();
            });
        }
    }
}
