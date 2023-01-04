using AutoMapper;
using MediatR;
using ZevitTask.Domain.Enums;
using ZevitTask.DTOs;
using ZevitTask.ExceptionZevit;

namespace ZevitTask.Commands.Contacts
{
    public class DeleteContactCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteContactCommand(Guid id) 
        {
            Id = id;
        }
    }


    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly DataContext _context;

        public DeleteContactCommandHandler(DataContext context)
        {
            _context = context; 
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {

            var existing = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (existing == null)
                throw new CustomExceptionZevit("Contact does not exist", ErrorCode.NotFound);

            _context.Contacts.Remove(existing);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
