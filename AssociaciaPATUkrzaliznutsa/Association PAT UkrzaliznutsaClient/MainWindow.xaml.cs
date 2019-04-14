using Association_PAT_Ukrzaliznutsa.Users;
using Association_PAT_UkrzaliznutsaClient.EMail;
using Association_PAT_UkrzaliznutsaClient.Ticket;
using Association_PAT_UkrzaliznutsaClient.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Association_PAT_UkrzaliznutsaClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContract contract;
        public MainWindow()
        {

            InitializeComponent();
            string endpPointStr = "net.tcp://localhost:4000/IContract";
            //Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            Uri uri = new Uri(endpPointStr);
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            netTcpBinding.TransferMode = TransferMode.Buffered;
            netTcpBinding.MaxReceivedMessageSize = 104857600;
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            

            numbertrain.ItemsSource = contract.getNumber();
            pointstart.ItemsSource = contract.getPointStart();
            pointend.ItemsSource = contract.getPointEnd();
            typetrain.ItemsSource = contract.getTypeVagon();

            Type type = typeof(MainWindow);
            Trace.WriteLine(type.Name);

        }

        private void BtnAddNaselenPunkt_Click(object sender, RoutedEventArgs e)
        {
            NaselennuyPunktInfo naselennuyPunktInfo = new NaselennuyPunktInfo();
            naselennuyPunktInfo.Show();
        }

        private void BtnAddLocomotive_Click(object sender, RoutedEventArgs e)
        {
            Locomotiveinfo locomotiveinfo = new Locomotiveinfo();
            locomotiveinfo.Show();
        }

        private void BtnAddLocomotiveType_Click(object sender, RoutedEventArgs e)
        {
            AddLocomotiveWindow addLocomotiveType = new AddLocomotiveWindow();
            addLocomotiveType.Show();
        }
        
        private void MarsruteLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServicePointManager.DefaultConnectionLimit = 999999999;
                numbertrain.ItemsSource = contract.getNumber();
                pointstart.ItemsSource = contract.getPointStart();
                pointend.ItemsSource = contract.getPointEnd();
                typetrain.ItemsSource = contract.getTypeVagon();
                listbox.ItemsSource = contract.getMarshruteData();
                
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream("ConnectiongError.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fileStream = new FileStream("MarshruteInfo.txt", FileMode.Append);
                byte[] arraybyte = Encoding.Default.GetBytes(listbox.SelectedItem.ToString());
                fileStream.Write(arraybyte, 0, arraybyte.Length);
                MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                fileStream.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream("SavingError.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }
        }

        private void Btn_Mail_Click(object sender, RoutedEventArgs e)
        {
            MailWorksWindows mailWorks = new MailWorksWindows();
            mailWorks.Show();
        }

        private void BtnSetTicket_Click(object sender, RoutedEventArgs e)
        {
            CreateTicketWindow createTicket = new CreateTicketWindow();
            createTicket.Show();
        }

       

        private void Btn_prodaction_Click(object sender, RoutedEventArgs e)
        {
            AddProdactionWindow addProdaction = new AddProdactionWindow();
            addProdaction.Show();
        }

        

        private void Btn_contragent_Click(object sender, RoutedEventArgs e)
        {
            AddContragentWindow addContragent = new AddContragentWindow();
            addContragent.Show();
        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            listcontragent.ItemsSource = contract.getContragent();
            listprodaction.ItemsSource = contract.getProdaction();
        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow createOrder = new CreateOrderWindow();
            createOrder.Show();
        }

        private void BtnLoadingInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orderlistbox.ItemsSource = contract.getOrder();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream("LoadingError.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orderlistbox.ItemsSource = contract.getTickets();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream("LoadingError.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }
        }

        private void BtnCreateTicket_Click(object sender, RoutedEventArgs e)
        {
            CreateTicketWindow createTicket = new CreateTicketWindow();
            createTicket.Show();
        }

        private void BtnPrintOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fileStream = new FileStream("OrderInfo.txt", FileMode.Append);
                byte[] arraybyte = Encoding.Default.GetBytes(orderlistbox.SelectedItem.ToString());
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

        private void Listbox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            contract.getMarshruteWheelMove();
        }

        private void Listbox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contract.getMarshruteWheelMove();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            contract.getUser();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            contract.Delete(ListUsers.SelectedItem.ToString());
        }
    }
}
