Feature: User Login
  As a registered user of OpenCart
  I want to login to my account
  So that I can access my account features

  @positive @smoke
  Scenario: Successful login with valid credentials
    Given I have a registered account
    And I am on the Login page
    When I login with valid credentials
    Then I should be on the My Account page

  @negative
  Scenario: Login with wrong password
    Given I have a registered account
    And I am on the Login page
    When I login with incorrect password
    Then I should see a login warning message

  @negative
  Scenario: Login with non-existent email
    Given I am on the Login page
    When I login with a non-existent email
    Then I should see a login warning message

  @negative
  Scenario: Login with empty fields
    Given I am on the Login page
    When I login with empty email and password
    Then I should see a login warning message

  @positive
  Scenario: Navigate to Forgot Password page
    Given I am on the Login page
    When I click the Forgotten Password link
    Then I should be on the Forgot Password page
