﻿namespace WebToolService
{
    using System;
    using System.Linq;
    using Utilities;
    using WebToolRepository;

    public class UserService : ServiceBase, IUserService
    {
        private readonly AESHelper aESHelper;

        public UserService(AESHelper aESHelper)
        {
            this.aESHelper = aESHelper;
        }

        public UserModel GetUserModelByName(string encryptedUserName)
        {
            string userName = this.aESHelper.DecryptStringFromBytes(encryptedUserName);

            var userTable = this.CacheHelper.GetCacheTable("User", () => Context.Users);

            var user = userTable.FirstOrDefault(x => x.UserName == userName);
            var userModel = this.Mapper.Map<User, UserModel>(user);

            return userModel;
        }

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

        private User ConvertUser(LogOnModel logOnModel)
        {
            User user = new User();

            user = this.Mapper.Map<LogOnModel, User>(logOnModel);
            user.Password = logOnModel.Password.Hash();

            return user;
        }
    }
}
