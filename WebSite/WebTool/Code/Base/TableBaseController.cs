﻿namespace WebTool
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
        public virtual IList<string> PropertyList
        {
            get;
            set;
        }

        public virtual ActionResult JsonTable<T>(JQueryTable model, ListWrapper<T> mainList, Func<T, string[]> mainResultColumn)
        {
            return this.JSON(new
            {
                sEcho = model.sEcho,
                iTotalRecords = mainList.TotalRecords,
                iTotalDisplayRecords = mainList.TotalRecords,
                aaData = mainList.List.Select(mainResultColumn),
            });
        }

        public virtual void ReBindJQueryTable(JQueryTable model)
        {
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

        public virtual Func<T, string[]> SetMainResultColumn<T>()
        {
            return (T x) =>
            {
                string[] res = new string[this.PropertyList.Count];
                for (int i = 0; i < this.PropertyList.Count; i++)
                {
                    res[i] = Option.Safe(() => x.GetType().GetProperty(this.PropertyList[i]).GetValue(x, null).ToString()).GetValueOrDefault();
                }

                return res;
            };
        }
    }
}
