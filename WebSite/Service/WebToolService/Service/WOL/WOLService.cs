namespace WebToolService
{
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;
    using WebToolRepository;

    public class WolService : ServiceBase, IWolService
    {
        public ListWrapper<WolModel> GetWolById(int userId)
        {
            var defaultModel = new JQueryTable
            {
                OrderBy = "WOLID OrderBy"
            };

            return this.GetWolById(userId, defaultModel);
        }

        public ListWrapper<WolModel> GetWolById(int userId, JQueryTable model)
        {
            var wolTable = this.CacheHelper.GetCacheTable("WOL", () => this.Context.WOLs).ToList();

            var wolList = wolTable.AsQueryable()
                .Where(x => x.UserId == userId)
                .Search(model.sSearch, x => x.WOLName.ContainsCaseInsensitive(model.sSearch))
                .OrderBy(model.OrderBy)
                .Skip(model.iDisplayStart).Take(model.iDisplayLength)
                .ToList();

            var res = this.Mapper.Map<IList<WOL>, IList<WolModel>>(wolList);

            return new ListWrapper<WolModel>
            {
                List = res,
                TotalRecords = wolTable.Count
            };
        }

        public void Insert(WolModel logOnModel)
        {
            WOL wol = this.Mapper.Map<WolModel, WOL>(logOnModel);
            this.Context.WOLs.Add(wol);
            this.CommitChanges();
        }
    }
}
