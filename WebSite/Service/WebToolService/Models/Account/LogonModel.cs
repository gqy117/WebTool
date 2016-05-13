namespace WebToolService
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using WebToolCulture.Resource;

    [Serializable]
    public class LogOnModel : LogOnBaseModel
    {
        public LogOnModel()
        {
            this.RememberMe = true;
        }

        public string ErrorMessage { get; set; }

        [Required(ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = "PasswordIsRequired")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = ("PasswordCannotBeLongerThan20Characters"))]
        public virtual string Password
        {
            get;
            set;
        }

        public bool RememberMe { get; set; }

        [RequiredExt(ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = "UserNameIsRequired")]
        [StringLength(10, ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = ("UserNameCannotBeLongerThan10Characters"))]
        public override string UserName
        {
            get;
            set;
        }
    }
}
