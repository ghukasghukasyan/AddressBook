using AutoMapper;
using ZevitTask.DTOs;

namespace ZevitTask.Mappings
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(x => x.PhysicalAddress, opt => opt.MapFrom(src => src.PhysicalAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ReverseMap();
        }
    }
}
