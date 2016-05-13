namespace DependencyInjection
{
    using AutoMapper;
    using WebToolRepository;
    using WebToolService;

    public class WOLProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<WOL, WolModel>();
        }
    }
}