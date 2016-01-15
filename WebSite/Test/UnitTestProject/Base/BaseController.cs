﻿namespace UnitTestProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using WebTool;

    [TestClass]
    public abstract class BaseControllerTest
    {
        #region Constructors
        public BaseControllerTest()
        {
            this.InitDI();
            this.InitRequest();
            this.InitResponse();
            this.InitHttpContext();
            this.InitController();
            this.InitActionExecutingContext();
        }
        #endregion

        #region Properties
        public dynamic MainController { get; set; }

        public Mock<HttpContextBase> HttpContext { get; set; }

        public Mock<HttpRequestBase> Request { get; set; }

        public Mock<HttpResponseBase> Response { get; set; }

        public Mock<ControllerContext> ControllerContext { get; set; }

        public Mock<ActionExecutingContext> ActionExecutingContext { get; set; }

        #endregion

        #region Methods
        #region InitDI
        public virtual void InitDI()
        {
            Utilities.Bootstrap.Startup();
        }
        #endregion
        #region Request
        public virtual void InitRequest()
        {
            this.Request = new Mock<HttpRequestBase>();
        }
        #endregion
        #region Response
        public virtual void InitResponse()
        {
            this.Response = new Mock<HttpResponseBase>();
            this.Response.Setup(r => r.Cookies).Returns(new HttpCookieCollection());
        }
        #endregion
        #region HttpContext
        public virtual void InitHttpContext()
        {
            this.HttpContext = new Mock<HttpContextBase>();
            this.HttpContext.Setup(c => c.Request).Returns(this.Request.Object);
            this.HttpContext.Setup(c => c.Response).Returns(this.Response.Object);
        }
        #endregion
        #region ActionExecutingContext
        public virtual void InitActionExecutingContext()
        {
            this.ActionExecutingContext = new Mock<ActionExecutingContext>();
            this.ActionExecutingContext.Setup(c => c.HttpContext).Returns(this.HttpContext.Object);
        }
        #endregion
        #region MainController
        public virtual void InitController()
        {
            this.InitControllerContext();
            this.InitMainController();
            this.BindControllerContext();
        }

        public virtual void InitControllerContext()
        {
            this.ControllerContext = new Mock<ControllerContext>();
            this.ControllerContext.SetupGet(x => x.HttpContext)
                                 .Returns(this.HttpContext.Object);
        }

        public abstract void InitMainController();

        public virtual void BindControllerContext()
        {
            this.MainController.ControllerContext = this.ControllerContext.Object; 
        }
        #endregion
        #endregion
    }
}
