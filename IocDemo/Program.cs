namespace IocDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmailHandler handler = new EmailHandler();
            ChatService service = new ChatService(handler);
            service.SendMessageTo("John Doe", "Hello Joe");
        }
    }
}
