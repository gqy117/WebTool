namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebToolService;

    public class JQueryDataTablesModelBinder : IModelBinder
    {
        #region Private Variables (Request Keys)

        private const string DisplayStartKey = "iDisplayStart";

        private const string DisplayLengthKey = "iDisplayLength";

        private const string ColumnsKey = "iColumns";

        private const string Search = "sSearch";

        private const string EscapeRegex = "bRegex";

        private const string SortableKey = "bSortable_";

        private const string SearchableKey = "bSearchable_";

        private const string SearchKey = "sSearch_";

        private const string EscapeRegexKey = "bRegex_";

        private const string SortingColsKey = "iSortingCols";

        private const string SortColKey = "iSortCol_";

        private const string SortDirKey = "sSortDir_";

        private const string EchoKey = "sEcho";

        private const string DataPropKey = "mDataProp_";

        private ModelBindingContext bindingContext;

        #endregion

        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }

            this.bindingContext = bindingContext;

            ////Bind Model
            var dataTablesRequest = new JQueryTable();
            dataTablesRequest.sEcho = this.GetA<int>(EchoKey);
            if (dataTablesRequest.sEcho <= 0)
            {
                throw new InvalidOperationException("Expected the request to have a sEcho value greater than 0");
            }

            dataTablesRequest.iColumns = this.GetA<int>(ColumnsKey);
            dataTablesRequest.bRegex = this.GetA<bool>(EscapeRegex);
            dataTablesRequest.bRegex_ = this.GetAList<bool>(EscapeRegexKey);
            dataTablesRequest.bSearchable_ = this.GetAList<bool>(SearchableKey);
            dataTablesRequest.bSortable_ = this.GetAList<bool>(SortableKey);
            dataTablesRequest.iDisplayLength = this.GetA<int>(DisplayLengthKey);
            dataTablesRequest.iDisplayStart = this.GetA<int>(DisplayStartKey);
            dataTablesRequest.iSortingCols = this.GetANullableValue<int>(SortingColsKey);

            if (dataTablesRequest.iSortingCols.HasValue)
            {
                dataTablesRequest.iSortCol_ = this.GetAList<int>(SortColKey);
                dataTablesRequest.sSortDir_ = this.GetStringList(SortDirKey);

                if (dataTablesRequest.iSortingCols.Value
                    != dataTablesRequest.iSortCol_.Count)
                {
                    throw new InvalidOperationException(string.Format("Amount of items contained in iSortCol_ {0} do not match the amount specified in iSortingCols which is {1}", dataTablesRequest.iSortCol_.Count, dataTablesRequest.iSortingCols.Value));
                }

                if (dataTablesRequest.iSortingCols.Value
                    != dataTablesRequest.sSortDir_.Count)
                {
                    throw new InvalidOperationException(string.Format("Amount of items contained in sSortDir_ {0} do not match the amount specified in iSortingCols which is {1}", dataTablesRequest.sSortDir_.Count, dataTablesRequest.iSortingCols.Value));
                }
            }

            dataTablesRequest.sSearch = this.GetString(Search);
            dataTablesRequest.sSearch_ = this.GetStringList(SearchKey);
            dataTablesRequest.mDataProp_ = this.GetStringList(DataPropKey);

            return dataTablesRequest;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves an IList of strings from the ModelBindingContext based on the key provided.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ReadOnlyCollection<string> GetStringList(string key)
        {
            var list = new List<string>();
            bool hasMore = true;
            int i = 0;
            while (hasMore)
            {
                var newKey = key + i.ToString();

                // No need to use a prefix since data tables will not prefix the request names        
                var valueResult = this.bindingContext.ValueProvider.GetValue(newKey);

                if (valueResult == null)
                {
                    // If valueResult is still null then we know the value is not in the ModelBindingContext
                    // cease execution of this forloop
                    hasMore = false;
                    continue;
                }

                list.Add((string)valueResult.ConvertTo(typeof(string)));

                i++;
            }

            return list.AsReadOnly();
        }

        private ReadOnlyCollection<T> GetAList<T>(string key) where T : struct
        {
            var list = new List<T>();
            bool hasMore = true;
            int i = 0;
            while (hasMore)
            {
                var newKey = key + i.ToString();

                var valueResult = this.bindingContext.ValueProvider.GetValue(newKey);

                if (valueResult == null)
                {
                    // If valueResult is still null then we know the value is not in the ModelBindingContext
                    // cease execution of this forloop
                    hasMore = false;
                    continue;
                }

                list.Add((T)valueResult.ConvertTo(typeof(T)));
                i++;
            }

            return list.AsReadOnly();
        }

        /// <summary>
        /// Retrieves a string from the ModelBindingContext based on the key provided.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetString(string key)
        {
            var valueResult = this.bindingContext.ValueProvider.GetValue(key);

            if (valueResult == null)
            {
                return null;
            }

            return (string)valueResult.ConvertTo(typeof(string));
        }

        private T GetA<T>(string key) where T : struct
        {
            var valueResult = this.bindingContext.ValueProvider.GetValue(key);

            if (valueResult == null)
            {
                return new T();
            }

            return (T)valueResult.ConvertTo(typeof(T));
        }

        private T? GetANullableValue<T>(string key) where T : struct
        {
            var valueResult = this.bindingContext.ValueProvider.GetValue(key);

            if (valueResult == null)
            {
                return null;
            }

            return (T?)valueResult.ConvertTo(typeof(T));
        }

        #endregion
    }
}