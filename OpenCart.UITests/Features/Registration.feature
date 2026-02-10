Feature: User Registration
  As a new user of OpenCart
  I want to register an account
  So that I can shop on the website

  @positive 
  Scenario: Successful registration with valid data
    Given I am on the Registration page
    When I register with valid user details
    Then I should see the account created success message

  @negative
  Scenario: Registration with empty mandatory fields
    Given I am on the Registration page
    When I accept the privacy policy
    And I click the Continue button without filling any fields
    Then I should see validation errors for mandatory fields

  @negative
  Scenario: Registration with duplicate email
    Given I have already registered with a valid email
    And I am on the Registration page
    When I register with the same email again
    Then I should see a warning about duplicate email

  @negative
  Scenario: Registration without accepting privacy policy
    Given I am on the Registration page
    When I fill in valid registration details without accepting privacy policy
    Then I should see a warning about privacy policy

  @negative
  Scenario: Registration with invalid email format
    Given I am on the Registration page
    When I register with an invalid email format
    Then I should see an email validation error

  @negative @boundary
  Scenario: Registration with password below minimum length
    Given I am on the Registration page
    When I register with a password shorter than minimum length
    Then I should see a password validation error

  @boundary
  Scenario: Registration with first name exceeding maximum length
    Given I am on the Registration page
    When I register with a first name exceeding 32 characters
    Then I should see a first name validation error

  @positive
  Scenario: Registration with newsletter subscription
    Given I am on the Registration page
    When I register with valid details and subscribe to newsletter
    Then I should see the account created success message
