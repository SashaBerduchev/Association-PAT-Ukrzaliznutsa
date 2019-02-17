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

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddLocomotive.xaml
    /// </summary>
    public partial class AddLocomotive : Window
    {
        public AddLocomotive()
        {
            InitializeComponent();

            List<TypeLocomotiveSet> types;
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            types = ukrzaliznutsaDBEntities.TypeLocomotiveSet.ToList();
            Type.ItemsSource = types.Select(x => new { x.Type });
        }

        byte[] photoload;
        private void Photo_Click(object sender, RoutedEventArgs e)
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

        byte[] arrayread;
        private void FileLOad_Click(object sender, RoutedEventArgs e)
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
            try
            {

                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                LokomotiveSet lokomotive = new LokomotiveSet
                {
                    Name = NameLocomotive.Text,
                    PowerEngin = Power.Text,
                    Type = Type.SelectedItem.ToString(),
                    Velocity = Velocity.Text,
                    Photo = photoload,
                    PDF = arrayread,
                    Information = Information.Text
                };
                ukrzaliznutsaDBEntities.LokomotiveSet.Add(lokomotive);
                ukrzaliznutsaDBEntities.SaveChanges();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
