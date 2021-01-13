using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumNunitFramework.TestScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.PageObjects
{
    public class Login
    {

        IWebDriver driver;
        public Login(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id,Using = "input-email")]
        public IWebElement email { get; set; }

        [FindsBy(How = How.Id, Using = "input-password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div/div[2]/div/form/input")]
        public IWebElement loginbutton { get; set; }




        public MyAccount NavigateToMyAccount()
        {
            ExcelLib.PopulateInCollection(@"C:\Users\SIBTAIN\Source\Repos\Framework01\SeleniumNunitFramework\SeleniumNunitFramework\Credentials.xlsx");
            email.SendKeys(ExcelLib.ReadData(1, "Username"));
            password.SendKeys(ExcelLib.ReadData(1, "Password"));
            loginbutton.Click();
            return new MyAccount(driver);

        }

        public AddNewAddress NavigateToAddress()
        {
            ExcelLib.PopulateInCollection(@"C:\Users\SIBTAIN\Source\Repos\Framework01\SeleniumNunitFramework\SeleniumNunitFramework\Credentials.xlsx");
            email.SendKeys(ExcelLib.ReadData(1, "Username"));
            password.SendKeys(ExcelLib.ReadData(1, "Password"));
            loginbutton.Click();
            //Addressselect.Click();

            return new AddNewAddress(driver);

        }



    }
}
