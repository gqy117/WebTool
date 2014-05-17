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
using WebToolRepository;
using WebToolService;

namespace WebToolService
{
    public class ServiceBase : IServiceBase
    {
        #region Properties
        private WebToolEntities _context = null;
        public virtual WebToolEntities Context
        {
            get
            {
                _context = _context ?? new WebToolEntities();
                return _context;
            }
        }
        public virtual int Count { get; set; }
        #region Cache
        public ICacheHelper CacheHelper = WebToolService.BootStrap.Container.Resolve<ICacheHelper>();
        #endregion
        #region Validation
        public ValidationContext ValidationContext { get; set; }
        public List<ValidationResult> ValidationResults = new List<ValidationResult>();
        private bool _IsValid = true;
        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }
        #endregion
        #endregion
        #region Constructors
        public ServiceBase()
        {

        }
        #endregion
        #region Methods
        public void CommitChanges()
        {
            Context.SaveChanges();
        }
        public void Validate(object[] arg)
        {
            this.ValidationResults = new List<ValidationResult>();

            foreach (var o in arg)
            {
                this.ValidationContext = new ValidationContext(o, null, null);
                List<ValidationResult> validationResults = new List<ValidationResult>();
                this.IsValid = this.IsValid == false ? false : Validator.TryValidateObject(o, this.ValidationContext, validationResults, true);
                this.ValidationResults.AddRange(validationResults);
            }
        }


        #endregion
    }
}