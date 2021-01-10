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

namespace SeleniumNunitFramework.BaseTest
{
    public class BaseClass
    {

        public IWebDriver driver;

        [OneTimeSetUp]

        public void open()
        {
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
            //driver.Quit();

     }

    }
}
