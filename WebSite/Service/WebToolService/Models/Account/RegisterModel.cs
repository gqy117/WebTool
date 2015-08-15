namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using WebToolCulture.Resource;

    public class RegisterModel : LogOnModel
    {
        [Required(ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = "ConfirmPasswordIsRequired")]
        [DataType(DataType.Password)]
        [System.Web.Mvc.Compare("Password", ErrorMessageResourceType = typeof(UIResource), ErrorMessageResourceName = "ThePasswordAndConfirmationPasswordDoNotMatch")]
        public string ConfirmPassword { get; set; }
    }
}
