using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.TestScripts
{
   public class AddNewAddress
    {
        IWebDriver driver;
        public AddNewAddress(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "input-firstname")]
        public IWebElement firstname { get; set; }

        [FindsBy(How = How.Id, Using = "input-lastname")]
        public IWebElement lastname { get; set; }

        [FindsBy(How = How.Id, Using = "input-address-1")]
        public IWebElement address1 { get; set; }

        [FindsBy(How = How.Id, Using = "input-address-2")]
        public IWebElement address2 { get; set; }

        [FindsBy(How = How.Id, Using = "input-city")]
        public IWebElement city { get; set; }

        [FindsBy(How = How.Id, Using = "input-postcode")]
        public IWebElement postalcode { get; set; }
        //input-country
        [FindsBy(How = How.Id, Using = "input-country")]
        public IWebElement country { get; set; }

        [FindsBy(How = How.Id, Using = "input-zone")]
        public IWebElement state { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[@id='account-address']/div[1]/div[1]/form[1]/div[1]/div[2]/input[1]")]
        public IWebElement submit { get; set; }


        public void AddressFields()
        {
            ExcelLib.PopulateInCollection(@"C:\Users\SIBTAIN\Desktop\SeleniumNunitFramework\SeleniumNunitFramework\AddressDetails.xlsx");
            firstname.SendKeys(ExcelLib.ReadData(1, "Firstname"));
            lastname.SendKeys(ExcelLib.ReadData(1, "Lastname"));
            address1.SendKeys(ExcelLib.ReadData(1, "Address1"));
            address2.SendKeys(ExcelLib.ReadData(1, "Address2"));
            city.SendKeys(ExcelLib.ReadData(1, "City"));
            postalcode.SendKeys(ExcelLib.ReadData(1, "Postalcode"));
            Thread.Sleep(2000);
            country.SendKeys(ExcelLib.ReadData(1, "Country"));
            Thread.Sleep(2000);
            //country.SendKeys(Keys.Enter);
            state.SendKeys(ExcelLib.ReadData(1, "State"));
            //state.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            submit.Click();

        }


    }
}
