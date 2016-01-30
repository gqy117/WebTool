﻿namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class JQueryTableTest
    {
        public JQueryTable JQueryTable { get; set; }

        [TestFixtureSetUp]
        public void Init()
        {
            this.JQueryTable = new JQueryTable();
        }

        [Test]
        public void SortedColumns_ShouldReturnACollectionOfSortedColumns()
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