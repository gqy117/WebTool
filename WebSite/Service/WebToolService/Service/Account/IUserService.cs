namespace WebToolService
{
    public interface IUserService
    {
        UserModel GetUserModelByName(string encryptedUserName);

        bool Insert(LogOnModel logOnModel);

        bool IsExist(LogOnModel userModel);

        bool IsLogOnAllowed(LogOnModel userModel);
    }
}