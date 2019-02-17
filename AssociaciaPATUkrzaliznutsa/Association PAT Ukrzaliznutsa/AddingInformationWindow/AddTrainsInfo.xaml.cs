﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow
{
    /// <summary>
    /// Логика взаимодействия для AddTrainsInfo.xaml
    /// </summary>
    public partial class AddTrainsInfo : Window
    {
        public AddTrainsInfo()
        {
            InitializeComponent();

            List<LokomotiveSet> lokomotives;
            List<VagonTypeSet> vagonTypes;
            List<TypeLocomotiveSet> typeLocomotives;
            UkrzaliznutsaDBEntities  ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            lokomotives = ukrzaliznutsaDBEntities.LokomotiveSet.ToList();
            vagonTypes = ukrzaliznutsaDBEntities.VagonTypeSet.ToList();
            typeLocomotives = ukrzaliznutsaDBEntities.TypeLocomotiveSet.ToList();
            Locomotive.ItemsSource = lokomotives.Select(x => new { x.Name, x.Type, x.Velocity });
            TypeVagon.ItemsSource = vagonTypes.Select(x => new { x.Type });
            TypeLocomotive.ItemsSource = typeLocomotives.Select(x => new { x.Type });
            LocomotivePowerEngine.ItemsSource = lokomotives.Select(x => new { x.PowerEngin });
        }


        byte[] photoload;
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


        byte[] arrayread;
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

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            for (int i=0; i<Convert.ToInt32(point.Text); i++)
            {
                Thread thread = new Thread(setTrainInfo);
                thread.Start();
            }
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

