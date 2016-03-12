namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Remoting.Contexts;
    using System.Text;
    using System.Web;
    using Utilities;
    using WebToolCulture;
    using WebToolRepository;

    public class WolService : ServiceBase, IWolService
    {
        public IList<WolModel> GetWolById(int userId)
        {
            var defaultModel = new JQueryTable
            {
                OrderBy = "WOLID OrderBy"
            };

            return this.GetWolById(userId, defaultModel);
        }

        public IList<WolModel> GetWolById(int userId, JQueryTable model)
        {
            IEnumerable<WOL> wolTable = this.CacheHelper.GetCacheTable("WOL", () => this.Context.WOLs);

            var wolList = wolTable.AsQueryable()
                .Where(x => x.UserId == userId)
                .Search(model.sSearch, x => x.WOLName.ContainsCaseInsensitive(model.sSearch))
                .OrderBy(model.OrderBy)
                .Skip(model.iDisplayStart).Take(model.iDisplayLength)
                .ToList();

            var res = this.Mapper.Map<IList<WOL>, IList<WolModel>>(wolList);

            return res;
        }

        public void Insert(WolModel logOnModel)
        {
            WOL wol = this.Mapper.Map<WolModel, WOL>(logOnModel);
            this.Context.WOLs.Add(wol);
            this.CommitChanges();
        }
    }
}
