# Test Strategy - User Registration & Authentication

## 1. Scope
This test suite covers end-to-end UI testing for the User Registration and Authentication flow on https://demo.opencart.com.

### In Scope
- New user registration (positive and negative)
- User login (positive and negative)
- User logout
- Form field validations and boundary testing

### Out of Scope
- API/backend testing
- Performance/load testing
- Payment or checkout flows

## 2. Test Levels
| Level | Approach |
|-------|----------|
| UI Functional | Selenium WebDriver with BDD (SpecFlow/Gherkin) |
| Validation | Form field validation, error message verification |
| Negative | Invalid inputs, missing fields, boundary values |

## 3. Test Types
- **Smoke Tests** (@smoke): Registration, Login, Logout basics
- **Negative Tests** (@negative): Invalid data, empty fields, duplicates
- **Boundary Tests** (@boundary): Max/min field lengths

## 4. Technology Stack
| Component | Technology |
|-----------|-----------|
| Language | C# / .NET 8 |
| UI Automation | Selenium WebDriver |
| Test Framework | NUnit |
| BDD Framework | SpecFlow (Gherkin feature files) |
| Assertions | FluentAssertions |
| Design Pattern | Page Object Model (POM) |

## 5. Risks & Mitigations
| Risk | Mitigation |
|------|-----------|
| Demo site resets hourly | Tests generate unique emails via timestamps |
| Cloudflare protection | Run in non-headless; add wait strategies |
| UI element changes | POM isolates locator changes to Page classes |

## 6. Assumptions
- Chrome (latest) installed
- Stable internet connection
- demo.opencart.com is accessible

## 7. Test Data Approach
- Dynamic generation: `testuser_{timestamp}@mailinator.com`
- Each scenario creates its own data
- No external data files needed

