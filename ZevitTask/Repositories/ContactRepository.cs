using ZevitTask.ExceptionZevit;
using ZevitTask.Middleware;

namespace ZevitTask.Repositories
{
    public class ContactRepository : IContactRepository

    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }


        public List<Contact> Get()
        {
            return _context.Contacts.AsNoTracking().ToList();  
        }

        public Contact Get(Guid id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
                throw new CustomExceptionZevit("The record with the given id does't exist",Domain.Enums.ErrorCode.NotFound);
            return contact;
        }
       
        public Contact Add(Contact contact)
        {
            var dbcontact = _context.Contacts.Find(contact.Id);
            if(dbcontact != null)
            throw new Exception("Krknvox id");
              _context.Contacts.Add(contact);  
            return contact;
            
        }

        public Contact Update(Contact contact)
        {
           var dbcontact=_context.Contacts.Find(contact.Id);
           
            if (dbcontact == null)
                throw new Exception("Contact not found");

            dbcontact.FullName = contact.FullName;
            dbcontact.EmailAddress = contact.EmailAddress;
            dbcontact.PhoneNumber = contact.PhoneNumber;
            dbcontact.PhysicalAddress = contact.PhysicalAddress;

            return dbcontact;
        }

        public void Delete(Guid id)
        {
            var dbcontact= _context.Contacts.Find(id);
            if (dbcontact == null)
                throw new Exception("Chunenq chenq kara jnjenq");
            _context.Contacts.Remove(dbcontact);
            
        }

       
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
