using OpenCart.UIControllers.Common;
using OpenQA.Selenium;

namespace OpenCart.UIControllers.Pages
{
   public class HomePage
   {
      public static IWebElement MyAccountDropdown
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//a[contains(., 'My Account')]//parent::div"));
         }
      }

      public static IWebElement RegisterMenuOption
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//a[text()='Register']"));
         }
      }

      public static IWebElement LoginMenuOption
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//a[text()='Login']"));
         }
      }

      public static IWebElement LogOutButton
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.LinkText("Logout"));
         }
      }
      public static string Title
      {
         get
         {
            return ControllerCommon.WebDriver.Title;
         }
      }


   }
}