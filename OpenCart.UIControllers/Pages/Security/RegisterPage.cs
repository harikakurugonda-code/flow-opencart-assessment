using OpenCart.UIControllers.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.UIControllers.Pages.Security
{
   public class RegisterPage
   {
      public static IWebElement FirstNameTextbox
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.Id("input-firstname"));
         }
      }
      public static IWebElement LastNameTextbox
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.Id("input-lastname"));
         }
      }

      public static IWebElement EmailTextbox
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
      public static IWebElement NewsletterToggle
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//input[@name='newsletter'][@value='1']"));
         }
      }

      public static IWebElement PrivacyPolicyCheckbox
      {
         get
         {
            return ControllerCommon.WebDriver.FindElement(By.XPath("//input[@name='agree']"));
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
               return ControllerCommon.WebDriver.FindElement(By.XPath("//div[@id='content']/h1")).Text;
            }
            catch { return string.Empty; }
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

      public static string FirstNameError
      {
         get
         {
            try
            { 
               return ControllerCommon.WebDriver.FindElement(By.Id("error-firstname")).Text; 
            }
            catch 
            {
               return string.Empty; 
            }
         }
      }

      public static string LastNameError
      {
         get
         {
            try 
            { 
               return ControllerCommon.WebDriver.FindElement(By.Id("error-lastname")).Text;
            }
            catch
            { 
               return string.Empty; 
            }
         }
      }

      public static string EmailError
      {
         get
         {
            try 
            { 
               return ControllerCommon.WebDriver.FindElement(By.Id("error-email")).Text; 
            }
            catch 
            { 
               return string.Empty; 
            }
         }
      }

      public static string PasswordError
      {
         get
         {
            try 
            { 
               return ControllerCommon.WebDriver.FindElement(By.Id("error-password")).Text; 
            }
            catch 
            { 
               return string.Empty; 
            }
         }
      }

   }
}
