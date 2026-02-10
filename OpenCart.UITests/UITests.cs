using OpenCart.UIControllers.Common;
using OpenCart.UITests.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OpenCart.UITests
{
   [Binding]
   public class UITests
   {
      [BeforeTestRun]
      public static void Setup()
      {
         try
         {
            BrowserStartup.Initialize();
         }
         catch(Exception ex)
         {
            ControllerCommon.Stop_WebDriver();
            throw;
         }

      }
      [AfterTestRun]
      public static void TearDown()
      {
         ControllerCommon.Stop_WebDriver();
      }
      [BeforeScenario]
      public void BeforeScenario()
      {
         try
         {
            if (ControllerCommon.WebDriver == null)
            {
               BrowserStartup.Initialize();
            }
            var title = ControllerCommon.WebDriver.Title;
            ControllerCommon.WebDriver.Navigate().GoToUrl(ControllerCommon.BaseUrl.ToString());
            WaitForCloudflare();
         }
         catch
         {
            ControllerCommon.Stop_WebDriver();
            BrowserStartup.Initialize();
            ControllerCommon.WebDriver.Navigate().GoToUrl(ControllerCommon.BaseUrl.ToString());
            ControllerCommon.WaitForPageLoad();
         }
      }
      private static void WaitForCloudflare(int maxWaitSeconds = 30)
      {
         var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(
             ControllerCommon.WebDriver, TimeSpan.FromSeconds(maxWaitSeconds));
         wait.Until(driver =>
         {
            try
            {
               return !driver.PageSource.Contains("Verifying you are human")
                      && !driver.PageSource.Contains("Just a moment");
            }
            catch
            {
               return false;
            }
         });
         ControllerCommon.WaitForPageLoad();
      }
   }
}
