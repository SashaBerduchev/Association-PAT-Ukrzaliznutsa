using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows;

namespace Association_PAT_Ukrzaliznutsa.EMail
{
    /// <summary>
    /// Логика взаимодействия для MailWorks.xaml
    /// </summary>
    public partial class MailWorks : Window
    {
        public MailWorks()
        {

            InitializeComponent();

            List<MailSet> mails;
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            mails = ukrzaliznutsaDBEntities.MailSet.ToList();
            mailfrom.ItemsSource = mails.ToList();
            mailto.ItemsSource = mails.ToList();

        }

        List<MarshrutesSet> marshrutes;
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            UkrzaliznutsaDBEntities ukrzaliznutsaDBEntities = new UkrzaliznutsaDBEntities();
            marshrutes = ukrzaliznutsaDBEntities.MarshrutesSet.ToList();
            datagrid.ItemsSource = marshrutes.Select(x => new { x.Locomotive, x.NumberTrain, x.PointStart, x.PointEnd });
            marshrutes.Clear();
        }

        string file;
        private void BtnAttach_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            file = openFileDialog.FileName;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress(mailfrom.SelectedItem.ToString());
                MailAddress to = new MailAddress(mailto.SelectedItem.ToString());
                MailMessage m = new MailMessage(from, to);
                Attachment attachment = new Attachment(file, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(file);
                disposition.ModificationDate = File.GetLastWriteTime(file);
                disposition.ReadDate = File.GetLastAccessTime(file);
                m.Body = datagrid.SelectedItem.ToString();
                m.Attachments.Add(attachment);

                // письмо представляет код html
                m.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient(server.Text, Convert.ToInt32(port.Text));
                // логин и пароль
                smtp.Credentials = new NetworkCredential(mailfrom.SelectedItem.ToString(), passfrom.Password);
                smtp.EnableSsl = checkbox.IsChecked.Value;
                smtp.Send(m);
                MessageBox.Show("Отправленно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream(@"Mail.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);

                }
                fileStreamLog.Close();
            }
            


        }

    }
}
