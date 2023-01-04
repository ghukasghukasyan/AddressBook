namespace ZevitTask.NotificationSender
{
    public class RequestCounter : IRequestCounter
    {
       
        int count;

        public void RequestCount()
        {
            count++;
            Console.WriteLine("Request count is" + count);
        }
    }
}
