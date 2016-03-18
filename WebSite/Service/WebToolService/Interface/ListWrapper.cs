namespace WebToolService
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListWrapper<T> : ITotalRecords
    {
        public IList<T> List { get; set; }

        public int TotalRecords { get; set; }
    }
}