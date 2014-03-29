using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using DataHelperLibrary;
using WebToolRepository;
using WebToolCulture;



namespace WebToolService
{
    public class WOLService : ServiceBase
    {
        #region Properties

        #endregion
        #region Constructors

        #endregion
        #region Methods
        #region Select

        public List<WOLModel> GetWOLById(int userId)
        {
            return GetWOLById(userId, new JQueryTable());
        }
        public List<WOLModel> GetWOLById(int userId, JQueryTable model)
        {
            var res = this.Context.SelectWOL(userId, model.iDisplayLength, model.iDisplayStart, model.OrderBy, model.sSearch).ToList<SelectWOL_Result,WOLModel>();
            return res;
        }
        #endregion
        #region Insert
        public void Insert(WOLModel loginModel)
        {
            WOL wol = loginModel.To<WOLModel, WOL>();
            Context.WOLs.Add(wol);
            CommitChanges();
        }
        #endregion
        #endregion
    }
}
