using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace UITest
{
    public abstract class BaseController
    {
        #region Properties
        #region MainSite
        private string _MainSite = "http://localhost:12599/";
        public string MainSite
        {
            get { return _MainSite; }
            set { _MainSite = value; }
        }
        #endregion
        #region Broswer
        #region IE

        private InternetExplorerDriver _IE;
        public InternetExplorerDriver IE
        {
            get
            {
                _IE = _IE?? new InternetExplorerDriver();
                return _IE;
            }
        }
        #endregion
        #region Chrome
        private ChromeDriver _Chrome;
        public ChromeDriver Chrome
        {
            get
            {
                _Chrome = _Chrome ?? new ChromeDriver();
                return _Chrome;
            }
        }
        #endregion
        public RemoteWebDriver CurrentBroswer { get; set; }
        private List<RemoteWebDriver> _Broswers;
        public List<RemoteWebDriver> Broswers {
            get
            {
                _Broswers = _Broswers ?? new List<RemoteWebDriver>();
                return _Broswers;
            }
        }
        #endregion
        #endregion
        #region Constructors
        public BaseController()
        {
            Broswers.Add(IE);
            Broswers.Add(Chrome);
            Init();
        } 
        #endregion
        #region Methods
        public abstract void Init();
        #region Run
        public void Run(Action action)
        {
            foreach (RemoteWebDriver broswer in Broswers)
            {
                SetCurrentBroswer(broswer);
                action();
                CloseBroswer();
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
