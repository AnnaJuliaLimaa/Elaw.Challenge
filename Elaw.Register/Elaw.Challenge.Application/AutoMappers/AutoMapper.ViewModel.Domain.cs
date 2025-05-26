using Elaw.Challenge.Domain;

namespace Elaw.Challenge.Application
{
    public class ViewModelDomain : AutoMapper.Profile
    {
        public ViewModelDomain()
        {
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.AddressId))
                .ForPath(dest => dest.Address.Id, opt => opt.MapFrom(src => src.AddressId))
                .ForPath(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForPath(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.Address.City))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<AddressViewModel, Address>();
        }
    }
}