using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNunitFramework.BaseTest;
using SeleniumNunitFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.TestScripts
{
    [TestFixture]
    [Parallelizable]
    public class CheckoutScenario : BaseClass
    {
        [Test,Order(1),Category("SmokeTest")]
        public void Login()
        {

            try
            {
                var LOGIN = new Login(driver);
                LOGIN.NavigateToMyAccount();
                string title = driver.Title;

                Assert.AreEqual("My Account", title);
            }
            catch (Exception e)
            {

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\SIBTAIN\Source\Repos\Framework01\SeleniumNunitFramework\SeleniumNunitFramework\Screenshots\Login2.jpeg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }

            //var product = Myaccount.NavigateToProducts();

            //var addtocart = product.NavigateToAddToCart();
            // Thread.Sleep(3000);
            // addtocart.NavigatoToCheckout();
        }

        [Test,Order(2),Category("SmokeTest")]
        public void MyAccount()
        {
            try
            {
                var myaccount = new MyAccount(driver);
                myaccount.NavigateToProducts();
            }

            catch (Exception e)
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\SIBTAIN\Source\Repos\Framework01\SeleniumNunitFramework\SeleniumNunitFramework\Screenshots\MyAccount.jpeg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        [Test, Order(3),Category("SmokeTest")]
        public void Products()
        {
            try
            {
                var procuct = new Product(driver);
                procuct.NavigateToAddToCart();
            }
            catch (Exception e)
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\SIBTAIN\Source\Repos\Framework01\SeleniumNunitFramework\SeleniumNunitFramework\Screenshots\Product.jpeg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        [Test, Order(4),Category("SmokeTest")]
        public void Addtocart()
        {
            try
            {
                var addtocart = new AddToCart(driver);
                Thread.Sleep(3000);
                addtocart.NavigatoToCheckout();
            }
            catch(Exception e)
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\SIBTAIN\Source\Repos\Framework01\SeleniumNunitFramework\SeleniumNunitFramework\Screenshots\Addtocart.jpeg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }
           
        }




    }
}
