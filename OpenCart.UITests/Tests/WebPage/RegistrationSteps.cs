using OpenCart.UIControllers.Controllers.Security;
using OpenCart.UIControllers.Pages.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OpenCart.UITests.Tests.Security
{
   [Binding]
   public class RegistrationSteps
   {
      private readonly BaseTester _baseTester;

      public RegistrationSteps(BaseTester baseTester)
      {
         _baseTester = baseTester;
      }

      [Given(@"I am on the Registration page")]
      public void GivenIAmOnTheRegistrationPage()
      {
         SecurityController.NavigateToRegistration();
      }

      [When(@"I register with valid user details")]
      public void WhenIRegisterWithValidUserDetails()
      {
         _baseTester.RegisteredEmail = SecurityController.GenerateUniqueEmail();
         _baseTester.RegisteredPassword = "Test@1234";

         SecurityController.Register(
             firstName: "John",
             lastName: "Doe",
             email: _baseTester.RegisteredEmail,
             password: _baseTester.RegisteredPassword
         );
      }

      [Then(@"I should see the account created success message")]
      public void ThenIShouldSeeTheAccountCreatedSuccessMessage()
      {
         RegisterPage.SuccessMessage.Contains("Your Account Has Been Created");
      }

      [When(@"I accept the privacy policy")]
      public void WhenIAcceptThePrivacyPolicy()
      {
         RegisterPage.PrivacyPolicyCheckbox.Click();
      }

      [When(@"I click the Continue button without filling any fields")]
      public void WhenIClickTheContinueButtonWithoutFillingAnyFields()
      {
         SecurityController.SubmitRegistrationForm();
      }

      [Then(@"I should see validation errors for mandatory fields")]
      public void ThenIShouldSeeValidationErrorsForMandatoryFields()
      {
         RegisterPage.FirstNameError.Contains("First name validation error expected");
         RegisterPage.LastNameError.Contains("Last name validation error expected");
         RegisterPage.EmailError.Contains("Email validation error expected");
         RegisterPage.PasswordError.Contains("Password validation error expected");
      }

      [Given(@"I have already registered with a valid email")]
      public void GivenIHaveAlreadyRegisteredWithAValidEmail()
      {
         _baseTester.RegisteredEmail = SecurityController.GenerateUniqueEmail();
         _baseTester.RegisteredPassword = "Test@1234";

         SecurityController.NavigateToRegistration();
         SecurityController.Register("John", "Doe", _baseTester.RegisteredEmail, _baseTester.RegisteredPassword);
         SecurityController.LogOut();
      }

      [When(@"I register with the same email again")]
      public void WhenIRegisterWithTheSameEmailAgain()
      {
         SecurityController.Register("Jane", "Doe", _baseTester.RegisteredEmail, _baseTester.RegisteredPassword);
      }

      [Then(@"I should see a warning about duplicate email")]
      public void ThenIShouldSeeAWarningAboutDuplicateEmail()
      {
         RegisterPage.AlertDangerMessage.Contains("Warning");
      }

      [When(@"I fill in valid registration details without accepting privacy policy")]
      public void WhenIFillInValidRegistrationDetailsWithoutAcceptingPrivacyPolicy()
      {
         var email = SecurityController.GenerateUniqueEmail();
         SecurityController.Register("John", "Doe", email, "Test@1234", agreePrivacyPolicy: false);
      }

      [Then(@"I should see a warning about privacy policy")]
      public void ThenIShouldSeeAWarningAboutPrivacyPolicy()
      {
         RegisterPage.AlertDangerMessage.Contains("Warning");
      }

      [When(@"I register with an invalid email format")]
      public void WhenIRegisterWithAnInvalidEmailFormat()
      {
         SecurityController.Register("John", "Doe", "invalid-email", "Test@1234");
      }

      [Then(@"I should see an email validation error")]
      public void ThenIShouldSeeAnEmailValidationError()
      {
         RegisterPage.EmailError.Contains("Email validation error expected");
      }

      [When(@"I register with a password shorter than minimum length")]
      public void WhenIRegisterWithAPasswordShorterThanMinimumLength()
      {
         var email = SecurityController.GenerateUniqueEmail();
         SecurityController.Register("John", "Doe", email, "12");
      }

      [Then(@"I should see a password validation error")]
      public void ThenIShouldSeeAPasswordValidationError()
      {  
         RegisterPage.PasswordError.Contains("Password validation error expected");
      }

      [When(@"I register with a first name exceeding 32 characters")]
      public void WhenIRegisterWithAFirstNameExceeding32Characters()
      {
         var email = SecurityController.GenerateUniqueEmail();
         var longName = new string('A', 33);
         SecurityController.Register(longName, "Doe", email, "Test@1234");
      }

      [Then(@"I should see a first name validation error")]
      public void ThenIShouldSeeAFirstNameValidationError()
      {
         RegisterPage.FirstNameError.Contains("First name max length error expected");
      }

      [When(@"I register with valid details and subscribe to newsletter")]
      public void WhenIRegisterWithValidDetailsAndSubscribeToNewsletter()
      {
         var email = SecurityController.GenerateUniqueEmail();
         SecurityController.Register("John", "Doe", email, "Test@1234", subscribeNewsletter: true);
      }

   }
}
