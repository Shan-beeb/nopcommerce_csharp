Feature: Functionality of nopCommerce internal portal login page
  In order to check the functionality of login page with registered and lon-registred users
  As a business analyst
  I wan to observe the expected and actual behavior

  @happy
  Scenario Outline: To check nopCommerce internal portal login page with registered users
    Given a user wants to login to nopCommerce internal portal
    When a user enters <email> and <password> as credentials
    And a user clicks on submit button
    Then a user should be logged in
    Examples:
      | email               | password |
      | admin@yourstore.com | admin    |

  @sad
  Scenario Outline: To check nopCommerce internal portal login page with non-registered users
    Given a user wants to login to nopCommerce internal portal
    When a user enters <email> and <password> as credentials
    And a user clicks on submit button
    Then a user should get the following error message in admin area login page
    """
    Login was unsuccessful. Please correct the errors and try again.
    No customer account found
    """
    Examples:
      | email                     | password |
      | wrongemail1@yourstore.com | admin    |
      | wrongemail2@yourstore.com | admin    |
      | wrongemail3@yourstore.com | admin    |

  @sad
  Scenario Outline: To check nopCommerce internal portal login page with invalid password
    Given a user wants to login to nopCommerce internal portal
    When a user enters <email> and <password> as credentials
    And a user clicks on submit button
    Then a user should get the following error message in admin area login page
    """
    Login was unsuccessful. Please correct the errors and try again.
    The credentials provided are incorrect
    """
    Examples:
      | email               | password      |
      | admin@yourstore.com | wrongpassword |

  @sad
  Scenario: To check nopCommerce internal portal login page with empty email
    Given a user wants to login to nopCommerce internal portal
    When a user does not enter any email
    And a user clicks on submit button
    Then a user should get the following error message underneath user's email input
    """
    Please enter your email
    """

  @sad
  Scenario: To check nopCommerce internal portal login page with invalid email
    Given a user wants to login to nopCommerce internal portal
    When a user does not enter any email
    And a user clicks on submit button
    Then following emails will trigger a validation edit as Wrong email
      | email                  |
      | adminyourstore         |
      | adminyourstore..com    |
      | admin..yourstore.com   |
      | admin*9yourstore.com   |
      | admin()yourstore.com   |
      | admin#$%#yourstore.com |
   

