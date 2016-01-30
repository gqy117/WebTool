namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Text;
    using Autofac;
    using Enyim.Caching;
    using Enyim.Caching.Memcached;
    using Microsoft.Practices.Unity;
    using Utilities;
    using WebToolRepository;
    using WebToolService;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Justification")]
    public class ServiceBase
    {
        #region Properties
        public virtual WebToolEntities Context { get; set; }

        public virtual int Count { get; set; }

        public ICacheHelper CacheHelper { get; set; }

        public ValidationContext ValidationContext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Justification")]
        public List<ValidationResult> ValidationResults { get; set; }

        public bool IsValid { get; set; }

        #endregion

        [InjectionMethod]
        public void Init(ICacheHelper cache, WebToolEntities webToolEntities)
        {
            this.Context = webToolEntities;
            this.CacheHelper = cache;
            this.IsValid = true;
            this.ValidationResults = new List<ValidationResult>();
        }

        #region Methods
        public void CommitChanges()
        {
            this.Context.SaveChanges();
        }
        #endregion
    }
}