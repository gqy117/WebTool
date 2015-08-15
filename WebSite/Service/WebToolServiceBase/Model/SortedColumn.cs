namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a sorted column from DataTables.
    /// </summary>
    public class SortedColumn
    {
        private const string Ascending = "asc";

        public SortedColumn(string propertyName, string sortingDirection)
        {
            this.PropertyName = propertyName;
            this.Direction = sortingDirection.Equals(Ascending) ? SortingDirection.Asc : SortingDirection.Desc;
        }

        /// <summary>
        /// Gets the name of the Property on the class to sort on.
        /// </summary>
        public string PropertyName { get; private set; }

        public SortingDirection Direction { get; private set; }

        public override int GetHashCode()
        {
            var directionHashCode = this.Direction.GetHashCode();

            return this.PropertyName != null ? this.PropertyName.GetHashCode() + directionHashCode : directionHashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var other = (SortedColumn)obj;

            if (other.Direction != this.Direction)
            {
                return false;
            }

            return other.PropertyName == this.PropertyName;
        }
    }
}
