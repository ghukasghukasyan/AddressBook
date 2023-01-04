using MediatR;
using ZevitTask.Domain.Enums;
using ZevitTask.ExceptionZevit;

namespace ZevitTask.Queries.Contacts
{
    public class GetContactByIdQuery : IRequest<Contact>
    {

        public Guid Id { get; set; }

        public GetContactByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Contact>
    {
        private readonly DataContext _context;

        public GetContactByIdQueryHandler(DataContext context)
        {
            _context = context;
        }


        public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {   
            if (!await _context.Contacts.AnyAsync(x => x.Id == request.Id, cancellationToken))
            {
                throw new CustomExceptionZevit($"Contact with the given id ({request.Id}) does not exist",ErrorCode.NotFound);
            }
            
            var contact = _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (contact == null)
            {
                throw new Exception("Contact with the given Id does not exist");
            }

            return await contact;
        }
    }
}
