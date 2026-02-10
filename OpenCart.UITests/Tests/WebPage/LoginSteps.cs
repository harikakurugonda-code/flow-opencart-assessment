using FluentAssertions;
using OpenCart.UIControllers.Common;
using OpenCart.UIControllers.Controllers.Security;
using OpenCart.UIControllers.Pages;
using OpenCartControllers.Pages.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OpenCart.UITests.Tests.Security
{
   [Binding]
   public class LoginSteps
   {
      private readonly BaseTester _baseTester;

      public LoginSteps(BaseTester baseTester)
      {
         _baseTester = baseTester;
      }

      [Given(@"I have a registered account")]
      public void GivenIHaveARegisteredAccount()
      {
         _baseTester.RegisteredEmail = SecurityController.GenerateUniqueEmail();
         _baseTester.RegisteredPassword = "Test@1234";

         SecurityController.NavigateToRegistration();
         SecurityController.Register("Test", "User", _baseTester.RegisteredEmail, _baseTester.RegisteredPassword);
         SecurityController.LogOut();
      }

      [Given(@"I am on the Login page")]
      public void GivenIAmOnTheLoginPage()
      {
         SecurityController.NavigateToLogin();
      }

      [When(@"I login with valid credentials")]
      public void WhenILoginWithValidCredentials()
      {
         SecurityController.LoginByUsername(_baseTester.RegisteredEmail, _baseTester.RegisteredPassword);
      }

      [Then(@"I should be on the My Account page")]
      public void ThenIShouldBeOnTheMyAccountPage()
      {
         ControllerCommon.IsLoggedIn.Should().BeTrue("User should be on My Account page after login");
      }

      [When(@"I login with incorrect password")]
      public void WhenILoginWithIncorrectPassword()
      {
         SecurityController.LoginByUsername(_baseTester.RegisteredEmail, "WrongPassword123");
      }

      [Then(@"I should see a login warning message")]
      public void ThenIShouldSeeALoginWarningMessage()
      {
         LoginPage.ErrorText.Should().Contain("Warning");
      }

      [When(@"I login with a non-existent email")]
      public void WhenILoginWithANonExistentEmail()
      {
         SecurityController.LoginByUsername("nonexistent_user_xyz@test.com", "Test@1234");
      }

      [When(@"I login with empty email and password")]
      public void WhenILoginWithEmptyEmailAndPassword()
      {
         SecurityController.LoginByUsername("", "");
      }

      [When(@"I click the Forgotten Password link")]
      public void WhenIClickTheForgottenPasswordLink()
      {
         LoginPage.ForgotPassword.Click();
      }

      [Then(@"I should be on the Forgot Password page")]
      public void ThenIShouldBeOnTheForgotPasswordPage()
      {
         HomePage.Title.Should().Contain("Forgot");
      }

   }
}
