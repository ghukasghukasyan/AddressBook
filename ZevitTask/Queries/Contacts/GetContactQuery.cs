using AutoMapper;
using MediatR;
using ZevitTask.DTOs;

namespace ZevitTask.Queries.Contacts
{
    public class GetContactQuery : IRequest<List<ContactDTO>>
    {
        public string Name { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }

        public GetContactQuery(string name, int? skip, int? take) : base()
        {
            Name = name;
            Skip = skip;
            Take = take;
        }
    }

    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<ContactDTO>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<List<ContactDTO>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contacts = _context.Contacts.AsNoTracking();
            if (request.Name != null)
                contacts = contacts.Where(c => c.FullName.Contains(request.Name));

            if (request.Skip != null)
                contacts = contacts.Skip(request.Skip.Value);


            if (request.Take != null)
                contacts = contacts.Take(request.Take.Value);

            return   _mapper.Map<List<ContactDTO>>(await contacts.ToListAsync());


        }


    }


}
