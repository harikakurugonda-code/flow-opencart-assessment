Feature: User Logout
  As a logged-in user of OpenCart
  I want to logout from my account
  So that my session is ended securely

  @positive 
  Scenario: Successful logout after login
    Given I am logged into my account
    When I click logout
    Then I should see the Account Logout page
