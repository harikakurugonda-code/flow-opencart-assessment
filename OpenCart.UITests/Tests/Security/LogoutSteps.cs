using FluentAssertions;
using OpenCart.UIControllers.Controllers.Security;
using OpenCart.UIControllers.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OpenCart.UITests.Tests.Security
{
   [Binding]
   public class LogoutSteps
   {
      private readonly BaseTester _baseTester;

      public LogoutSteps(BaseTester baseTester)
      {
         _baseTester = baseTester;
      }

      [Given(@"I am logged into my account")]
      public void GivenIAmLoggedIntoMyAccount()
      {
         _baseTester.RegisteredEmail = SecurityController.GenerateUniqueEmail();
         _baseTester.RegisteredPassword = "Test@1234";

         SecurityController.NavigateToRegistration();
         SecurityController.Register("Logout", "TestUser", _baseTester.RegisteredEmail, _baseTester.RegisteredPassword);
      }

      [When(@"I click logout")]
      public void WhenIClickLogout()
      {
         SecurityController.LogOut();
      }

      [Then(@"I should see the Account Logout page")]
      public void ThenIShouldSeeTheAccountLogoutPage()
      {
         HomePage.Title.Should().Contain("Logout");
      }

   }
}
