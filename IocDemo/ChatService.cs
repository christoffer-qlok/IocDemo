using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocDemo
{
    public class ChatService
    {
        private IMessageHandler _messageHandler;

        public ChatService(IMessageHandler handler)
        {
            _messageHandler = handler;
        }

        public void SendMessageTo(string name, string message)
        {
            _messageHandler.SendMessage($"To {name}: {message}");
        }

        public string RecieveMessageFrom(string name)
        {
            string message = _messageHandler.GetMessage();
            return $"{name} says {message}";
        }
    }
}
