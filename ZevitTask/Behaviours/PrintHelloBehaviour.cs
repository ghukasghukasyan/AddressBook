using MediatR;

namespace ZevitTask.Behaviours
{
    public class PrintHelloBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>

    {
        public PrintHelloBehaviour()
        {

        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Print hello");
            var response = await next();
            Console.WriteLine("Print end Hello");

            return response;    
        }
    }
}
