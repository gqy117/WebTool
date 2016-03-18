namespace WebToolService
{
    using System.Collections.Generic;

    public interface IWolService
    {
        ListWrapper<WolModel> GetWolById(int userId);

        ListWrapper<WolModel> GetWolById(int userId, JQueryTable model);

        void Insert(WolModel logOnModel);
    }
}