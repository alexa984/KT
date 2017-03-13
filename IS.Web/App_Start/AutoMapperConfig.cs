
namespace IS.Web.App_Start
{
    using AutoMapper;
    using Data.Models;
    using Models;
    using ViewModels.AccountViewModels;
    using ViewModels.ProfileViewModels;
    using ViewModels.BusinessProfileViewModels;
    using ViewModels.ServiceViewModels;
    using ViewModels.BranchViewModels;

    public class AutoMapperConfig
    {
        public static IMapper Execute()
        {
            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Business, RegisterViewModel>()
               .ForAllOtherMembers(x => x.Ignore());
               cfg.CreateMap<Business, LoginViewModel>();
               cfg.CreateMap<ISUser, RegisterViewModel>()
               .ForAllOtherMembers(x => x.Ignore());
               cfg.CreateMap<ISUser, ProfileViewModel>();
               cfg.CreateMap<ProfileViewModel, ISUser>()
               .ForAllOtherMembers(x => x.Ignore());
               cfg.CreateMap<Business, BusinessProfileViewModel>()
               .ForAllOtherMembers(x => x.Ignore());
               cfg.CreateMap<Service, ServiceViewModel>();
               cfg.CreateMap<Branch, BranchViewModel>()
               .ForAllOtherMembers(x => x.Ignore());

           });

            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            var subDest1 = mapper.Map<ISUser, RegisterViewModel>(new ISUser());
            var subDest2 = mapper.Map<Business, RegisterViewModel>(new Business());
            var subDest3 = mapper.Map<Business, LoginViewModel>(new Business());
            var subDest5 = mapper.Map<Business, BusinessProfileViewModel>(new Business());
            var subDest6 = mapper.Map<Service, ServiceViewModel>(new Service());
            var subDest7 = mapper.Map<Branch, BranchViewModel>(new Branch());

            return mapper;
        }
    }
}