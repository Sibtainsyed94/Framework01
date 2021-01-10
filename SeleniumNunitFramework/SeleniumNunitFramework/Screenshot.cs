using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Web;

//file path issue gdr exception

namespace SeleniumNunitFramework
{

[TestFixture]
    class Screenshot
    {
        IWebDriver driver;
        [Test]
        //[Author("Sibtain", "sibtainsyed94@gmail.com")]
        //[Description("BQHT Login Verify")]
        //[TestCaseSource("DataDrivenTesting")]

        public void Test1()
        {
            

            try {
                driver = new ChromeDriver();
            
                driver.Manage().Window.Maximize();

                driver.Url = "https://demo.qardanhasana.org/";
                driver.FindElement(By.Id("txtusername")).SendKeys("30442293");
                //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(DateTime.Now.ToShortDateString() + ".png",ScreenshotImageFormat.Png);

               // ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\...\screen.jpeg", ScreenshotImageFormat.Jpeg);
            }

            catch (Exception e)
            {








                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(DateTime.Now.ToShortDateString() + ".png", ScreenshotImageFormat.Png);


                Console.WriteLine(e.StackTrace);
                throw;
            }

            finally
            {
                driver.Quit();

            }

        }
        //static IList DataDrivenTesting()

        //{
        //    ArrayList list = new ArrayList();

        //    list.Add("https://demo.qardanhasana.org/");
        //    //list.Add("https://www.google.com/");
        //    //list.Add("https://www.gmail.com/");

        //    return list;
       }
       
    }


