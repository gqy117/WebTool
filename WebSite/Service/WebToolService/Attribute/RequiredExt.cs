using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebToolService
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class RequiredExtAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        #region Properties
        private bool _Enabled = true;
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; } }
        #endregion

        #region Constructors
        public RequiredExtAttribute(bool enabled = true)
            : base()
        {
            this.Enabled = enabled;
        }
        #endregion
        #region Methods
        public override bool IsValid(object value)
        {
            bool res = !this.Enabled ? true : base.IsValid(value);
            return res;
        }
        #endregion
    }
}
