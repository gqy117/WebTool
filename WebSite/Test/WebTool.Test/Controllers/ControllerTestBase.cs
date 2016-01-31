namespace WebTool.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Microsoft.Practices.Unity;
    using Moq;

    public abstract class ControllerTestBase
    {
        protected Mock<HttpContextBase> MockContext;

        protected Mock<HttpRequestBase> MockRequest;

        protected Mock<HttpResponseBase> MockResponse;

        protected IUnityContainer Container { get; set; }

        protected abstract Controller Controller { get; }

        protected abstract void InitController();

        public virtual void Init()
        {
            this.SetupDependency();
            this.InitMockRequest();
            this.InitMockResponse();
            this.InitMockContext();
            this.InitController();
            this.InitControllerContext();
        }

        private void InitMockRequest()
        {
            MockRequest = new Mock<HttpRequestBase>();
        }

        private void InitMockResponse()
        {
            MockResponse = new Mock<HttpResponseBase>();
        }

        private void InitMockContext()
        {
            MockContext = new Mock<HttpContextBase>();

            MockContext.Setup(c => c.Request).Returns(MockRequest.Object);
            MockContext.Setup(x => x.Response).Returns(MockResponse.Object);
        }

        private void InitControllerContext()
        {
            Controller.ControllerContext = new ControllerContext(MockContext.Object, new RouteData(), Controller);
        }

        private void SetupDependency()
        {
            BootStrap bootStrap = new BootStrap();
            bootStrap.Configure();

            this.Container = bootStrap.MyContainer;
        }
    }
}