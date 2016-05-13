namespace DependencyInjection
{
    using AutoMapper;
    using WebToolRepository;
    using WebToolService;

    public class WolModelProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<WolModel, WOL>();
        }
    }
}