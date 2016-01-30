namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using WebToolCulture.Resource;

    [Serializable]
    public class LogOnModel : LogOnBaseModel
    {
        #region Constructors
        public LogOnModel()
        {
            this.RememberMe = true;
        }
        #endregion

        [RequiredExt(ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = "UserNameIsRequired")]
        [StringLength(10, ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = ("UserNameCannotBeLongerThan10Characters"))]
        public override string UserName
        {
            get;
            set;
        }

        [Required(ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = "PasswordIsRequired")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = ("PasswordCannotBeLongerThan20Characters"))]
        public virtual string Password
        {
            get;
            set;
        }

        public bool RememberMe { get; set; }

        public string ErrorMessage { get; set; }
    }
}
