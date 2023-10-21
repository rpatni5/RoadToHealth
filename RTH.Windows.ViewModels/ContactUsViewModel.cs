using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class ContactUsViewModel : ViewModelBase
    {
        
        public ContactUsViewModel()
        {
            FooterVisibility = true;
        }

        public string Message
        {
            get { return GetValue(() => Message); }
            set { SetValue(() => Message, value); }
        }
        RelayCommand _sendMessage;
        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessage ?? (_sendMessage = new RelayCommand(
                    (vm) =>
                    {
                        SendMessage("");
                    }, (vm) => { return true; }));
            }
        }
        public void SendMessage(string Host)
        {
            Process.Start("mailto://support@quealth.zendesk.com");
            //string to = "dawnoflavsingh@gmail.com";
            //string from = "lavsingh2011@gmail.com";
            //string subject = "Customer feedback";

            //MailMessage message = new MailMessage(from, to, subject, Message.Trim());
            //SmtpClient client = new SmtpClient(Host);
            //client.Timeout = 100;
            //if (string.IsNullOrEmpty(Host)) throw new ArgumentNullException("Server name is required!");
            //try
            //{
            //    client.Send(message);
            //}
            //catch (Exception ex)
            //{
            //   throw new Exception(string.Format("Exception caught in SendMessage(): {0}",
            //          ex.ToString()));
            //}
        }
        
    }
}
