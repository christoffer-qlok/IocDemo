using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocDemo
{
    public interface IMessageHandler
    {
        void SendMessage(string message);
        string GetMessage();
    }

    public class EmailHandler : IMessageHandler
    {
        public string GetMessage()
        {
            return "Hello from email";
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }
}
