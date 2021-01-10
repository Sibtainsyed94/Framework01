using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumNunitFramework
{
    [TestFixture]
    class ExtentReport
    {

        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {

            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\SIBTAIN\Desktop\SeleniumNunitFramework\SeleniumNunitFramework\ExtentReports");
            extent.AttachReporter(htmlReporter);

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();

        }

        [Test]
      
        public void Test1()
        {
            IWebDriver driver = null;
            ExtentTest test = null;
            try
            {
               test =  extent.CreateTest("Test1").Info("Test Started");
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                test.Log(Status.Info, "Chrome is launched");
                driver.Url = "https://demo.qardanhasana.org/";
                driver.FindElement(By.Id("txtusername")).SendKeys("30442293");
                test.Log(Status.Info, "username entered");
                
                driver.Quit();
                test.Log(Status.Info, "Test is passed");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
