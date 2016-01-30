namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class SortedColumnTest : TestBase
    {
        [TestFixtureSetUp]
        public override void Init()
        {
            base.Init();
        }

        [Test]
        public void Equals_ShouldReturnTrue_WhenDirectionAndPropertyNameAreTheSame()
        {
            // Arrange
            string propertyName1 = "property1";
            string sortingDirection1 = "asc";
            var sortedColumn1 = new SortedColumn(propertyName1, sortingDirection1);

            string propertyName2 = "property1";
            string sortingDirection2 = "asc";
            var sortedColumn2 = new SortedColumn(propertyName2, sortingDirection2);

            // Act
            bool actual = sortedColumn1.Equals(sortedColumn2);


            // Assert
            bool expected = true;

            actual.ShouldBeEquivalentTo(expected);
        }

        #region Equals_ShouldReturnFalse_WhenDirectionAndPropertyNameAreNotTheSame

        private static object[] PropertyNamesAreTheSameDirectionsAreNot = { new object[] { new SortedColumn("property1", "asc"), new SortedColumn("property1", "desc") } };
        private static object[] PropertyNamesAreNotTheSameDirectionsAreTheSame = { new object[] { new SortedColumn("property1", "asc"), new SortedColumn("property2", "asc") } };

        [Test]
        [TestCaseSource("PropertyNamesAreTheSameDirectionsAreNot")]
        [TestCaseSource("PropertyNamesAreNotTheSameDirectionsAreTheSame")]
        public void Equals_ShouldReturnFalse_WhenDirectionOrPropertyNameAreNotTheSame(SortedColumn sortedColumn1, SortedColumn sortedColumn2)
        {
            // Act
            bool actual = sortedColumn1.Equals(sortedColumn2);

            // Assert
            bool expected = false;

            actual.ShouldBeEquivalentTo(expected);
        }
        #endregion

        [Test]
        public void GetHashCode_ShouldCalculateTheHashCodeBasedOnDirectionAndPropertyName()
        {
            // Arrange
            string propertyName1 = "property1";
            string sortingDirection1 = "asc";
            var sortedColumn1 = new SortedColumn(propertyName1, sortingDirection1);

            // Act
            int actual = sortedColumn1.GetHashCode();

            // Assert
            int expected = 2036934070;
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}