using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddLocomotiveWindow.xaml
    /// </summary>
    public partial class AddLocomotiveWindow : Window
    {
        private byte[] photoload;
        private byte[] arrayread;
        public AddLocomotiveWindow()
        {
            InitializeComponent();

            List<TypeLocomotiveSet> types;
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            types = ukrzaliznutsaDBEntities.TypeLocomotiveSet.ToList();
            typesList.ItemsSource = types.Select(x => new { x.Type });

            Type type = typeof(AddLocomotiveWindow);
            Trace.WriteLine(type);
        }
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
            Thread thread = new Thread(Save);
            thread.Start();
            this.Close();
        }

        private void Save()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                    LokomotiveSet lokomotive = new LokomotiveSet
                    {
                        Name = NameLocomotive.Text,
                        PowerEngin = Power.Text,
                        Type = typesList.SelectedItem.ToString(),
                        Velocity = Velocity.Text,
                        Photo = photoload,
                        PDF = arrayread,
                        Information = Information.Text
                    };
                    ukrzaliznutsaDBEntities.LokomotiveSet.Add(lokomotive);
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
