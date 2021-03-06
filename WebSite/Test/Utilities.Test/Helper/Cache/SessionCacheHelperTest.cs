﻿namespace Utilities.Test
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System.Web.SessionState;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class SessionCacheHelperTest
    {
        private string key;

        private string value;

        private SessionHelper SessionHelper { get; set; }

        [Test]
        public void GetCache_ShouldGetFromCache_WhenTheKeyDoesNotExist()
        {
            // Arrange
            HttpContext.Current.Session[this.key] = null;

            // Act
            string actual = this.SessionHelper.GetCacheById(this.key, () => this.value);

            // Assert
            string expected = this.value;

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void GetCache_ShouldGetFromCache_WhenTheKeyExists()
        {
            // Arrange
            HttpContext.Current.Session[this.key] = this.value;

            // Act
            string actual = this.SessionHelper.GetCacheById(this.key, () => "Another Value");

            // Assert
            string expected = this.value;

            actual.ShouldBeEquivalentTo(expected);
        }


        [Test]
        public void GetCacheTable_ShouldGetFromCache_WhenTheKeyDoesNotExist()
        {
            // Arrange
            HttpContext.Current.Session[this.key] = null;

            // Act
            IEnumerable<string> actual = this.SessionHelper.GetCacheTable(this.key, () => new List<string>() { "1" });

            // Assert
            IEnumerable<string> expected = new List<string>() { "1" };

            actual.ShouldAllBeEquivalentTo(expected);
        }

        [Test]
        public void GetCacheTable_ShouldGetFromCache_WhenTheKeyExists()
        {
            // Arrange
            HttpContext.Current.Session[this.key] = new List<string>() { "1" };

            // Act
            IEnumerable<string> actual = this.SessionHelper.GetCacheTable(this.key, () => new List<string>() { "2" });

            // Assert
            IEnumerable<string> expected = new List<string>() { "1" };

            actual.ShouldAllBeEquivalentTo(expected);
        }

        [SetUp]
        public void Init()
        {
            this.SessionHelper = new SessionHelper();

            this.InitKeyAndValue();

            this.InitHttpContext();
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

        private void InitKeyAndValue()
        {
            this.key = "the key";
            this.value = "the value";
        }
    }
}