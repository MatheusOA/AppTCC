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
        public ObservableRangeCollection<Message> ListMessages { get; }
        public ICommand SendCommand { get; set; }
        public string OutText { get; set; }

        public SupportViewModel()
        {
            ListMessages = new ObservableRangeCollection<Message>();

            SendCommand = new Command(() =>
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

                    SendFakeResponse();
                }
            });
        }

        public async Task SendFakeResponse()
        {
            await Task.Delay(1000);

            var response = new Message
            {
                Text = "Recurso ainda não funcional. Para dúvidas, entrar em contato com a equipe do Eye Tractor no site http://sitefake.com",
                IsTextIn = true,
                MessageDateTime = DateTime.Now
            };

            ListMessages.Add(response);
        }
    }
}
