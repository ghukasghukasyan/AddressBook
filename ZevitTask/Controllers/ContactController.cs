using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZevitTask.DTOs;
using ZevitTask.Queries.Contacts;

namespace ZevitTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DataContext _context;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ContactDTO>>> Get(
            [FromQuery] string name,
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            var result = await _mediator.Send(new GetContactQuery(name, skip, take));

            return Ok(result);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Contact>> Get(Guid? id)
        {
            Contact contact = await _context.Contacts.AsNoTracking().SingleAsync(x=>x.Id.Equals(id));
            if (contact == null)
                return BadRequest("Contact not found");
            return Ok(contact);
        }


        [HttpPost]

        public async Task<IActionResult> AddContact(Contact contact)
        {
            var dbcontact = await _context.Contacts.FindAsync(contact.Id);
           
            if (dbcontact!=null)
                return BadRequest($"Contact with the given Id({contact.Id}) already exists");

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        
        public async Task<ActionResult<Contact>> UpdateContact(Contact request)
        {
            var dbcontact = await _context.Contacts.FindAsync(request.Id);
            if (dbcontact == null)
                return BadRequest("Contact not found");

            dbcontact.FullName = request.FullName;
            dbcontact.EmailAddress = request.EmailAddress;
            dbcontact.PhoneNumber = request.PhoneNumber;
            dbcontact.PhysicalAddress=request.PhysicalAddress;
           
            await _context.SaveChangesAsync();  
            return Ok(dbcontact);
        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<List<Contact>>> Delete(Guid? id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                return BadRequest("Contact not found");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }
    }
}
