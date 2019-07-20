using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Association_PAT_Ukrzaliznutsa.MarshruteInfoWindow
{
    /// <summary>
    /// Логика взаимодействия для MarshruteInfoWindow.xaml
    /// </summary>
    public partial class MarshruteInfoWindow : Window
    {
        String _number, _pointstart, _pointend;
        UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
        List<TrainsInfoSet> trainsInfo;
        public MarshruteInfoWindow(String number, String pointstart, String pointend)
        {
            InitializeComponent();
            Trace.WriteLine(this);
            _number = number;
            _pointstart = pointstart;
            _pointend = pointend;
            Number.Text = _number;
            PointStart.Text = _pointstart;
            PointEnd.Text = _pointend;
            trainsInfo = ukrzaliznutsaDBEntities.TrainsInfoSet.ToList();
            Train.ItemsSource = trainsInfo.Select(x => x.Locomotive + " " + x.LocomotivePowerEngine);
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= Convert.ToInt32(count.Text); i++)
            {
                Thread thread = new Thread(SetInfo);
                thread.Start();
            }

        }
            private void SetInfo()
            {
                Dispatcher.Invoke(() =>
                {
                    InfoMarshrute infoMarshrute = new InfoMarshrute
                    {
                        Number = Number.Text,
                        PointStart = PointStart.Text,
                        PointEnd = PointEnd.Text,
                        ArrayStations = StationArray.Text,
                        Cost = Cost.Text,
                        Trains = Train.SelectedItem.ToString()
                    };
                    ukrzaliznutsaDBEntities.InfoMarshruteSet.Add(infoMarshrute);
                    ukrzaliznutsaDBEntities.SaveChanges();
                });
            }
        }
    }
