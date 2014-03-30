using System;
using System.Web;
using TechTalk.SpecFlow;
using WebTool;
using WebToolService;

namespace BDD
{
    [Binding]
    public class AccountControllerFlow : BaseController
    {
        #region Properties
        private LoginModel LoginModel = new LoginModel() { UserName = "1", Password = "1" };
        #endregion
        #region Methods
        #region Override
        public override void InitRequest()
        {
            base.InitRequest();
            this.Request.SetupGet(r => r.Cookies).Returns(new HttpCookieCollection() { new HttpCookie(ConstParameter.WebToolUserName, "") });
        }
        public override void InitMainController()
        {
            this.MainController = new AccountController() { UserService = new UserService() };
        }
        #endregion
        [When(@"I open login page")]
        public void WhenIOpenLoginPage()
        {
            MainController.Login();
        }

        [Then(@"I see no exceptions")]
        public void ThenISeeNoExceptions()
        {

        }
        #endregion
    }
}
