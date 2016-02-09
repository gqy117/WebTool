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

    public class WOLProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<WOL, WolModel>();
        }
    }
}