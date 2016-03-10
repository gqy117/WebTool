namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Devshorts.MonadicNull;
    using UnconstrainedMelody;
    using WebToolService;

    public class TableBaseController : BaseController
    {
        public virtual IEnumerable<ITotalRecords> MainList
        {
            get;
            set;
        }

        public virtual Func<ITotalRecords, string[]> MainResultColumn
        {
            get;
            set;
        }

        public virtual IList<string> PropertyList
        {
            get;
            set;
        }

        public int TotalRecords { get; set; }

        public virtual ActionResult GetJsonTable(JQueryTable model, Action action)
        {
            this.ReBindJQueryTable(model);
            action();

            return this.JsonTable(model);
        }

        public virtual ActionResult JsonTable(JQueryTable model)
        {
            this.SetTotalRecords();
            return this.JSON(new
            {
                sEcho = model.sEcho,
                iTotalRecords = this.TotalRecords,
                iTotalDisplayRecords = this.TotalRecords,
                aaData = this.MainList.Select(this.MainResultColumn),
            });
        }

        public virtual void ReBindJQueryTable(JQueryTable model)
        {
            this.SetMainResultColumn();
            ReadOnlyCollection<SortedColumn> res = model.SortedColumns();
            StringBuilder sb = new StringBuilder();

            foreach (SortedColumn sortedColumn in res)
            {
                int columnNumber = int.Parse(sortedColumn.PropertyName);

                sb.Append(this.PropertyList[columnNumber]);
                sb.Append(" ");
                sb.Append(Enums.GetDescription(sortedColumn.Direction));
                sb.Append(",");
            }

            model.OrderBy = sb.ToString().Substring(0, sb.Length - 1);
        }

        public virtual void SetMainResultColumn()
        {
            this.MainResultColumn = (ITotalRecords x) =>
            {
                string[] res = new string[this.PropertyList.Count];
                for (int i = 0; i < this.PropertyList.Count; i++)
                {
                    res[i] = Option.Safe(() => x.GetType().GetProperty(this.PropertyList[i]).GetValue(x, null).ToString()).GetValueOrDefault();
                }

                return res;
            };
        }

        public virtual void SetTotalRecords()
        {
            var list = this.MainList.ToList();

            this.TotalRecords = list.Count > 0 ? list.FirstOrDefault().TotalRecords : 0;
        }
    }
}
