using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DinerMax3000.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Collections.Generic.List<Business.Menu> resultMenus = NewMethod();

            int countBeforeSave = resultMenus[0].Items.Count;
            resultMenus[0].SaveMenuItem("UT_Name", "UT_Description", 10.00);
            resultMenus = DinerMax3000.Business.Menu.GetAllMenus();
            int countAfterSave = resultMenus[0].Items.Count;

            Assert.IsTrue(countBeforeSave < countAfterSave);
        }

        private static System.Collections.Generic.List<Business.Menu> NewMethod()
        {
            var resultMenus = DinerMax3000.Business.Menu.GetAllMenus();
            Assert.IsTrue(resultMenus.Count > 0);
            return resultMenus;
        }
    }
}
