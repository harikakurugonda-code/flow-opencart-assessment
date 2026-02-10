# flow-opencart-assessment
Open Cart Registration and Authentication
## Technology Stack
- **Language**: C# (.NET 8)
- **UI Automation**: Selenium WebDriver
- **Test Framework**: NUnit
- **BDD Framework**: SpecFlow (Gherkin feature files)
- **Assertions**: FluentAssertions
- **Design Pattern**: Page Object Model (POM)

## Project Structure

OpenCart.UITests.sln
|
|-- OpenCart.UIControllers/              (Page Objects + Controllers)
|   |-- Common/
|   |   |-- ControllerCommon.cs          (WebDriver, BaseUrl, waits)
|   |-- Pages/
|   |   |-- HomePage.cs                  (nav menu elements)
|   |   |-- Security/
|   |       |-- LoginPage.cs             (login form elements)
|   |       |-- RegisterPage.cs          (registration form elements)
|   |       |-- ForgotPasswordPage.cs
|   |-- Controllers/
|       |-- ControllerBase.cs
|       |-- Security/
|           |-- SecurityController.cs    (login, register, logout actions)
|
|-- OpenCart.UITests/                    (BDD Test Project)
    |-- UITests.cs                       (browser setup/teardown hooks)
    |-- Tests/
    |   |-- BrowserStartup.cs            (Chrome initialization)
    |   |-- BaseTester.cs                (shared test data)
    |   |-- Security/
    |       |-- RegistrationSteps.cs     (registration step definitions)
    |       |-- LoginSteps.cs            (login step definitions)
    |       |-- LogoutSteps.cs           (logout step definitions)
    |-- Features/
        |-- Registration.feature         (8 BDD scenarios)
        |-- Login.feature                (5 BDD scenarios)
        |-- Logout.feature               (1 BDD scenario)
```

## Prerequisites
1. .NET 8 SDK - https://dotnet.microsoft.com/download/dotnet/8.0
2. Google Chrome (latest version)

## How to Run

### Command Line
git clone https://github.com/YOUR_USERNAME/opencart-sdet-assignment.git
cd opencart-sdet-assignment

dotnet build OpenCart.UITests.sln


### Visual Studio
1. Open `OpenCart.UITests.sln`
2. Build (Ctrl+Shift+B)
3. Test Explorer (Test > Test Explorer) > Run All
