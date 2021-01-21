using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNunitFramework.BaseTest;
using SeleniumNunitFramework.Helpers;
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

            try {
                test = extent.CreateTest("Login1").Info("Login Test");
                var LOGIN = new Login(driver);
                LOGIN.NavigateToMyAccount();
                string title = driver.Title;

                Assert.AreEqual("My Account", title);
            } catch (Exception e) {
                test.Fail(e.StackTrace);
                var loc = Helpers.Screenshot.TakeScreenshot(ref driver, screenshot_location, timestamp+"-Login2.jpeg");
                JiraGenerateIssue.CreateIssue("Login", new List<string> { loc });
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
                test = extent.CreateTest("My Account").Info("Account Test");
                var myaccount = new MyAccount(driver);
                myaccount.NavigateToProducts();
            } catch (Exception e) {
                test.Fail(e.StackTrace);
                var loc = Helpers.Screenshot.TakeScreenshot(ref driver, screenshot_location, timestamp + "-MyAccount.jpeg");
                JiraGenerateIssue.CreateIssue("MyAccount Failed", new List<string> { loc });

            }
        }

        [Test, Order(3),Category("SmokeTest")]
        public void Products()
        {
            try
            {
                test = extent.CreateTest("Search Product").Info("Product Test");
                var procuct = new Product(driver);
                procuct.NavigateToAddToCart();
            }
            catch (Exception e)
            {
                test.Fail(e.StackTrace);
                var loc = Helpers.Screenshot.TakeScreenshot(ref driver, screenshot_location, timestamp + "-Product.jpeg");
                JiraGenerateIssue.CreateIssue("Products Failed", new List<string> { loc });

            }
        }

        [Test, Order(4),Category("SmokeTest")]
        public void AddToCart()
        {
            try
            {
                test = extent.CreateTest("Add to cart").Info("Add to cart Test");
                var addtocart = new AddToCart(driver);
                Thread.Sleep(3000);
                addtocart.NavigateToCheckout();
            }
            catch(Exception e)
            {
                test.Fail(e.StackTrace);
                var loc = Helpers.Screenshot.TakeScreenshot(ref driver, screenshot_location, timestamp + "-Addtocart.jpeg");
                JiraGenerateIssue.CreateIssue("AddToCart Failed", new List<string> { loc });
            }
           
        }


        [Test, Order(5), Category("SmokeTest")]
        public void Checkout()
        {
            try
            {
                test = extent.CreateTest("Checkout").Info("Checkout Test");
                var checkout = new Checkout(driver);
                checkout.OrderComplete();
                Thread.Sleep(2000);
                string title = driver.Title;

                Assert.AreEqual("Your ordr has been placed!", title);
               
            }
            catch (Exception e)
            {
                test.Fail(e.StackTrace);
                var loc = Helpers.Screenshot.TakeScreenshot(ref driver, screenshot_location, timestamp + "-Checkout.jpeg");
                JiraGenerateIssue.CreateIssue("Checkout Failed", new List<string> { loc });
            }

        }



    }
}
