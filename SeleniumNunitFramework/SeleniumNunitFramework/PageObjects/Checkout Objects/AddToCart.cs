using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.PageObjects
{
    public class AddToCart
    {

        IWebDriver driver;
        public AddToCart(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='button-cart']")]
        public IWebElement AddinCart { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Checkout')]")]
        public IWebElement checkoutclick { get; set; }


        public void NavigatoToCheckout()
        {
            AddinCart.Click();
            checkoutclick.Click();
        }

    }
}

///html[1]/body[1]/nav[1]/div[1]/div[2]/ul[1]/li[5]/a[1]/i[1]
