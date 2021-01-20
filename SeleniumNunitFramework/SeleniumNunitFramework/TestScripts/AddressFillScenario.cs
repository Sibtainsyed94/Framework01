using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNunitFramework.BaseTest;
using SeleniumNunitFramework.Helpers;
using SeleniumNunitFramework.TestScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.PageObjects.Address_Objects
{

    [TestFixture]
    [Parallelizable]

    public class AddressBook : BaseClass

    {
        
        //public ExtentTest test = null;
        //Screencapture obj =  new Screencapture();

        [Test, Order(1), Category("AddressScenario")]
        public void Login()
        {
            try {
                //var LOGIN1 = new Login1(driver);
                //   LOGIN1.NavigateToAddress();
                test = extent.CreateTest("Login").Info("Login Test");
                var LOGIN = new Login(driver);
                LOGIN.NavigateToAddress();
                //h2[contains(text(),'Add Address')]
                string title = driver.Title;
                Assert.AreEqual("My Account",title);
            } catch (Exception e) {
                test.Fail(e.StackTrace);
                //obj.Capture();
                Helpers.Screenshot.TakeScreenshot(ref driver, screenshot_location, timestamp + "-Login.jpeg");
                Console.WriteLine(e.StackTrace);
                throw;
            }

            
        }

        [Test, Order(2), Category("AddressScenario")]
        public void Addressenter()
        {
            try {
                test = extent.CreateTest("Address Fill").Info("Address Test");
                driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=account/address/add");
                var address = new AddNewAddress(driver);
                address.AddressFields();
                string actualsucessmessage = address.Suceess();
                string expected = "Yur address has been successfully added";
                Assert.IsTrue(actualsucessmessage.Equals(expected));
            } catch (Exception e) {
                test.Fail(e.StackTrace);
                Helpers.Screenshot.TakeScreenshot(ref driver, screenshot_location, timestamp + "-Address.jpeg");
                Console.WriteLine(e.StackTrace);
                throw;
            }

        }

    }
}
