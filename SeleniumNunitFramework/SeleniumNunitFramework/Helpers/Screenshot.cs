using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.Helpers
{
  class Screenshot {
    public static string TakeScreenshot(
      ref IWebDriver driver,
      string location,
      string filename,
      ScreenshotImageFormat format = ScreenshotImageFormat.Jpeg
    ) {
      var loc = string.Format("{0}{1}", location, filename);
      ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(loc, format);
      return loc;
    }
  }
}
