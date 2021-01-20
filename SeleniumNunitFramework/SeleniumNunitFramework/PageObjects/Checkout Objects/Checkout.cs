using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.PageObjects
{
    public class Checkout
    {
        IWebDriver driver;
        public Checkout(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
       


        [FindsBy(How = How.Id, Using = "button-payment-address")]
        public IWebElement billingconfirm { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input#button-shipping-address")]
        public IWebElement deliveryconfirm { get; set; }

        [FindsBy(How = How.TagName, Using = "textarea")]
        public IWebElement textfield { get; set; }

        [FindsBy(How = How.Id, Using = "button-shipping-method")]
        public IWebElement deliverymethod { get; set; }
        //*[@id="collapse-payment-method"]/div/div[2]/div/input[1]
       
        [FindsBy(How = How.CssSelector, Using = "#collapse-payment-method > div > div.buttons > div > input[type=checkbox]:nth-child(2)")]
        public IWebElement checkbox { get; set; }

        [FindsBy(How = How.Id, Using = "button-payment-method")]
        public IWebElement paymentmethod { get; set; }

        [FindsBy(How = How.Id, Using = "button-confirm")]
        public IWebElement confirmorder { get; set; }

        //[FindsBy(How = How.XPath, Using = "h1[contains(text(),'Your order has been placed!')]")]
        //public IWebElement sucessmessage { get; set; }

        //public string Sucees01()
        //{
        //    return sucessmessage.Text;
        //}

        public void OrderComplete()
        {
            Thread.Sleep(2000);
            billingconfirm.Click();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(3000);
            js.ExecuteScript("window.scrollBy(0,200)");
            //Console.Read();

            
            deliveryconfirm.Click();
            Thread.Sleep(3000);
            textfield.SendKeys("ok");
            Thread.Sleep(3000);
            deliverymethod.Click();
            IJavaScriptExecutor js1 = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(4000);
            js.ExecuteScript("window.scrollBy(0,200)");
            checkbox.Click();
            Thread.Sleep(3000);
            paymentmethod.Click();
            Thread.Sleep(3000);
            confirmorder.Click();
        }
    }
}
