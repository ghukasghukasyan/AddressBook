using AutoMapper;
using MediatR;
using ZevitTask.DTOs;

namespace ZevitTask.Commands.Contacts
{
    public class CreateContactCommand : IRequest<ContactDTO>
    {
        public ContactDTO Contact { get; set; }
        public CreateContactCommand(ContactDTO contact)
        {
            Contact = contact;
        }
    }


    public class CreatContactCommandhandler : IRequestHandler<CreateContactCommand, ContactDTO>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
       
        public CreatContactCommandhandler(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactDTO> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var dbcontact = _context.Contacts.Find(request.Contact.Id);
            if (dbcontact != null)
                throw new Exception("Krknvox id");

            var contact=_mapper.Map<Contact>(request.Contact);

            var createdContact = _context.Contacts.Add(contact);

            await _context.SaveChangesAsync(cancellationToken);
            var result = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == createdContact.Entity.Id);
            return _mapper.Map<ContactDTO>(result);
        }
    }
}
