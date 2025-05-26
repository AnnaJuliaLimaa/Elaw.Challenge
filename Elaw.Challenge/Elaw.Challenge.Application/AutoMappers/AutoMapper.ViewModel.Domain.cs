using Elaw.Challenge.Domain;

namespace Elaw.Challenge.Application
{
    public class ViewModelDomain : AutoMapper.Profile
    {
        public ViewModelDomain()
        {
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(src => src.AddressId, opt => opt.MapFrom(dest => dest.AddressId))
                .ForPath(src => src.Address.Id, opt => opt.MapFrom(dest => dest.AddressId))
                .ForPath(src => src.Address.Number, opt => opt.MapFrom(dest => dest.Address.Number))
                .ForPath(src => src.Address.ZipCode, opt => opt.MapFrom(dest => dest.Address.ZipCode))
                .ForPath(src => src.Address.City, opt => opt.MapFrom(dest => dest.Address.City))
                .ForPath(src => src.Address.Street, opt => opt.MapFrom(dest => dest.Address.Street))
                .ForPath(src => src.Address.State, opt => opt.MapFrom(dest => dest.Address.State))
                .ForMember(src => src.Id, opt => opt.MapFrom(dest => dest.Id));

            CreateMap<AddressViewModel, Address>();
        }
    }
}