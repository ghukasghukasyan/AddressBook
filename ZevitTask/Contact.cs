using System.ComponentModel.DataAnnotations;

namespace ZevitTask
{
    public class Contact
    {
        public int Id { get; set; }
       
        public string FullName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PhysicalAddress { get; set; } = string.Empty;


    }
}
