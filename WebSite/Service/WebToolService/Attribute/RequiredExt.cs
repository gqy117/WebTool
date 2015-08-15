namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class RequiredExtAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredExtAttribute()
            : this(true)
        {
        }

        public RequiredExtAttribute(bool enabled)
            : base()
        {
            this.Enabled = enabled;
        }

        public bool Enabled { get; protected set; }

        #region Methods
        public override bool IsValid(object value)
        {
            bool res = !this.Enabled ? true : base.IsValid(value);

            return res;
        }
        #endregion
    }
}
