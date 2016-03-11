namespace Utilities.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Cryptography.X509Certificates;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using ServiceStack.Redis;
    using ServiceStack.Redis.Generic;

    [TestFixture]
    public class RedisCacheHelperTest
    {
        private Expression<Action<IRedisTypedClient<string>>> Store;

        private Expression<Func<IRedisTypedClient<string>, string>> GetById;

        private Expression<Func<IRedisClient, IRedisTypedClient<string>>> As;

        private string key;

        private string value;

        private Expression<Func<IRedisTypedClient<string>, IList<string>>> GetAll;

        private Expression<Action<IRedisTypedClient<string>>> StoreAll;

        private Mock<IRedisClient> MockICacheClient { get; set; }

        private Mock<IRedisTypedClient<string>> MockTypedClient { get; set; }

        private RedisHelper RedisHelper { get; set; }

        [Test]
        public void GetCache_ShouldCallThePastInFunction_AndAddToTheCache_WhenTheKeyDoesNotExist()
        {
            // Arrange
            this.MockTypedClient.Setup(GetById).Returns<string>(null);
            this.MockTypedClient.Setup(Store);

            // Act
            this.RedisHelper.GetCacheById(key, () => value);

            // Assert
            this.MockTypedClient.Verify(Store, Times.Once);
            this.MockTypedClient.Verify(GetById, Times.Exactly(2));
        }

        [Test]
        public void GetCache_ShouldGetFromCache_WhenTheKeyExists()
        {
            // Arrange
            this.MockTypedClient.Setup(GetById).Returns(value);

            // Act
            string actual = this.RedisHelper.GetCacheById(key, () => value);

            // Assert
            string expected = value;
            actual.ShouldBeEquivalentTo(expected);

            this.MockTypedClient.Verify(GetById, Times.Once);
            this.MockTypedClient.Verify(Store, Times.Never);
        }

        [Test]
        public void GetCacheTable_ShouldCallThePastInFunction_AndAddToTheCache_WhenTheKeyDoesNotExist()
        {
            // Arrange
            this.MockTypedClient.Setup(GetAll).Returns(null as IList<string>);
            this.MockTypedClient.Setup(StoreAll);

            // Act
            this.RedisHelper.GetCacheTable(key, () => new List<string>() { "1" });

            // Assert
            this.MockTypedClient.Verify(StoreAll, Times.Once);
            this.MockTypedClient.Verify(GetAll, Times.Exactly(2));
        }

        [Test]
        public void GetCacheTable_ShouldGetFromCache_WhenTheKeyExists()
        {
            // Arrange
            this.MockTypedClient.Setup(GetAll).Returns(new List<string>() { "1" });
            this.MockTypedClient.Setup(StoreAll);

            // Act
            IEnumerable<string> actual = this.RedisHelper.GetCacheTable<string>(key, () => new List<string>());

            // Assert
            IEnumerable<string> expected = new List<string>() { "1" };
            actual.ShouldBeEquivalentTo(expected);

            this.MockTypedClient.Verify(GetAll, Times.Once);
            this.MockTypedClient.Verify(StoreAll, Times.Never);
        }

        [SetUp]
        public void Init()
        {
            this.RedisHelper = new RedisHelper();
            this.InitMockRedisTypedClient();
            this.InitMockICacheClient();

            RedisHelper.RedisCacheClient = MockICacheClient.Object;
        }

        private void InitMockRedisTypedClient()
        {
            this.MockTypedClient = new Mock<IRedisTypedClient<string>>();

            key = "the key";
            value = "the value";

            GetById = x => x.GetById(key);
            Store = x => x.Store(value);
            GetAll = x => x.GetAll();
            StoreAll = x => x.StoreAll(It.IsAny<IEnumerable<string>>());
        }

        private void InitMockICacheClient()
        {
            this.MockICacheClient = new Mock<IRedisClient>();
            As = x => x.As<string>();

            this.MockICacheClient.Setup(As).Returns(this.MockTypedClient.Object);
        }
    }
}