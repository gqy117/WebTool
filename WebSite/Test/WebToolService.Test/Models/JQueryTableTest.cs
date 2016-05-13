namespace WebToolService.Test
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class JQueryTableTest
    {
        public JQueryTable JQueryTable { get; set; }

        [SetUp]
        public void Init()
        {
            this.JQueryTable = new JQueryTable();
        }

        [Test]
        public void SortedColumns_ShouldReturnACollectionOfSortedColumns_WheniSortingColsDoesNotHavaValue()
        {
            // Arrange
            this.JQueryTable.iSortingCols = null;

            // Act
            var acutal = this.JQueryTable.SortedColumns();

            // Assert
            ReadOnlyCollection<SortedColumn> expected = new List<SortedColumn>().AsReadOnly();

            acutal.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void SortedColumns_ShouldReturnACollectionOfSortedColumns_WheniSortingColsHasValue()
        {
            // Arrange
            this.JQueryTable.iSortingCols = 1;
            this.JQueryTable.iSortCol_ = new ReadOnlyCollection<int>(new List<int>() { 0 });
            this.JQueryTable.mDataProp_ = new ReadOnlyCollection<string>(new List<string>() { "WOLID" });
            this.JQueryTable.sSortDir_ = new ReadOnlyCollection<string>(new List<string>() { "asc" });

            // Act
            var acutal = this.JQueryTable.SortedColumns();

            // Assert
            ReadOnlyCollection<SortedColumn> expected = new List<SortedColumn>
            {
                new SortedColumn("WOLID", "asc")
            }.AsReadOnly();

            acutal.ShouldBeEquivalentTo(expected);
        }
    }
}