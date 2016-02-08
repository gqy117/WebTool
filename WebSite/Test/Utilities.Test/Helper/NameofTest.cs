namespace Utilities.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class NameofTest
    {
        [Test]
        public void Property_ShouldReturnTheNameOfTheProperty_WhenTheExpressionIsNotNull()
        {
            // Arrange

            // Act
            string actual = Nameof<NameofTestClass>.Property(x => x.Id);

            // Assert
            string expected = "Id";
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Property_ShouldThrowArgumentException_WhenTheExpressionIsNull()
        {
            // Arrange

            // Act
            Action action = () => Nameof<NameofTestClass>.Property<string>(null);

            // Assert
            action.ShouldThrow<NullReferenceException>();
        }

        private class NameofTestClass
        {
            public int Id { get; set; }
        }
    }
}