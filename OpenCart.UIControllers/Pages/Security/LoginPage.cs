using OpenCart.UIControllers.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.Input;

namespace OpenCartControllers.Pages.Security
{
   public class LoginPage
   {
      public static IWebElement BreadCrumbLoginText
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//*[@class='breadcrumb']/li[3]"));
         }
      }
      public static IWebElement EmailAddressTextbox
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.Id("input-email"));
         }
      }
      public static IWebElement PasswordTextbox
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.Id("input-password"));
         }
      }
      public static IWebElement ForgotPassword
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//input[@id='input-password']/following-sibling::a"));
         }
      }

      public static IWebElement LoginButton
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//button[text()='Login']"));
         }
      }

      public static string ErrorText
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.CssSelector(".alert-danger")).Text;
         }
      }
   }
}