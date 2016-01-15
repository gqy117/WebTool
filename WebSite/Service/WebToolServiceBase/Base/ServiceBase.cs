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
    using WebToolRepository;
    using WebToolService;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Justification")]
    public class ServiceBase : IServiceBase
    {
        #region Properties
        private WebToolEntities context = null;

        private List<ValidationResult> validationResults = new List<ValidationResult>();

        private bool isValid = true;

        private ICacheHelper cacheHelper;
        
        public virtual WebToolEntities Context
        {
            get
            {
                this.context = this.context ?? new WebToolEntities();

                return this.context;
            }
        }

        public virtual int Count { get; set; }

        public ICacheHelper CacheHelper
        {
            get { return this.cacheHelper; }

            set { this.cacheHelper = value; }
        }

        public ValidationContext ValidationContext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Justification")]
        public List<ValidationResult> ValidationResults
        {
            get { return this.validationResults; }

            set { this.validationResults = value; }
        }

        public bool IsValid
        {
            get { return this.isValid; }

            set { this.isValid = value; }
        }

        #endregion

        [InjectionMethod]
        public void Init(ICacheHelper cache)
        {
            this.cacheHelper = cache;
        }

        #region Methods
        public void CommitChanges()
        {
            this.Context.SaveChanges();
        }

        public void Validate(object[] arg)
        {
            this.ValidationResults = new List<ValidationResult>();

            foreach (var o in arg)
            {
                this.ValidationContext = new ValidationContext(o, null, null);
                List<ValidationResult> currentResults = new List<ValidationResult>();
                this.IsValid = this.IsValid == false ? false : Validator.TryValidateObject(o, this.ValidationContext, this.validationResults, true);
                this.ValidationResults.AddRange(currentResults);
            }
        }
        #endregion
    }
}