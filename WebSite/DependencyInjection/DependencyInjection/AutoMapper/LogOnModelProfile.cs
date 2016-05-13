namespace DependencyInjection
{
    using AutoMapper;
    using WebToolRepository;
    using WebToolService;

    public class LogOnModelProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<LogOnModel, User>();
        }
    }
}