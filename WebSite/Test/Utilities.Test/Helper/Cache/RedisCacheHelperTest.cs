namespace Utilities.Test
{
    using System;
    using System.Linq.Expressions;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using StackExchange.Redis.Extensions.Core;

    [TestFixture]
    public class RedisCacheHelperTest
    {
        private Expression<Func<ICacheClient, bool>> addMethod;

        private Expression<Func<ICacheClient, bool>> existsMethod;

        private Expression<Func<ICacheClient, string>> getMethod;

        private string key;

        private string value;

        private Mock<ICacheClient> MockICacheClient { get; set; }

        private RedisHelper RedisHelper { get; set; }

        [Test]
        public void GetCache_ShouldCallThePastInFunction_AndAddToTheCache_WhenTheKeyDoesNotExist()
        {
            // Arrange
            this.MockICacheClient.Setup(existsMethod).Returns(false);

            this.MockICacheClient.Setup(addMethod).Returns(true);

            // Act
            this.RedisHelper.GetCache(key, () => value);

            // Assert
            this.MockICacheClient.Verify(addMethod, Times.Once);
            this.MockICacheClient.Verify(getMethod, Times.Never);
        }

        [Test]
        public void GetCache_ShouldGetFromCache_WhenTheKeyExists()
        {
            // Arrange
            this.MockICacheClient.Setup(existsMethod).Returns(true);

            this.MockICacheClient.Setup(getMethod).Returns(value);

            // Act
            this.RedisHelper.GetCache(key, () => value);

            // Assert
            this.MockICacheClient.Verify(getMethod, Times.Once);
            this.MockICacheClient.Verify(addMethod, Times.Never);
        }

        [SetUp]
        public void Init()
        {
            this.RedisHelper = new RedisHelper();
            this.MockICacheClient = new Mock<ICacheClient>();
            RedisHelper.StackExchangeRedisCacheClient = MockICacheClient.Object;

            InitMockICacheClient();
        }

        private void InitMockICacheClient()
        {
            key = "the key";
            value = "the value";
            existsMethod = x => x.Exists(key);
            getMethod = x => x.Get<string>(key);
            addMethod = x => x.Add(key, value);
        }
    }
}