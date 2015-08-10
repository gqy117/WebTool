namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using WebToolCulture.Resource;

    [Serializable]
    public class LoginModel : LoginBaseModel
    {
        private bool rememberMe = true;

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

        public bool RememberMe
        {
            get { return this.rememberMe; }

            set { this.rememberMe = value; }
        }

        public string ErrorMessage { get; set; }
    }
}
