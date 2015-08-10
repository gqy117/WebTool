namespace UITest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;

    public abstract class BaseController
    {
        #region Properties
        private InternetExplorerDriver ie;

        private string mainSite = "http://gqy115.cloudapp.net/";

        private ChromeDriver chrome;

        private List<RemoteWebDriver> broswers;

        #region Constructors
        public BaseController()
        {
            this.Broswers.Add(this.IE);
            this.Broswers.Add(this.Chrome);
            this.Init();
        }
        #endregion

        public string MainSite
        {
            get { return this.mainSite; }
            set { this.mainSite = value; }
        }

        public InternetExplorerDriver IE
        {
            get
            {
                this.ie = this.ie ?? new InternetExplorerDriver();

                return this.ie;
            }
        }

        public ChromeDriver Chrome
        {
            get
            {
                this.chrome = this.chrome ?? new ChromeDriver();

                return this.chrome;
            }
        }
        #endregion
        public RemoteWebDriver CurrentBroswer { get; set; }

        public List<RemoteWebDriver> Broswers
        {
            get
            {
                this.broswers = this.broswers ?? new List<RemoteWebDriver>();

                return this.broswers;
            }
        }

        #region Methods
        public abstract void Init();
        #region Run
        public void Run(Action action)
        {
            foreach (RemoteWebDriver broswer in this.Broswers)
            {
                this.SetCurrentBroswer(broswer);
                action();
                this.CloseBroswer();
            }
        }

        public virtual void SetCurrentBroswer(RemoteWebDriver broswer)
        {
            this.CurrentBroswer = broswer;
        }

        public virtual void CloseBroswer()
        {
            this.CurrentBroswer.Quit();
        }
        #endregion
        #endregion
    }
}
