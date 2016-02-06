namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Remoting.Contexts;
    using System.Text;
    using System.Web;
    using DataHelperLibrary;
    using Utilities;
    using WebToolCulture;
    using WebToolRepository;

    public class UserService : ServiceBase
    {
        #region Properties
        private readonly AESHelper aESHelper;
        #endregion

        #region Constructors
        public UserService(AESHelper aESHelper)
        {
            this.aESHelper = aESHelper;
        }
        #endregion

        #region Methods
        #region Select
        public UserModel GetUserModelByName(string encryptedUserName)
        {
            string userName = this.aESHelper.DecryptStringFromBytes(encryptedUserName);

            return this.CacheHelper.GetCache(userName, () => Context.Users.FirstOrDefault(x => x.UserName == userName).To<User, UserModel>());
        }
        #endregion
        #region Insert
        public bool Insert(LogOnModel logOnModel)
        {
            bool res = true;

            if (!this.IsExist(logOnModel))
            {
                User user = this.ConvertUser(logOnModel);
                user.CreationDate = DateTime.Now;
                Context.Users.Add(user);
                this.CommitChanges();
            }
            else
            {
                logOnModel.ErrorMessage = WebToolCulture.Resource.UIResource.UserAlreadyExist;
                res = false;
            }

            return res;
        }
        #endregion
        #region Check
        public bool IsExist(LogOnModel userModel)
        {
            return this.Context.Users.Any(x => x.UserName == userModel.UserName);
        }

        public bool IsLogOnAllowed(LogOnModel userModel)
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
        private User ConvertUser(LogOnModel logOnModel)
        {
            User user = new User();
            user = logOnModel.To<LogOnModel, User>();
            user.Password = logOnModel.Password.Hash();

            return user;
        }
        #endregion
    }
}
