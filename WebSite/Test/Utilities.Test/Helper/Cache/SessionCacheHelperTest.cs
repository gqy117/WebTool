namespace Utilities.Test
{
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web;
    using System.Web.SessionState;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class SessionCacheHelperTest
    {
        private SessionHelper SessionHelper { get; set; }

        private string key;

        private string value;

        [SetUp]
        public void Init()
        {
            this.SessionHelper = new SessionHelper();

            this.InitKeyAndValue();

            this.InitHttpContext();
        }

        private void InitKeyAndValue()
        {
            this.key = "the key";
            this.value = "the value";
        }

        private void InitHttpContext()
        {
            var httpRequest = new HttpRequest("", "http://localhost/", "");

            // Step 2: Setup the HTTP Response
            var httpResponce = new HttpResponse(new StringWriter());

            // Step 3: Setup the Http Context
            var httpContext = new HttpContext(httpRequest, httpResponce);
            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(), new HttpStaticObjectsCollection(), 10, true, HttpCookieMode.AutoDetect, SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Standard, new[] { typeof(HttpSessionStateContainer) }, null).Invoke(new object[] { sessionContainer });

            HttpContext.Current = httpContext;
        }

        [Test]
        public void GetCache_ShouldGetFromCache_WhenTheKeyExists()
        {
            // Arrange
            HttpContext.Current.Session[this.key] = this.value;

            // Act
            string actual = this.SessionHelper.GetCache(this.key, () => "Another Value");

            // Assert
            string expected = this.value;

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void GetCache_ShouldGetFromCache_WhenTheKeyDoesNotExist()
        {
            // Arrange
            HttpContext.Current.Session[this.key] = null;

            // Act
            string actual = this.SessionHelper.GetCache(this.key, () => this.value);

            // Assert
            string expected = this.value;

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}