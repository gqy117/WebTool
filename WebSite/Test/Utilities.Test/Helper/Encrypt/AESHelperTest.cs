namespace Utilities.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class AESHelperTest
    {
        private AESHelper AESHelper { get; set; }

        [Test]
        public void EncryptStringToBytes_ShouldReturnEncryptedString_WhenTheInputIs1()
        {
            // Arrange
            string plaintext = "1";

            // Act
            string actual = this.AESHelper.EncryptStringToBytes(plaintext);

            // Assert
            string expected = "Pn8YTV5phgjk62xMg9xxhw==";

            actual.ShouldBeEquivalentTo(expected);
        }

        [SetUp]
        public void Init()
        {
            this.AESHelper = new AESHelper();
        }
    }
}