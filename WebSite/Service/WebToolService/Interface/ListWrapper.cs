namespace WebToolService
{
    using System.Collections.Generic;

    public class ListWrapper<T> : ITotalRecords
    {
        public IList<T> List { get; set; }

        public int TotalRecords { get; set; }
    }
}