using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.PageObjects
{
    public class MyAccount
    {

        IWebDriver driver;
        public MyAccount(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"search\"]/input")]
        public IWebElement searchbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"search\"]/span/button")]
        public IWebElement searchclick { get; set; }


        public Product NavigateToProducts()
        {
            searchbox.SendKeys("Hp");
            searchclick.Click();
            return new Product(driver);
        }

    }
}
