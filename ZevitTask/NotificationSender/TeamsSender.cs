namespace ZevitTask.NotificationSender
{
    public class TeamsSender : ITeamSender
    {

        public void SendNotification()
        {
            Console.WriteLine("Teams message was sent");
        }
    }
}
