namespace WebToolService.Test
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class LogonModelTest
    {
        [Test]
        public void RememberMe_ShouldBeTrue_ByDefault()
        {
            // Arrange
            LogOnModel logOnModel = new LogOnModel();

            // Action
            bool actual = logOnModel.RememberMe;

            // Assert
            bool expected = true;
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}