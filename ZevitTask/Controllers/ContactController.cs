using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZevitTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
       
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }
       
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Contacts.AsNoTracking().ToListAsync());
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Contact>> Get(int id)
        {
            Contact hero = await _context.Contacts.AsNoTracking().SingleAsync(x=>x.Id==id);
            if (hero == null)
                return BadRequest("Hero not found");
            return Ok(hero);
        }


        [HttpPost]

        public async Task<IActionResult> AddHero(Contact hero)
        {
            _context.Contacts.Add(hero);
            await _context.SaveChangesAsync();
            
            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> UpdateHero(Contact request)
        {
            var dbhero = await _context.Contacts.FindAsync(request.Id);
            if (dbhero == null)
                return BadRequest("Hero not found");

            dbhero.FullName = request.FullName;
            dbhero.EmailAddress = request.EmailAddress;
            dbhero.PhoneNumber = request.PhoneNumber;
            dbhero.PhysicalAddress=request.PhysicalAddress;
           
            await _context.SaveChangesAsync();  
            return Ok(dbhero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> Delete(int id)
        {
            var hero = await _context.Contacts.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found");

            _context.Contacts.Remove(hero);
            await _context.SaveChangesAsync();
           
            return Ok(hero);
        }


    }
}
