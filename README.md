# flow-opencart-assessment
Open Cart Registration and Authentication
## Technology Stack
- **Language**: C# (.NET 8)
- **UI Automation**: Selenium WebDriver
- **Test Framework**: NUnit
- **BDD Framework**: SpecFlow 
- **Design Pattern**: Page Object Model (POM)

## Project Structure

OpenCart.UITests.sln
|
|-- OpenCart.UIControllers/              (Page Objects + Controllers)
|   |-- Common/
|   |   |-- ControllerCommon.cs          (WebDriver, BaseUrl, waits)
|   |-- Pages/
|   |   |-- HomePage.cs                  (nav menu elements)
|   |   |-- LoginPage.cs                (login form elements)
|   |   |-- RegisterPage.cs             (registration form elements)
|   |   |-- ForgotPasswordPage.cs
|   |-- Controllers/
|           |-- SecurityController.cs    (login, register, logout actions)
|
|-- OpenCart.UITests/                    (BDD Test Project)
    |-- UITests.cs                       (browser setup/teardown)
    |-- Tests/
    |   |-- BrowserStartup.cs            (Chrome initialization)
    |   |-- BaseTester.cs                (shared test data)
    |   |-- WebPage/
    |       |-- RegistrationSteps.cs     (registration step definitions)
    |       |-- LoginSteps.cs            (login step definitions)
    |       |-- LogoutSteps.cs           (logout step definitions)
    |-- Features/
        |-- Registration.feature         
        |-- Login.feature                
        |-- Logout.feature               
```

## Prerequisites
1. .NET 8 SDK
2. Google Chrome (latest version)

## How to Run
### Visual Studio
1. Install Allure CLI
2. Open `OpenCart.UITests.sln`
3. Build 
4. Test Explorer > Run All
5. Generate report(OpenCart.UITests/bin/Debug/net8.0/allure-results)
