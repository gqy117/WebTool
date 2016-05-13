namespace DependencyInjection
{
    using AutoMapper;
    using WebToolRepository;
    using WebToolService;

    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<User, UserModel>();
        }
    }
}