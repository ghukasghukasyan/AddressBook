

namespace ZevitTask.Repositories


{
    public interface IContactRepository
    {
        List<Contact> Get();
        Contact Get(Guid id);
        Contact Add(Contact contact);
        Contact Update(Contact contact);
        void Delete(Guid id);
        void SaveChanges();
    }
}
