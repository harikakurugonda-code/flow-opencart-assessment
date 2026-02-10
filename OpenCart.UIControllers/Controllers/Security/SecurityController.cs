using OpenCart.UIControllers.Common;
using OpenCart.UIControllers.Pages;
using OpenCart.UIControllers.Pages.Security;
using OpenCartControllers.Pages.Security;

namespace OpenCart.UIControllers.Controllers.Security
{
   public class SecurityController : ControllerBase
   {
      public static void NavigateToRegistration()
      {
         ControllerCommon.WebDriver.Navigate().GoToUrl(
         ControllerCommon.BaseUrl + "/index.php?route=account/register");
         Thread.Sleep(3000); // Small delay to ensure page starts loading before waiting for it to load completely
         WaitForPageLoad();
      }

      public static void NavigateToLogin()
      {
         ControllerCommon.WebDriver.Navigate().GoToUrl(
         ControllerCommon.BaseUrl + "/index.php?route=account/login");
         Thread.Sleep(3000); // Small delay to ensure page starts loading before waiting for it to load completely
         WaitForPageLoad();
      }

      public static void NavigateToForgotPassword()
      {
         NavigateToLogin();
         LoginPage.ForgotPassword.Click();
         WaitForPageLoad();
      }

      public static void Register(string firstName, string lastName, string email, string password, bool subscribeNewsletter = false, bool agreePrivacyPolicy = true)
      {
         RegisterPage.FirstNameTextbox.Clear();
         RegisterPage.FirstNameTextbox.SendKeys(firstName);

         RegisterPage.LastNameTextbox.Clear();
         RegisterPage.LastNameTextbox.SendKeys(lastName);

         RegisterPage.EmailTextbox.Clear();
         RegisterPage.EmailTextbox.SendKeys(email);

         RegisterPage.PasswordTextbox.Clear();
         RegisterPage.PasswordTextbox.SendKeys(password);

         if (subscribeNewsletter)
            RegisterPage.NewsletterToggle.Click();

         if (agreePrivacyPolicy)
            RegisterPage.PrivacyPolicyCheckbox.Click();

         RegisterPage.ContinueButton.Click();
         WaitForPageLoad();
      }

      public static void SubmitRegistrationForm()
      {
         RegisterPage.ContinueButton.Click();
         WaitForPageLoad();
      }

      public static void LoginByUsername(string email, string password)
      {
         LoginPage.EmailAddressTextbox.Clear();
         LoginPage.EmailAddressTextbox.SendKeys(email);

         LoginPage.PasswordTextbox.Clear();
         LoginPage.PasswordTextbox.SendKeys(password);

         LoginPage.LoginButton.Click();
         WaitForPageLoad();
      }

      public static void LogOut()
      {
         HomePage.MyAccountDropdown.Click();
         HomePage.LogOutButton.Click();
         WaitForPageLoad();
      }

      public static void ForgottenPassword(string email)
      {
         ForgotPasswordPage.EmailTextbox.Clear();
         ForgotPasswordPage.EmailTextbox.SendKeys(email);
         ForgotPasswordPage.ContinueButton.Click();
         WaitForPageLoad();
      }

      public static string GenerateUniqueEmail()
      {
         return $"testuser_{DateTime.Now.Ticks}@mailinator.com";
      }

   }
}