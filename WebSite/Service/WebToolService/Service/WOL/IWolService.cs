namespace WebToolService
{
    using System.Collections.Generic;

    public interface IWolService
    {
        IList<WolModel> GetWolById(int userId);

        IList<WolModel> GetWolById(int userId, JQueryTable model);

        void Insert(WolModel logOnModel);
    }
}