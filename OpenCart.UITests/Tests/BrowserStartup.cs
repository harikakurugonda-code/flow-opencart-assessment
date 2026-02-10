using OpenCart.UIControllers.Common;
using OpenQA.Selenium.Chrome;

namespace OpenCart.UITests.Tests
{
   public class BrowserStartup
   {
      [SetUp]
      public static void Initialize()
      {
         var options = new ChromeOptions();
         options.AddArgument("--start-maximized");
         options.AddArgument("--no-sandbox");
         options.AddArgument("--disable-dev-shm-usage");
         options.AddArgument("--ignore-ssl-errors=yes");
         options.AddArgument("--ignore-certificate-errors");
         options.AddArgument("--disable-blink-features=AutomationControlled");
         options.AddArgument("--disable-gpu");
         var userDataDir = Path.Combine(Path.GetTempPath(), "ChromeTest_" + Guid.NewGuid().ToString());
         options.AddArgument($"--user-data-dir={userDataDir}");

         ControllerCommon.WebDriver = new ChromeDriver(options);
         ControllerCommon.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
         ControllerCommon.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
         ControllerCommon.BaseUrl = new Uri("https://demo.opencart.com");

      }     
   }
}