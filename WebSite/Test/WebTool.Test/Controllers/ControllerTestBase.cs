namespace WebTool.Test
{
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
            this.Controller.ControllerContext = new ControllerContext(this.MockContext.Object, new RouteData(), this.Controller);
        }

        private void InitMockContext()
        {
            this.MockContext = new Mock<HttpContextBase>();

            this.MockContext.Setup(c => c.Request).Returns(this.MockRequest.Object);
            this.MockContext.Setup(x => x.Response).Returns(this.MockResponse.Object);
        }

        private void InitMockRequest()
        {
            this.MockRequest = new Mock<HttpRequestBase>();
        }

        private void InitMockResponse()
        {
            this.MockResponse = new Mock<HttpResponseBase>();
        }

        private void SetupDependency()
        {
            BootStrap bootStrap = new BootStrap();
            bootStrap.Configure();

            this.Container = bootStrap.MyContainer;
        }
    }
}