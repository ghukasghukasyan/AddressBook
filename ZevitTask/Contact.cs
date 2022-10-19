using System.ComponentModel.DataAnnotations;

namespace ZevitTask
{
    public class Contact
    {
        public Guid Id { get; set; }
        
        [Required (ErrorMessage= "Full Name field is Required")]
        [StringLength(20,MinimumLength =5)]
        
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address field is Required")]
        [RegularExpression(@"\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b", ErrorMessage = ("You have entered invalid email address.Please try again." +
            " Email should be in this format name@example.com"))]
        
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number field is Required")]
        [RegularExpression(@"(([+374]{4}|[0]{1}))?([1-9]{2})(\d{6})", ErrorMessage = ("You have entered invalid phone number.Please try again." +
            " Phone number should be in this format +374xxxxxxxx"))]
        
        public string PhoneNumber { get; set; } = string.Empty;
        
        public string PhysicalAddress { get; set;} = string.Empty;

    }
}
