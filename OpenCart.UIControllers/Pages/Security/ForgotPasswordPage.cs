using OpenCart.UIControllers.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.UIControllers.Pages.Security
{
   public class ForgotPasswordPage
   {
      public static IWebElement EmailTextbox
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.Id("input-email"));
         }
      }

      public static IWebElement ContinueButton
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.CssSelector("button[type='submit']"));
         }
      }

      public static string SuccessMessage
      {
         get
         {          
            try 
            { 
               return ControllerCommon.WebDriver.FindElement(By.CssSelector(".alert-success")).Text; 
            }
            catch 
            { 
               return string.Empty;
            }
         }
      }

      public static string AlertDangerMessage
      {
         get
         {          
            try 
            { 
               return ControllerCommon.WebDriver.FindElement(By.CssSelector(".alert-danger")).Text; 
            }
            catch 
            { 
               return string.Empty; 
            }
         }
      }

   }
}
