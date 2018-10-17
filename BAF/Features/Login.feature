@DemoLoginSuite
Feature: Login Test
	Check if login functionality works

@LoginDemoGroup
@LoginDemo
Scenario: 01 Login Demo chrome
	Given I navigate to application
	And I login with user credentials
	And I click login
	Then I should see user logged in to the application

@LoginDemo
Scenario: 02 Login Demo firefox
	Given I navigate to application
	And I enter username and password
		| UserName | Password |
		| admin    | admin    |
	And I click login
	Then I should see user logged in to the application

@LoginDemoGroup
@LoginDemo
Scenario: 03 Login Demo firefox
	Given I navigate to application
	And I enter username and password
		| UserName | Password |
		| admin    | admin    |
	And I click login
	Then I should see user logged in to the application
