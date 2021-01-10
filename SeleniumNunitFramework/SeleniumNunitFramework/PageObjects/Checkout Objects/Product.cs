using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.PageObjects
{
   public class Product
    {

        IWebDriver driver;
        public Product(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add to Cart')]")]
        public IWebElement select { get; set; }


        public AddToCart NavigateToAddToCart()
        {
            select.Click();
           

            return new AddToCart(driver);
        }


    }
}

//fa fa-shopping-cart
//
