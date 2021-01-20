using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumNunitFramework.BaseTest
{
    [TestFixture]
    public class BaseClass
    {
        public String photoTime = DateTime.Now.ToString("MM.dd.yyyy HH.mm.ss");
        public ExtentTest test = null;
        public ExtentReports extent = null;
        public IWebDriver driver;

        [OneTimeSetUp]

        public void open()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\SIBTAIN\Source\Repos\Framework01\SeleniumNunitFramework\SeleniumNunitFramework\ExtentReports\" + photoTime + "Extent.html");
            extent.AttachReporter(htmlReporter);

            string execbrowser = ConfigurationManager.AppSettings["executionbrowser"].ToString();
            string url = ConfigurationManager.AppSettings["URL"].ToString();

            if (execbrowser == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (execbrowser == "firefox")
            {
                 driver = new FirefoxDriver();
            }


            //driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //var URL = ConfigurationManager.AppSettings["URL"];

            driver.Url = url;


        }


        [OneTimeTearDown]
     public void close()
     {
            extent.Flush();
            //driver.Quit();

        }

    }
}
