using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using WebToolService;
using DataHelperLibrary;

namespace WebTool
{
    public class TableBaseController<TMain> : BaseController where TMain : ITotalRecords
    {
        #region Properties
        public virtual Func<TMain, string[]> MainResultColumn
        {
            get;
            set;
        }
        public virtual List<TMain> MainList
        {
            get;
            set;
        }

        public int TotalRecords { get; set; }

        public virtual List<string> PropertyList
        {
            get;
            set;
        }
        #endregion
        #region Methods
        public virtual ActionResult JsonTable(JQueryTable model)
        {
            GetTotalRecords();
            return JSON(new
            {
                sEcho = model.sEcho,
                iTotalRecords = this.TotalRecords,
                iTotalDisplayRecords = this.TotalRecords,
                aaData = this.MainList.Select(this.MainResultColumn),
            });
        }
        public virtual void GetTotalRecords()
        {
            this.TotalRecords = (this.MainList != null && this.MainList.Count > 0) ? this.MainList.FirstOrDefault().TotalRecords : 0;
        }
        public virtual void GetMainResultColumn()
        {
            this.MainResultColumn = ((TMain x) =>
            {
                string[] res = new string[this.PropertyList.Count];
                for (int i = 0; i < this.PropertyList.Count; i++)
                {
                    res[i] = DataHelperLibrary.DataHelper.GetPropertyValue(x, this.PropertyList[i]);
                }
                return res;
            });
        }

        public virtual ActionResult GetJsonTable(JQueryTable model, Action action)
        {
            ReBindJQueryTable(model);
            action();
            return JsonTable(model);
        }
        public virtual void ReBindJQueryTable(JQueryTable model)
        {
            GetMainResultColumn();
            ReadOnlyCollection<SortedColumn> res = model.GetSortedColumns();
            StringBuilder sb = new StringBuilder();
            foreach (SortedColumn sortedColumn in res)
            {
                sb.Append(this.PropertyList[sortedColumn.PropertyName.ToInt32()]);
                sb.Append(" ");
                sb.Append(sortedColumn.Direction.ToString());
                sb.Append(",");
            }
            model.OrderBy = sb.ToString().Substring(0, sb.Length - 1);
        }
        #endregion
    }
}
