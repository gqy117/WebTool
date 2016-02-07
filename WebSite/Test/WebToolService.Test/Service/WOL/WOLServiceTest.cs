namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;

    [TestFixture]
    public class WOLServiceTest : TestBase
    {
        private WolService WolService { get; set; }

        [SetUp]
        public override void Init()
        {
            base.Init();
            this.WolService = this.Container.Resolve<WolService>();
        }

        [Test]
        public void Insert_ShouldInsertARecordIntoTheDataBase()
        {
            // Arrange
            WolModel wolModel = new WolModel()
            {
                WolName = "1"
            };

            // Act
            this.WolService.Insert(wolModel);
            var actual = this.WolService.Context.WOLs.Last();

            // Assert
            actual.WOLName.ShouldBeEquivalentTo(wolModel.WolName);
        }

        [Test]
        public void GetWolById_ShouldReturnAllTheRecordInTheDatabase_WhenWeDoNotProvideTheModel()
        {
            // Arrange
            int userId = 1;

            // Act
            IList<WolModel> result = this.WolService.GetWolById(1);
            int actual = result.First().WOLID;

            // Assert
            int expected = 1;
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}