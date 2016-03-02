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
    using WebToolCulture;

    [TestFixture]
    public class LanguageServiceTest : TestBase
    {
        private LanguageService LanguageService { get; set; }

        [Test]
        public void GetLanguageModel_ShouldReturnTheGetLanguageModel_WhenTheInputLanguageCodeExists()
        {
            // Arrange
            string languageCode = "en";

            // Act
            LanguageModel actual = this.LanguageService.GetLanguageModel(languageCode);

            // Assert
            LanguageModel expected = new LanguageModel()
            {
                CurrentLanguage = new Language() { Code = "en", Name = "English", PictureName = "us.png" },
                ListLanguage = new List<Language>()
                {
                    new Language(){ Code = "zh-CN", Name = "中文", PictureName = "cn.png"},
                }
            };

            actual.ShouldBeEquivalentTo(expected);
        }

        [SetUp]
        public override void Init()
        {
            base.Init();
            this.LanguageService = this.Container.Resolve<LanguageService>();
        }
    }
}