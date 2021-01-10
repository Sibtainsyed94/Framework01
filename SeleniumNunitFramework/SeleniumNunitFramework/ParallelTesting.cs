// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNunitFramework.Utilities;

namespace SeleniumNunitFramework
{
    [TestFixture]
    public class ParallelTesting
    {

        IWebDriver driver;

        [Test,Category("LoginTest")]
        public void TestMethod1()

        {

          var Driver =   new BrowserUtility().Init(driver);
            Driver.FindElement(By.Id("txtusername")).SendKeys("30442293");

        }



        [Test, Category("LoginTest")]
        public void TestMethod2()

        {

            var Driver = new BrowserUtility().Init(driver);
            Driver.FindElement(By.Id("txtusername")).SendKeys("30442293");

        }
        [Test, Category("LoginTest")]
        public void TestMethod3()

        {

            var Driver = new BrowserUtility().Init(driver);
            Driver.FindElement(By.Id("txtusername")).SendKeys("30442293");

        }
        [Test, Category("LoginTest")]
        public void TestMethod4()

        {

            var Driver = new BrowserUtility().Init(driver);
            Driver.FindElement(By.Id("txtusername")).SendKeys("30442293");

        }
    }

}


