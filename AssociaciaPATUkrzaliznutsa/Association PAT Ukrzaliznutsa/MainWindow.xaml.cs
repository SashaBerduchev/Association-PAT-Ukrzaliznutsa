using Association_PAT_Ukrzaliznutsa.AddingInformationWindow;
using Association_PAT_Ukrzaliznutsa.EMail;
using Association_PAT_Ukrzaliznutsa.MarshruteInfoWindow;
using Association_PAT_Ukrzaliznutsa.Tickets;
using Association_PAT_Ukrzaliznutsa.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Association_PAT_Ukrzaliznutsa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities;
        private List<MarshrutesSet> marshrutes;
        private List<OrderSet> orders;
        private List<KlientsSet> klients;
        private List<ProdactionSet> prodactions;
        public MainWindow()
        {
            InitializeComponent();
            OnUpdate();
            Type typen = typeof(MainWindow);
            Trace.Write(message: typen.Name);

        }

        private void OnUpdate()
        {
            Thread klientload = new Thread(OnLoadKlient);
            Thread orderLoad = new Thread(OnLoadOrder);
            klientload.Start();
            orderLoad.Start();
        }

        private void OnLoadOrder()
        {
            Dispatcher.Invoke(() =>
            {
                ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                prodactions = ukrzaliznutsaDBEntities.ProdactionSet.ToList();
                listprodact.ItemsSource = prodactions.Select(x => x.ProdactionName);
            });
        }

        private void OnLoadKlient()
        {
            Dispatcher.Invoke(() =>
            {
                ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                klients = ukrzaliznutsaDBEntities.KlientsSet.ToList();
                listcontragent.ItemsSource = klients.Select(x => x.NameKlient);
            });
        }

        private void BtnAddNaselenPunkt_Click(object sender, RoutedEventArgs e)
        {
            NaselennuyPunktInfoWindow naselennuyPunkt = new NaselennuyPunktInfoWindow();
            naselennuyPunkt.Show();
        }


        private void BtnAddLocomotive_Click(object sender, RoutedEventArgs e)
        {
            LocomotiveInformationWindow locomotiveInformation = new LocomotiveInformationWindow();
            locomotiveInformation.Show();
        }

        private void BtnAddLocomotiveType_Click(object sender, RoutedEventArgs e)
        {
            AddTypeLocomotiveWindow addTypeLocomotive = new AddTypeLocomotiveWindow();
            addTypeLocomotive.Show();
        }

        private void BtnAddVagonType_Click(object sender, RoutedEventArgs e)
        {
            AddVagonTypeWindow addVagonType = new AddVagonTypeWindow();
            addVagonType.Show();
        }

        private void BtnAddVagon_Click(object sender, RoutedEventArgs e)
        {
            TrainsInformationWindow trainsInformation = new TrainsInformationWindow();
            trainsInformation.Show();
        }

        private void AddMarshrute_Click(object sender, RoutedEventArgs e)
        {
            CreateMarshrute createMarshrute = new CreateMarshrute();
            createMarshrute.Show();
        }


        private void Load_Click(object sender, RoutedEventArgs e)
        {

            Thread thread = new Thread(LoadMarshrute);
            thread.Start();

        }

        private void BtnSert_Click(object sender, RoutedEventArgs e)
        {
            Thread sertthread = new Thread(SertMarshrute);
            sertthread.Start();
        }

        private void LoadMarshrute()
        {
            Dispatcher.Invoke(() =>
            {

                try
                {
                    UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                    marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
                    numbertrain.ItemsSource = marshrutes.AsParallel().Select(x => x.NumberTrain).ToArray();
                    pointstart.ItemsSource = marshrutes.AsParallel().Select(x => x.PointStart).ToArray();
                    pointend.ItemsSource = marshrutes.AsParallel().Select(x => x.PointEnd).ToArray();
                    typetrain.ItemsSource = marshrutes.AsParallel().Select(x => x.TypeTrain).ToArray();
                    BitmapImage image = new BitmapImage();
                    listbox.ItemsSource = marshrutes.AsParallel().Select(x =>x.Locomotive +" "+x.NumberTrain+" "+x.PointStart+" "+x.PointEnd+" "+x.TypeLocomotive+" "+x.TypeVagon+" "+x.TypeTrain).ToList();
                    numbertrain.ItemsSource = marshrutes.AsParallel().Select(x => x.NumberTrain ).ToArray();



                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    string expstr = exp.ToString();
                    FileStream fileStreamLog = new FileStream(@"D:\\Progects\\C-SHARP\\Association-PAT-Ukrzaliznutsa\\Association-PAT-Ukrzaliznutsa\\Association PAT Ukrzaliznutsa\\Association PAT Ukrzaliznutsa\\bin\\Debug\\Log\\ConnectiongError.log", FileMode.Append);
                    for (int i = 0; i < expstr.Length; i++)
                    {
                        byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                        fileStreamLog.Write(array, 0, array.Length);

                    }
                    fileStreamLog.Close();

                }
            });
        }


        private void SertMarshrute()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    List<string> marshdata;
                    marshdata = marshrutes.Select(x => x.NumberTrain + "" + x.PointStart + " " + x.PointEnd + " " + x.Locomotive + " " + x.TypeLocomotive + " " + x.TypeTrain).ToList();
                    listbox.ItemsSource = marshdata.Take(10).ToList();
                }catch(Exception exp)
                {
                    MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    string expstr = exp.ToString();
                    FileStream fileStreamLog = new FileStream(@"ConnectiongError.log", FileMode.Append);
                    for (int i = 0; i < expstr.Length; i++)
                    {
                        byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                        fileStreamLog.Write(array, 0, array.Length);

                    }
                    fileStreamLog.Close();

                }
            });

        }
        
        private void Print_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                FileStream fileStream = new FileStream(@"MarshruteInfo.txt", FileMode.Append);
                for (int i = 0; i < marshrutes.Count; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(marshrutes[i].ToString());
                    fileStream.Write(array, 0, array.Length);

                }
                fileStream.Close();
                FileStream fileStreamBin = new FileStream(@"MarshruteInfo.bin", FileMode.Append);
                for (int i = 0; i < marshrutes.Count; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(marshrutes[i].ToString());
                    fileStreamBin.Write(array, 0, array.Length);

                }
                fileStreamBin.Close();


                FileStream fileStreamWord = new FileStream(@"MarshruteSelectInfo.docx", FileMode.Append);
                for (int i = 0; i < marshrutes.Count; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(marshrutes[i].ToString());
                    fileStreamWord.Write(array, 0, array.Length);

                }
                fileStreamWord.Close();



                FileStream fileStreamSelectItem = new FileStream(@"MarshruteSelectInfo.txt", FileMode.Append);
                for (int i = 0; i < marshrutes.Count; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(listbox.SelectedItem.ToString());
                    fileStreamSelectItem.Write(array, 0, array.Length);

                }
                fileStream.Close();
                FileStream fileStreamBinSelectItem = new FileStream(@"MarshruteInfo.bin", FileMode.Append);
                for (int i = 0; i < marshrutes.Count; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(listbox.SelectedItem.ToString());
                    fileStreamBinSelectItem.Write(array, 0, array.Length);

                }
                fileStreamBin.Close();


                FileStream fileStreamWordSelectItem = new FileStream(@"MarshruteSelectInfo.docx", FileMode.Append);
                for (int i = 0; i < marshrutes.Count; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(listbox.SelectedItem.ToString());
                    fileStreamWordSelectItem.Write(array, 0, array.Length);

                }
                fileStreamWord.Close();



                MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception exp)
            {
                string expstr = exp.ToString();
                MessageBox.Show(exp.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                FileStream fileStreamLog = new FileStream(@"SaveInfo.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }

        }

        private void BtnAddMail_Click(object sender, RoutedEventArgs e)
        {
            MailInfoWindow mail = new MailInfoWindow();
            mail.Show();
        }

        private void BtnMail_Click(object sender, RoutedEventArgs e)
        {
            MailWorksWindow mailWork = new MailWorksWindow();
            mailWork.Show();

        }
        

        private void BtnSetTicket_Click(object sender, RoutedEventArgs e)
        {
            CreateTicketWindow createTicket = new CreateTicketWindow();
            createTicket.Show();
        }

        private void Btn_contragent_Click(object sender, RoutedEventArgs e)
        {
            AddContragentWindow addContragent = new AddContragentWindow();
            addContragent.Show();
        }

        private void Btn_prodaction_Click(object sender, RoutedEventArgs e)
        {
            AddProdactionWindow addProdaction = new AddProdactionWindow();
            addProdaction.Show();
        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            Thread threadinfo = new Thread(getInfoLoading);
            threadinfo.Start();
            Thread.Sleep(20);
        }

        private void getInfoLoading()
        {
            Dispatcher.Invoke(() =>
            {
                string[] arrayprod;
                List<ProdactionSet> prodactions;
                List<KlientsSet> klients;
                UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                prodactions = ukrzaliznutsaDBEntities.ProdactionSet.ToList();
                klients = ukrzaliznutsaDBEntities.KlientsSet.ToList();
                listcontragent.ItemsSource = klients.Select(x => x.NameKlient).ToArray();
                arrayprod = prodactions.Select(x => x.ProdactionName).ToArray();
                listprodact.ItemsSource = arrayprod;
            });
        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow createOrder = new CreateOrderWindow();
            createOrder.Show();
        }
        

        private void BtnLoadingInfo_Click_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(LoadOrder);
            thread.Start();
        }

        private void LoadOrder()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
                    orders = ukrzaliznutsaDBEntities.OrderSet.ToList();
                    Number.ItemsSource = orders.Select(x => x.Number);
                    PointStart.ItemsSource = orders.Select(x => x.PointStart);
                    PointEnd.ItemsSource = orders.Select(x => x.PointEnd);
                    TypeTrain.ItemsSource = orders.Select(x => x.TypeVagon);
                    orderloadgrid.ItemsSource = orders.Select(x => new { x.Number, x.PointStart, x.ContragentFrom, x.PointEnd, x.ContragentTo, x.TypeVagon, x.PriceOfOrder, x.Marshrute });
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void Ticketloadgrid_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<TicketSet> tickets;
            tickets = ukrzaliznutsaDBEntities.TicketSet.ToList();
            orderloadgrid.ItemsSource = tickets.Select(x => new { x.User, x.Number, x.Marshrute, x.PointStart, x.PointEnd, x.Price, x.TypeVagon });
        }

        private void BtnPrintOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fileStream = new FileStream("OrderInfo.txt", FileMode.Append);
                byte[] arraybyte = Encoding.Default.GetBytes(orderloadgrid.SelectedItem.ToString());
                fileStream.Write(arraybyte, 0, arraybyte.Length);
                MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                fileStream.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream("SavingInfoError.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().Show();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<UsersSet> users;
            UsersSet user = ukrzaliznutsaDBEntities.UsersSet.Where(x=>x.Name == ListUsers.SelectedItem.ToString()).FirstOrDefault();
            users = ukrzaliznutsaDBEntities.UsersSet.ToList();
            ukrzaliznutsaDBEntities.UsersSet.Remove(user);
            ukrzaliznutsaDBEntities.SaveChanges();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            List<UsersSet> users;
            users = ukrzaliznutsaDBEntities.UsersSet.ToList();
            ListUsers.ItemsSource = users.Select(x=>x.Name);
        }
    }

}


