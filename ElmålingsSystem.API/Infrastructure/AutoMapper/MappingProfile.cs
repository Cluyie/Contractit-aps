using AutoMapper;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;

namespace ElmålingsSystem.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //<from, to>
            //returns a VM with links
            CreateMap<EjerKunde, EjerKundeLinked>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                         nameof(Controllers.EjerKundeController.GetEjerKunde),
                         new { ejerKundeId = src.KundeId })));
            //returns a VM for editing
            CreateMap<EjerKundeLinked, EjerKunde>();


            CreateMap<LejerKunde, LejerKundeLinked>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                     nameof(Controllers.LejerKundeController.GetLejerKundeById),
                     new { lejerKundeId = src.KundeId })));
            CreateMap<LejerKundeLinked, LejerKunde>();

            CreateMap<Installation, InstallationLinked>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                         nameof(Controllers.InstallationController.GetAllInstallationer),
                         new { installationId = src.InstallationsId })));
            CreateMap<InstallationLinked, Installation>();

            CreateMap<Måler, MålerLinked>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                         nameof(Controllers.MålerController.GetMålerByInstallationsId),
                         new { målerId = src.MålerId })));
            CreateMap<MålerLinked, Måler>();

            CreateMap<Måleværdier, MåleVærdierLinked>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                         nameof(Controllers.MåleVærdierController.GetAllMåleVærdierFromMålerIdAndDate),
                         new { måleraflæsningId = src.MåleraflæsningId })));
            CreateMap<MåleVærdierVM, Måleværdier>();
        }
    }
}
