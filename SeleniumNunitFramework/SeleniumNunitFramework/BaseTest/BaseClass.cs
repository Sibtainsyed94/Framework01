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
using System.IO;
using SeleniumNunitFramework.Helpers;

namespace SeleniumNunitFramework.BaseTest
{
    [TestFixture]
    public class BaseClass
    {
        public string timestamp {
          get {
            return DateTime.Now.ToString("MM.dd.yyyy HH.mm.ss");
          }
        }

        private string extentreport_location = "";
        
        public string screenshot_location = "./";

        public ExtentTest test = null;
        public ExtentReports extent = null;
        public IWebDriver driver;

        [OneTimeSetUp]
        public void open()
        {
            extent = new ExtentReports();
            var er_location = ConfigurationManager.AppSettings["ExtentReportLocation"];
            var ss_location = ConfigurationManager.AppSettings["ScreenshotLocation"];
            var x = Directory.GetCurrentDirectory().Replace('\\', '/');
            if (ss_location.StartsWith("./")) {
              ss_location = ss_location.Replace("./", x+"/");
            }
            if (er_location.StartsWith("./")) {
              er_location = er_location.Replace("./", x+"/"); ;
            }
            if (!Directory.Exists(er_location)) {
              Directory.CreateDirectory(er_location);
            }
            if (!Directory.Exists(ss_location)) {
              Directory.CreateDirectory(ss_location);
            }
            screenshot_location = ss_location;
            extentreport_location = string.Format("{0}{1}-Extent.html", er_location, timestamp);
            var htmlReporter = new ExtentHtmlReporter(extentreport_location);
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
            var attachments = new List<string> { };
            attachments.Add(extentreport_location);
            Directory.GetFiles(screenshot_location).ToList().ForEach(x => {
              attachments.Add(x);
            });
            Mailer.SendMail(
               timestamp+" - Test Report",
               "Test Report contains attachment",
               attachments
            );
        }

    }
}
