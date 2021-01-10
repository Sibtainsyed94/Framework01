using NUnit.Framework;
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

            
            var LOGIN = new Login(driver);
           LOGIN.NavigateToMyAccount();
           //var product = Myaccount.NavigateToProducts();
            
           //var addtocart = product.NavigateToAddToCart();
           // Thread.Sleep(3000);
           // addtocart.NavigatoToCheckout();
        }

        [Test,Order(2),Category("SmokeTest")]
        public void MyAccount()
        {
            
            var myaccount = new MyAccount(driver);
            myaccount.NavigateToProducts();
        }

        [Test, Order(3),Category("SmokeTest")]
        public void Products()
        {
            
            var procuct = new Product(driver);
            procuct.NavigateToAddToCart();
        }

        [Test, Order(4),Category("SmokeTest")]
        public void Addtocart()
        {
            
            var addtocart = new AddToCart(driver);

            Thread.Sleep(3000);
            addtocart.NavigatoToCheckout();
        }




    }
}
