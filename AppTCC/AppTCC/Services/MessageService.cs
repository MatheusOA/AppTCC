using AppTCC.Models;
using AppTCC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTCC.Services
{
    public class MessageService
    {
        public MessageRepository _messageRepository = new MessageRepository();

        public async Task<List<Message>> GetMessages()
        {
            List<Message> response = new List<Message>();
            List<UserMessage> messages = await _messageRepository.GetMessages();

            if (messages == null)
            {
                return response;
            }

            foreach (UserMessage message in messages)
            {
                response.Add(new Message()
                {
                    IsTextIn = !message.IsAuthor,
                    MessageDateTime = message.MessageDateTime,
                    Text = message.Text
                });
            }

            return response;
        }

        public async Task SendMessage(string message)
        {
            SendMessage newMessage = new SendMessage()
            {
                Message = message
            };

            await _messageRepository.SendMessage(newMessage);
            return;
        }
    }
}
