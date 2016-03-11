namespace Utilities.Test
{
    using System;
    using System.Linq.Expressions;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using ServiceStack.Redis;

    [TestFixture]
    public class RedisCacheHelperTest
    {
        private Expression<Func<IRedisClient, string>> Store;

        private Expression<Func<IRedisClient, string>> GetById;

        private string key;

        private string value;

        private Mock<IRedisClient> MockICacheClient { get; set; }

        private RedisHelper RedisHelper { get; set; }

        [Test]
        public void GetCache_ShouldCallThePastInFunction_AndAddToTheCache_WhenTheKeyDoesNotExist()
        {
            // Arrange
            this.MockICacheClient.Setup(GetById).Returns<string>(null);

            // Act
            this.RedisHelper.GetCache(key, () => value);

            // Assert
            this.MockICacheClient.Verify(Store, Times.Once);
            this.MockICacheClient.Verify(GetById, Times.Never);
        }

        [Test]
        public void GetCache_ShouldGetFromCache_WhenTheKeyExists()
        {
            // Arrange
            this.MockICacheClient.Setup(GetById).Returns(value);

            // Act
            this.RedisHelper.GetCache(key, () => value);

            // Assert
            this.MockICacheClient.Verify(GetById, Times.Once);
            this.MockICacheClient.Verify(Store, Times.Never);
        }

        [SetUp]
        public void Init()
        {
            this.RedisHelper = new RedisHelper();
            this.MockICacheClient = new Mock<IRedisClient>();
            RedisHelper.RedisCacheClient = MockICacheClient.Object;

            InitMockICacheClient();
        }

        private void InitMockICacheClient()
        {
            key = "the key";
            value = "the value";
            GetById = x => x.GetById<string>(key);
            Store = x => x.Store(value);
        }
    }
}