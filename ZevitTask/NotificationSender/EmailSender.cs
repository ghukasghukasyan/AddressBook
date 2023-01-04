namespace ZevitTask.NotificationSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IDbConnection _connection;

        public EmailSender(IDbConnection connection)
        {
            _connection = connection;
        }

        public void SendNotification()
        {
            Console.WriteLine("Email was sent");
        }
    }
}
