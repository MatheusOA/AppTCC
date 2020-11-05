using AppTCC.Interfaces;
using AppTCC.Models;
using AppTCC.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTCC.ViewModels
{
    public class SupportViewModel
    {
        private MessageService _messageService = new MessageService();
        public ObservableRangeCollection<Message> ListMessages { get; }
        public ICommand SendCommand { get; set; }
        public string OutText { get; set; }

        public SupportViewModel()
        {
            ListMessages = new ObservableRangeCollection<Message>();

            LoadMessages();

            SendCommand = new Command(async () =>
            {
                if (!string.IsNullOrWhiteSpace(OutText))
                {
                    var message = new Message
                    {
                        Text = OutText,
                        IsTextIn = false,
                        MessageDateTime = DateTime.Now
                    };

                    OutText = string.Empty;
                    ListMessages.Add(message);

                    await SendMessage(message.Text);
                }
            });
        }

        public async Task LoadMessages()
        {
            List<Message> messages = await _messageService.GetMessages();

            if (messages == null)
            {
                return;
            }

            foreach (Message message in messages)
            {
                ListMessages.Add(message);
            }
        }

        public async Task SendMessage(string message)
        {
            await _messageService.SendMessage(message);
        }
    }
}
