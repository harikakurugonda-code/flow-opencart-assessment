using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCart.UIControllers.Common
{
   public class ControllerCommon
   {
      private static IWebDriver _webDriver;
      public static Uri BaseUrl { get; set; }

      public static IWebDriver WebDriver
      {
         get
         {
            if (_webDriver == null)
            {
               throw new InvalidOperationException("WebDriver has not been initialized. Please set the WebDriver before accessing it.");
            }
            return _webDriver;
         }
         set
         {
            _webDriver = value;
         }
      }

      public static WebDriverWait WebDriverWait
      {
         get
         {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));

         }
      }

      public static void WaitForPageLoad(int timeoutSeconds = 10)
      {
         var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSeconds));
         wait.Until(driver=>((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
      }
      public static bool IsLoggedIn
      {
         get
         {
            try
            {
               return WebDriver.FindElement(By.LinkText("Edit Account")).Displayed;
            }
            catch
            {
               return false;
            }
         }
      }

      public static void Stop_WebDriver()
      {
         try
         {
            _webDriver?.Close();
         }
         catch { }
         try
         {
            _webDriver?.Quit();
         }
         catch { }
         try
         {
            _webDriver?.Dispose();
         }
         catch { }
         _webDriver = null;
      }
   }
}