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
    using WebToolCulture;
    using WebToolRepository;

    public class WolService : ServiceBase
    {
        #region Properties

        #endregion
        #region Constructors

        #endregion
        #region Methods
        #region Select

        public IList<WolModel> GetWolById(int userId)
        {
            return this.GetWolById(userId, new JQueryTable());
        }

        public IList<WolModel> GetWolById(int userId, JQueryTable model)
        {
            var res = this.Context.SelectWOL(userId, model.iDisplayLength, model.iDisplayStart, model.OrderBy, model.sSearch).ToList<SelectWOL_Result, WolModel>();
            
            return res;
        }
        #endregion
        #region Insert
        public void Insert(WolModel logOnModel)
        {
            WOL wol = logOnModel.To<WolModel, WOL>();
            this.Context.WOLs.Add(wol);
            this.CommitChanges();
        }
        #endregion
        #endregion
    }
}
