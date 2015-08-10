namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Remoting.Contexts;
    using System.Text;
    using System.Web;
    using Autofac.Extras.DynamicProxy2;
    using DataHelperLibrary;
    using Enyim.Caching;
    using Enyim.Caching.Memcached;
    using WebToolCulture;
    using WebToolRepository;

    ////[Intercept(typeof(Validation))]
    public class UserService : ServiceBase
    {
        #region Properties

        #endregion
        #region Constructors

        #endregion
        #region Methods
        #region Select
        public UserModel GetUserModelByName(string userNameEncryped)
        {
            string userName = Utility.AESHelper.DecryptStringFromBytes(userNameEncryped);

            return this.CacheHelper.GetCache(userName, () => Context.Users.FirstOrDefault(x => x.UserName == userName).To<User, UserModel>());
        }
        #endregion
        #region Insert
        public bool Insert(LoginModel loginModel)
        {
            bool res = true;

            if (!this.IsExist(loginModel))
            {
                User user = this.ConvertUser(loginModel);
                user.CreationDate = DateTime.Now;
                Context.Users.Add(user);
                this.CommitChanges();
            }
            else
            {
                loginModel.ErrorMessage = WebToolCulture.Resource.UIResource.UserAlreadyExist;
                res = false;
            }

            return res;
        }
        #endregion
        #region Check
        public bool IsExist(LoginModel userModel)
        {
            return this.Context.Users.Any(x => x.UserName == userModel.UserName);
        }

        public bool IsLoginAllowed(LoginModel userModel)
        {
            bool res = true;
            string encryptedPassword = userModel.Password.Hash();
            User user = this.Context.Users.FirstOrDefault(x => x.UserName == userModel.UserName);

            if (user == null || user.Password != encryptedPassword)
            {
                userModel.ErrorMessage = WebToolCulture.Resource.UIResource.UserNameOrPasswordError;
                res = false;
            }

            return res;
        }
        #endregion
        private User ConvertUser(LoginModel loginModel)
        {
            User user = new User();
            user = loginModel.To<LoginModel, User>();
            user.Password = loginModel.Password.Hash();

            return user;
        }
        #endregion
    }
}
