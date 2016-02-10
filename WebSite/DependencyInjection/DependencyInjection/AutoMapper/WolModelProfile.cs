namespace DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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