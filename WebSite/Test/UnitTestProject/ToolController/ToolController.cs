using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebTool;
using WebToolService;

namespace UnitTestProject
{
    [TestClass]
    public class ToolControllerTest : BaseControllerTest
    {
        #region Properties

        #endregion
        #region Methods
        #region Override
        public override void InitMainController()
        {
            this.MainController = new ToolController() { WOLService = new WOLService(), CurrentUserModel = new UserModel() { UserId = 1 }, FileName = AppDomain.CurrentDomain.BaseDirectory + @"\WOL\WolCmd.exe" };
        }
        #endregion
        [TestMethod]
        public void WakeUp()
        {
            this.MainController.WakeUp();
        }
        [TestMethod]
        public void WOLTable()
        {
            JQueryTable JQueryTable = new JQueryTable()
            {
                iSortCol_ = new ReadOnlyCollection<int>(new List<int>() { 1 }), 
                iSortingCols =1,
                sSortDir_ = new ReadOnlyCollection<string>(new List<string>() { "asc" }),
                mDataProp_ = new ReadOnlyCollection<string>(new List<string>(){"0","1","2","3","4","5","6","7"}),
            };
            this.MainController.WOLTable(JQueryTable);
        }
        #endregion
    }
}
