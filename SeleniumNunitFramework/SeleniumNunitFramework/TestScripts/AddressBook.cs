using NUnit.Framework;
using SeleniumNunitFramework.BaseTest;
using SeleniumNunitFramework.TestScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.PageObjects.Address_Objects
{

    [TestFixture]
    [Parallelizable]
    public class AddressBook : BaseClass

    {

        [Test, Order(1), Category("AddressScenario")]
        public void Login()
        {
            //var LOGIN1 = new Login1(driver);
            //   LOGIN1.NavigateToAddress();

          var LOGIN  = new Login(driver);
            LOGIN.NavigateToAddress();
        }

        [Test, Order(2), Category("AddressScenario")]
        public void Addressenter()
        {

            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=account/address/add");

            var address = new AddNewAddress(driver);
          
            address.AddressFields();

        }

    }
}
