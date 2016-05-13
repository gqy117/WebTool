namespace WebToolService
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Microsoft.Practices.Unity;
    using Utilities;
    using WebToolRepository;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Justification")]
    public abstract class ServiceBase
    {
        public ICacheHelper CacheHelper { get; set; }

        public virtual WebToolEntities Context { get; set; }

        public virtual int Count { get; set; }

        public bool IsValid { get; set; }

        public IMapper Mapper { get; private set; }

        public ValidationContext ValidationContext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Justification")]
        public List<ValidationResult> ValidationResults { get; set; }

        public void CommitChanges()
        {
            this.Context.SaveChanges();
        }

        [InjectionMethod]
        public void Init(ICacheHelper cache, WebToolEntities webToolEntities, IMapper mapper)
        {
            this.Context = webToolEntities;
            this.CacheHelper = cache;
            this.IsValid = true;
            this.ValidationResults = new List<ValidationResult>();
            this.Mapper = mapper;
        }
    }
}