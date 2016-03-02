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
    using WebToolService;

    public abstract class ControllerTestBase
    {
        protected Mock<HttpContextBase> MockContext;

        protected Mock<ILanguageService> MockLanguageService = new Mock<ILanguageService>();

        protected Mock<HttpRequestBase> MockRequest;

        protected Mock<HttpResponseBase> MockResponse;

        protected Mock<IUserService> MockUserService = new Mock<IUserService>();

        protected IUnityContainer Container { get; set; }

        protected abstract Controller Controller { get; }

        public virtual void Init()
        {
            this.SetupDependency();
            this.InitMockRequest();
            this.InitMockResponse();
            this.InitMockContext();
            this.RegisterMockingService();
            this.InitController();
            this.InitControllerContext();
        }

        protected abstract void InitController();

        protected virtual void RegisterMockingService()
        {
            this.Container.RegisterInstance<IUserService>(this.MockUserService.Object);
            this.Container.RegisterInstance<ILanguageService>(this.MockLanguageService.Object);
        }

        private void InitControllerContext()
        {
            Controller.ControllerContext = new ControllerContext(MockContext.Object, new RouteData(), Controller);
        }

        private void InitMockContext()
        {
            MockContext = new Mock<HttpContextBase>();

            MockContext.Setup(c => c.Request).Returns(MockRequest.Object);
            MockContext.Setup(x => x.Response).Returns(MockResponse.Object);
        }

        private void InitMockRequest()
        {
            MockRequest = new Mock<HttpRequestBase>();
        }

        private void InitMockResponse()
        {
            MockResponse = new Mock<HttpResponseBase>();
        }

        private void SetupDependency()
        {
            BootStrap bootStrap = new BootStrap();
            bootStrap.Configure();

            this.Container = bootStrap.MyContainer;
        }
    }
}