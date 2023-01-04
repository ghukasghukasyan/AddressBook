using AutoMapper;
using MediatR;
using ZevitTask.Domain.Enums;
using ZevitTask.DTOs;
using ZevitTask.ExceptionZevit;

namespace ZevitTask.Commands.Contacts
{
    public class UpdateContactCommand : IRequest<ContactDTO>
    {
        public ContactDTO Contact { get; set; }

        public UpdateContactCommand(ContactDTO contact)
        {
            Contact = contact;
        }
    }

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ContactDTO>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactDTO> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
 
            var contact = _mapper.Map<Contact>(request.Contact);
            if (!await _context.Contacts.AnyAsync(x=>x.Id==contact.Id,cancellationToken))
                throw new CustomExceptionZevit("There is no record with given ID", ErrorCode.NotFound);
            
            var updatedContact =  _context.Contacts.Update(contact);
            
            await _context.SaveChangesAsync(cancellationToken);
            var result = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == updatedContact.Entity.Id,cancellationToken);
            return _mapper.Map<ContactDTO>(result);

        }
    }
}






