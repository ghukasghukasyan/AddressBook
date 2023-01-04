namespace ZevitTask.NotificationSender
{
    public class DbConnection : IDbConnection
    {
        private readonly IEmailSender _sender;
        private readonly ITeamSender _teamSender;

        public DbConnection(IEmailSender sender, ITeamSender teamSender)
        {
            _teamSender = teamSender;
            _sender = sender;
        }

        public void Connect()
        {
            Console.WriteLine("Db is connected");
        }
    }
}
