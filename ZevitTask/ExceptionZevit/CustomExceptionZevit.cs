using ZevitTask.Domain.Enums;

namespace ZevitTask.ExceptionZevit
{
    public class CustomExceptionZevit : Exception
    {
        public ErrorCode Error { get; set; }

        public CustomExceptionZevit(string message, ErrorCode error):base(message)
        {
           Error = error;   
        }

        public CustomExceptionZevit()
        {

        }
    }
}
